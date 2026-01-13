// <copyright file="UserFromDirectoryMapper.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.User.Mappers
{
    using System;
    using BIA.Net.Core.Domain.User.Mappers;
    using BIA.Net.Core.Domain.User.Services;
    using TheBIADevCompany.BIATemplate.Domain.Dto.User;
    using TheBIADevCompany.BIATemplate.Domain.User.Models;

    /// <summary>
    /// The mapper used from directory for user from directory dto.
    /// </summary>
    /// <typeparam name="TUserFromDirectoryDto">Type of the user from directory dto.</typeparam>
    /// <typeparam name="TUserFromDirectory">Type of the user from directory.</typeparam>
    /// <param name="userIdentityKeyDomainService">The user identity key domain service.</param>
    public class UserFromDirectoryMapper(IUserIdentityKeyDomainService userIdentityKeyDomainService) : IUserFromDirectoryMapper<UserFromDirectoryDto, UserFromDirectory>
    {
        private readonly IUserIdentityKeyDomainService userIdentityKeyDomainService = userIdentityKeyDomainService;

        /// <summary>
        /// Create a user DTO from an entity.
        /// </summary>
        /// <returns>The user DTO.</returns>
        public Func<UserFromDirectory, UserFromDirectoryDto> EntityToDto()
        {
            return entity => new UserFromDirectoryDto
            {
                IdentityKey = this.userIdentityKeyDomainService.GetDirectoryIdentityKey(entity),
                DisplayName = entity.LastName + " " + entity.FirstName + "(" + entity.Domain + "\\" + entity.Login + ")",
                Domain = entity.Domain,
            };
        }
    }
}