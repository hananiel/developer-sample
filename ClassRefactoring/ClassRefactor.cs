using System;
using System.Diagnostics.CodeAnalysis;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        // Refactored to interface which will allow easy addition of new types when extending code
        public ISwallow GetSwallow(SwallowType swallowType)
        {
            switch (swallowType)
            {
                case SwallowType.European: return new EuropeanSwallow();
                case SwallowType.African: return new AfricanSwallow();
                default: throw new ArgumentOutOfRangeException(nameof(swallowType));
            }
        }
    }

    public interface ISwallow
    {
        public void ApplyLoad(SwallowLoad swallowLoad);
        public double GetAirspeedVelocity();
    }

    // Moved common functionality to an abstract class
    public abstract class AbstractSwallow
    {
        protected SwallowLoad Load;

        public void ApplyLoad(SwallowLoad swallowLoad)
        {
            this.Load = swallowLoad;
        }
    }

    // Refactored to separate classes since the Type of the swallow lines up with its own type
    public class AfricanSwallow : AbstractSwallow, ISwallow
    {
        public double GetAirspeedVelocity() => 
            // Refactored to a switch expression 
            Load switch
            {
                SwallowLoad.None => 22,
                SwallowLoad.Coconut => (double)18,
                _ => throw new InvalidOperationException($"Unknown type of {Load}"),
            };
        
    }
    public class EuropeanSwallow : AbstractSwallow, ISwallow
    {
        public double GetAirspeedVelocity() =>
            Load switch
            {
                SwallowLoad.None => 20,
                SwallowLoad.Coconut => (double)16,
                _ => throw new InvalidOperationException($"Unknown type of {Load}"),
            };
    }
}