// <copyright file="UserSynchronizeDomainService.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.UserModule.Service
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BIA.Net.Core.Domain.RepoContract;
    using TheBIADevCompany.BIATemplate.Domain.UserModule.Aggregate;

    /// <summary>
    /// The service used for synchronization between AD and DB.
    /// </summary>
    public class UserSynchronizeDomainService : IUserSynchronizeDomainService
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ITGenericRepository<User, int> repository;

        /// <summary>
        /// The AD helper.
        /// </summary>
        private readonly IUserDirectoryRepository<UserFromDirectory> userDirectoryHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSynchronizeDomainService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="configuration">The configuration of the BiaNet section.</param>
        /// <param name="adHelper">The AD helper.</param>
        public UserSynchronizeDomainService(ITGenericRepository<User, int> repository, IUserDirectoryRepository<UserFromDirectory> adHelper)
        {
            this.repository = repository;
            this.userDirectoryHelper = adHelper;
        }

        /// <inheritdoc cref="IUserSynchronizeDomainService.SynchronizeFromADGroupAsync"/>
        public async Task SynchronizeFromADGroupAsync(bool fullSynchro = false)
        {
            List<User> users = (await this.repository.GetAllEntityAsync()).ToList();
            List<string> usersSidInDirectory = (await this.userDirectoryHelper.GetAllUsersSidInRoleToSync("User"))?.ToList();

            if (usersSidInDirectory == null)
            {
                // If user in DB just synchronize the field of the active user.
                foreach (User user in users)
                {
                    if (user.IsActive)
                    {
                        var userFromDirectory = await this.userDirectoryHelper.ResolveUserByLogin(user.Login, fullSynchro);
                        if (userFromDirectory != null)
                        {
                            this.ResynchronizeUser(user, userFromDirectory);
                        }
                    }
                }
            }
            else
            {
                ConcurrentBag<UserFromDirectory> usersFromDirectory = new ConcurrentBag<UserFromDirectory>();

                Parallel.ForEach(usersSidInDirectory, sid =>
                {
                    var userFromDirectory = this.userDirectoryHelper.ResolveUserBySid(sid, fullSynchro).Result;
                    if (userFromDirectory != null)
                    {
                        usersFromDirectory.Add(userFromDirectory);
                    }
                });

                foreach (User user in users)
                {
                    var userFromDirectory = usersFromDirectory.FirstOrDefault(u => u.Login == user.Login);

                    if (userFromDirectory == null)
                    {
                        if (user.IsActive)
                        {
                            this.DeactivateUser(user);
                        }
                    }
                    else
                    {
                        if (fullSynchro)
                        {
                            this.ResynchronizeUser(user, userFromDirectory);
                        }
                    }
                }

                foreach (UserFromDirectory userFromDirectory in usersFromDirectory)
                {
                    var foundUser = users.FirstOrDefault(a => a.Login == userFromDirectory.Login);

                    this.AddOrActiveUserFromDirectory(userFromDirectory, foundUser);
                }

                await this.repository.UnitOfWork.CommitAsync();
            }
        }

        /// <summary>
        /// Deactivaye a user.
        /// </summary>
        /// <param name="user">The user to deactivate.</param>
        public void DeactivateUser(User user)
        {
            user.IsActive = false;
        }

        /// <summary>
        /// Add or active User from AD.
        /// </summary>
        /// <param name="userFormDirectory">the user in Directory.</param>
        /// <param name="foundUser">the User if exist in repository.</param>
        /// <returns>The async task.</returns>
        public User AddOrActiveUserFromDirectory(UserFromDirectory userFormDirectory, User foundUser)
        {
            if (foundUser == null)
            {
                if (userFormDirectory.Login != null)
                {
                    // Create the missing user
                    User user = new User();
                    UserFromDirectory.UpdateUserFieldFromDirectory(user, userFormDirectory);
                    this.repository.Add(user);
                    return user;
                }
            }
            else if (!foundUser.IsActive)
            {
                foundUser.IsActive = true;
            }

            return foundUser;
        }

        private void ResynchronizeUser(User user, UserFromDirectory userFromDirectory)
        {
            if (userFromDirectory != null)
            {
                UserFromDirectory.UpdateUserFieldFromDirectory(user, userFromDirectory);
                this.repository.Update(user);
            }
        }
    }
}