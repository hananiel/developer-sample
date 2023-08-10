using DeveloperSample.ClassRefactoring;
using System;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }

        [Fact]
        public void MakeSureImplementable()
        {
            var container = new Container();
            try
            {
                container.Bind(typeof(IContainerTestInterface), typeof(Swallow));
                Assert.Fail("Bind did not pass test");
            }
            catch (InvalidCastException e)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                throw;
            }

        }

        [Fact]
        public void MakeSureBound()
        {
            var container = new Container();
            try
            {
                var testInstance = container.Get<IContainerTestInterface>();
                Assert.Fail("Get did not pass test");

            }
            catch (ContainerBindingNotFoundException e)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                throw;
            }

        }
    }
}