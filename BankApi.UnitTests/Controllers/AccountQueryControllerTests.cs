using AutoFixture.Idioms;
using Xunit;
using BankApi.Controllers;
using BankApi.UnitTests.AutoFixtureExtensions;

namespace BankApi.UnitTests.Controllers
{
    public class AccountQueryControllerTests 
    {
        [Theory, AutoNSubstituteData]
        public void Sut_Should_Guard_Its_Clauses(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AccountQueryController).GetConstructors());
        }
    }
}