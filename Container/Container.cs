using System;
using System.Collections;

namespace DeveloperSample.Container
{
    public class Container 
    {
        private Hashtable containerCollection = new Hashtable();
        public void Bind(Type interfaceType, Type implementationType)
        {
            containerCollection.Add(interfaceType, implementationType);
        }
        public T Get<T>()
        {
            Type implementationType = (Type)containerCollection[typeof(T)];
            return (T)Activator.CreateInstance(implementationType);
        }
    }
}