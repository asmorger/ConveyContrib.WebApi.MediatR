using FakeItEasy.Core;

namespace ConveyContrib.WebApi.MediatR.Tests
{
    public static class FakeItEasyExtensions
    {
        public static bool MatchesEndpointMethodByName(this IFakeObjectCall fake, string name) =>
            fake.Method.Name == name;
    }
}