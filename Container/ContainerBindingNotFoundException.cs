using System;

namespace DeveloperSample.Container
{
    public class ContainerBindingNotFoundException : Exception
    {
        public ContainerBindingNotFoundException(Type bindingType):base($@"Could not find Type:{bindingType.FullName} in container; make sure to call .Bind() first")
        {
        }
    }
}