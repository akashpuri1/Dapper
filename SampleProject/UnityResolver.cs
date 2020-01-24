﻿using System;
using System.Collections.Generic;
using Unity;

namespace SampleProject
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        //public idependencyscope beginscope()
        //{
        //    var child = container.createchildcontainer();
        //    return new unityresolver(child);
        //}

        public void Dispose()
        {
            container.Dispose();
        }
    }
}