using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private Dictionary<Type,Type> containerBindings= new Dictionary<Type,Type>();
        /// <summary>
        /// Bind to this container an interfacetype and an implementation for it
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="InvalidCastException">Throws invalid cast if implementationType does not inherit from interfaceType </exception>
        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsAssignableFrom(implementationType))
                throw new InvalidCastException($@"Type:{implementationType} does not implement {interfaceType}");
            if(containerBindings.ContainsKey(interfaceType))
                containerBindings[interfaceType] = implementationType;
            containerBindings.Add(interfaceType, implementationType);
        }
        /// <summary>
        /// Returns binding for type
        /// </summary>
        /// <typeparam name="T">Interface Type</typeparam>
        /// <returns>Implementation Type From Bind</returns>
        /// <exception cref="ContainerBindingNotFoundException">Throws error of binding is not found</exception>
        public T Get<T>()
        {
            Type getType = typeof(T);
            if (containerBindings.ContainsKey(getType))
                return (T)Activator.CreateInstance(containerBindings[getType]);
            throw new ContainerBindingNotFoundException(getType);

        }
    }
}