// <copyright file="SiteMapper.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.SiteModule.Aggregate
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using BIA.Net.Core.Domain;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;
    using TheBIADevCompany.BIATemplate.Domain.Dto.Site;

    /// <summary>
    /// The mapper used for site.
    /// </summary>
    public class SiteMapper : BaseMapper<SiteDto, Site, int>
    {
        /// <summary>
        /// Gets or sets the collection used for expressions to access fields.
        /// </summary>
        public override ExpressionCollection<Site> ExpressionCollection
        {
            get
            {
                return new ExpressionCollection<Site>
                {
                    { "Id", site => site.Id },
                    { "Title", site => site.Title },
                };
            }
        }

        /// <summary>
        /// Create a site DTO from a entity.
        /// </summary>
        /// <returns>The site DTO.</returns>
        public override Expression<Func<Site, SiteDto>> EntityToDto()
        {
            return entity => new SiteDto { Id = entity.Id, Title = entity.Title };
        }

        /// <summary>
        /// Create a site DTO from a entity.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The site DTO.
        /// </returns>
        public Expression<Func<Site, SiteDto>> EntityToDto(int userId)
        {
            return entity => new SiteDto { Id = entity.Id, Title = entity.Title, IsDefault = entity.Members.Any(member => member.UserId == userId && member.IsDefault) };
        }

        /// <summary>
        /// Create a site entity from a DTO.
        /// </summary>
        /// <param name="dto">The site DTO.</param>
        /// <param name="entity">The entity to update.</param>
        public override void DtoToEntity(SiteDto dto, Site entity)
        {
            if (entity == null)
            {
                entity = new Site();
            }

            entity.Id = dto.Id;
            entity.Title = dto.Title;
            entity.TeamTypeId = (int)TeamTypeId.Site;
        }
    }
}