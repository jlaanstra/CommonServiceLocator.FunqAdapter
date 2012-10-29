using Funq;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonServiceLocator.FunqAdapter
{
    public class FunqServiceLocator : ServiceLocatorImplBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Container container;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunqServiceLocator" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public FunqServiceLocator(Container container)
        {
            this.container = container;
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of
        /// resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>
        /// Sequence of service instance objects.
        /// </returns>
        /// <exception cref="System.NotSupportedException"></exception>
        protected override System.Collections.Generic.IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of resolving
        /// the requested service instance.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>
        /// The requested service instance.
        /// </returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (key == null)
            {
                return typeof(Container).GetMethod("Resolve").MakeGenericMethod(serviceType).Invoke(container, null);
            }
            else
            {
				return typeof(Container).GetMethod("Resolve").MakeGenericMethod(serviceType).Invoke(container, new[] { key });
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public override TService GetInstance<TService>()
        {
            return container.Resolve<TService>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public override TService GetInstance<TService>(string key)
        {
            return container.ResolveNamed<TService>(key);
        }
    }
}
