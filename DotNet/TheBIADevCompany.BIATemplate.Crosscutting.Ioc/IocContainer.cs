// <copyright file="IocContainer.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Crosscutting.Ioc
{
    using BIA.Net.Core.Ioc;
    using BIA.Net.Core.Ioc.Param;
    using Microsoft.Extensions.DependencyInjection;
    using TheBIADevCompany.BIATemplate.Crosscutting.Ioc.Bia.Param;

    /// <summary>
    /// The IoC Container.
    /// </summary>
    public static partial class IocContainer
    {
        /// <summary>
        /// Configures the container.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public static void ConfigureContainer(ParamIocContainer param)
        {
            BiaConfigureContainer(param);
        }

        private static ParamAutoRegister GetGlobalParamAutoRegister(ParamIocContainer param)
        {
            return new ParamAutoRegister()
            {
                Collection = param.Collection,
                ExcludedServiceNames = null,
                IncludedServiceNames = null,
            };
        }

        private static void ConfigureApplicationContainer(ParamIocContainer param)
        {
            BiaConfigureApplicationContainer(param);
            BiaConfigureApplicationContainerAutoRegister(GetGlobalParamAutoRegister(param));
        }

        private static void ConfigureDomainContainer(ParamIocContainer param)
        {
            BiaIocContainer.ConfigureDomainContainer(param);
            BiaConfigureDomainContainer(param);
            BiaConfigureDomainContainerAutoRegister(GetGlobalParamAutoRegister(param));
        }

        private static void ConfigureCommonContainer(ParamIocContainer param)
        {
            BiaIocContainer.ConfigureCommonContainer(param);
        }

#if BIA_USE_DATABASE
        private static void ConfigureInfrastructureDataContainer(ParamIocContainer param)
        {
            BiaIocContainer.ConfigureInfrastructureDataContainer(param);
            BiaConfigureInfrastructureDataContainer(param);
            BiaConfigureInfrastructureDataContainerAutoRegister(GetGlobalParamAutoRegister(param));
            BiaConfigureInfrastructureDataContainerDbContext(param);
        }

#endif

        private static void ConfigureInfrastructureServiceContainer(ParamIocContainer param)
        {
            BiaIocContainer.ConfigureInfrastructureServiceContainer(param);
            BiaConfigureInfrastructureServiceContainer(param);
#if BIA_FRONT_FEATURE
#endif
        }
    }
}
