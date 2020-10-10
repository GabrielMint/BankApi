using AutoFixture;
using AutoFixture.Xunit2;
using System.Linq;
using AutoFixture.AutoNSubstitute;

namespace BankApi.UnitTests.AutoFixtureExtensions
{
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(FixtureFactory)
        {
        }

        public static IFixture FixtureFactory()
        {
            var fixture = new Fixture();

            fixture.Customize(new AutoNSubstituteCustomization());
            
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));

            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            return fixture;
        }
    }
}