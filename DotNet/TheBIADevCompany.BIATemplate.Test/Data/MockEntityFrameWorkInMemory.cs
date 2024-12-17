// <copyright file="MockEntityFrameWorkInMemory.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>
namespace TheBIADevCompany.BIATemplate.Test.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using BIA.Net.Core.Infrastructure.Data;
    using BIA.Net.Core.Test.Data;
#if BIA_FRONT_FEATURE
    using TheBIADevCompany.BIATemplate.Domain.Site.Entities;
    using TheBIADevCompany.BIATemplate.Domain.User.Entities;
    using TheBIADevCompany.BIATemplate.Domain.View.Entities;
#endif
    using TheBIADevCompany.BIATemplate.Infrastructure.Data;

    /// <summary>
    /// Manage the mock of the DB context as an "in memory" database.
    /// </summary>
    /// <seealso cref="AbstractMockEntityFramework{TDbContext}"/>
    public class MockEntityFrameworkInMemory : AbstractMockEntityFramework<DataContext, DataContextNoTracking>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockEntityFrameworkInMemory"/> class.
        /// </summary>
        /// <param name="dbContext">The DB context.</param>
        /// <param name="dbContextReadOnly">The DB context readonly.</param>
        public MockEntityFrameworkInMemory(IQueryableUnitOfWork dbContext, IQueryableUnitOfWorkNoTracking dbContextReadOnly)
            : base(dbContext, dbContextReadOnly)
        {
            // Do nothing. Used to create the DbContext through IoC.
        }
#if BIA_FRONT_FEATURE

        #region Sites methods

        /// <inheritdoc cref="IDataSites.CountSites"/>
        public int CountSites()
        {
            return this.GetDbContext().Sites.Count();
        }

        /// <inheritdoc cref="IDataSites.GetSite(int)"/>
        public Site GetSite(int id)
        {
            return this.GetDbContext().Sites.Find(id);
        }

        /// <inheritdoc cref="IDataSites.InitDefaultSites"/>
        public void InitDefaultSites()
        {
            int id = 1;

            foreach (string title in DataConstants.DefaultSitesTitles)
            {
                Site site = new Site
                {
                    Id = id++,
                    Title = title,
                    Members = new List<Member>(),
                };

                this.GetDbContext().Sites.Add(site);
            }

            this.GetDbContext().SaveChanges();
        }

        #endregion Sites methods

        #region Users methods

        /// <inheritdoc cref="IDataUsers.AddMember(int, int, int, ICollection{MemberRole})"/>
        public void AddMember(int id, int teamId, int userId, ICollection<MemberRole> roles)
        {
            Member member = new Member()
            {
                Id = id,
                TeamId = teamId,
                UserId = userId,
                MemberRoles = roles,
            };

            this.GetDbContext().Members.Add(member);
            this.GetDbContext().SaveChanges();
        }

        /// <inheritdoc cref="IDataUsers.AddUser(int, string, string, int?, int?, ICollection{MemberRole})"/>
        public void AddUser(int id, string firstName, string lastName, int? memberId = null, int? memberSiteId = null, ICollection<MemberRole> memberRoles = null)
        {
            User user = new User()
            {
                Id = id,
                Company = "TheBIADevCompany",
                Country = "France",
                DaiDate = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Department = "DM",
                DistinguishedName = "DistinguishedName",
                Email = $"{firstName}{lastName}@fake.com",
                ExternalCompany = string.Empty,
                FirstName = firstName,
                IsActive = true,
                IsEmployee = true,
                IsExternal = false,
                LastLoginDate = DateTime.Now.AddDays(-2),
                LastName = lastName,
                Login = firstName + lastName,
                Manager = "Big BOSS",
                Members = new List<Member>(),
                Office = "101",
                Site = DataConstants.DefaultSitesTitles[0],
                SubDepartment = "BIA",
                ViewUsers = new List<ViewUser>(),
            };

            this.GetDbContext().Users.Add(user);

            if (memberId != null)
            {
                this.AddMember(memberId.Value, memberSiteId.Value, id, memberRoles);
            }
            else
            {
                // We do not save changes in the "if", because it is already done by AddMember().
                this.GetDbContext().SaveChanges();
            }
        }

        #endregion Users methods
#endif
        #region AbstractMockEntityFrameworkInMemory methods

        /// <inheritdoc cref="AbstractMockEntityFramework{TDbContext}.InitDefaultData" />
        public override void InitDefaultData()
        {
#if BIA_FRONT_FEATURE
            this.InitDefaultSites();
#endif
        }

        #endregion AbstractMockEntityFrameworkInMemory methods
    }
}
