﻿using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using VirtualTemplates.Core.Impl;
using VirtualTemplates.Core.Interfaces;
using VirtualTemplates.UI.Impl;
using VirtualTemplates.UI.Interfaces;

namespace VirtualTemplates.UI.Init
{
    [InitializableModule]
    [ModuleDependency(typeof(VirtualTemplates.Core.Init.RegisterImplementations))]
    public class RegisterImplementations : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.StructureMap().Configure(x => { x.For<IUiTemplateLister>().Use<UiTemplateLister>(); });
        }

        public void Initialize(InitializationEngine context) { }
        public void Uninitialize(InitializationEngine context) { }
        public void Preload(string[] parameters) 
        {
        }
    }
}