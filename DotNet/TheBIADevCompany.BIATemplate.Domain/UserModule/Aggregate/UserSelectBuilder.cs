// <copyright file="UserSelectBuilder.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.UserModule.Aggregate
{
    using System;
    using System.Linq.Expressions;
    using BIA.Net.Core.Domain.Dto.User;
    using TheBIADevCompany.BIATemplate.Domain.Dto.User;

    /// <summary>
    /// The select builder of the user entity.
    /// </summary>
    public static class UserSelectBuilder
    {
        /// <summary>
        /// Gets the expression used to select user.
        /// </summary>
        /// <returns>The expression.</returns>
        public static Expression<Func<User, UserDto>> EntityToDto()
        {
            return user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Login = user.Login,
                LastName = user.LastName,
            };
        }

        /// <summary>
        /// Gets the expression used to select user.
        /// </summary>
        /// <returns>The expression.</returns>
        public static Expression<Func<User, UserInfoDto>> SelectUserInfo()
        {
            return user => new UserInfoDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Login = user.Login,
                LastName = user.LastName,
                Country = user.Country,
                IsActive = user.IsActive,
            };
        }
    }
}