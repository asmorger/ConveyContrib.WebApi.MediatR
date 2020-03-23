using Convey.WebApi;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace ConveyContrib.WebApi.MediatR.Tests
{
    public class MediatrEndpointsBuilderTests
    {
        internal class TestMessageWithNoResponse : IRequest
        {
            
        }

        internal class TestMessageWithResponse : IRequest<bool>
        {
            
        }
        
        private readonly IEndpointsBuilder _endpointsBuilder;
        private readonly MediatrEndpointsBuilder _systemUnderTest;

        public MediatrEndpointsBuilderTests()
        {
            _endpointsBuilder = A.Fake<IEndpointsBuilder>();
            _systemUnderTest = new MediatrEndpointsBuilder(_endpointsBuilder);
        }

        [Fact]
        public void Get_with_no_inputs_should_call_get_on_builder()
        {
            _systemUnderTest.Get("", ctx => ctx.Response.WriteAsync("Hello"));

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Get)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Get_with_one_input_and_no_output_should_call_get_on_builder()
        {
            _systemUnderTest.Get<TestMessageWithNoResponse>("");

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Get)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Get_with_one_input_and_one_output_should_call_get_on_builder()
        {
            _systemUnderTest.Get<TestMessageWithResponse, bool>("");

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Get)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Post_with_no_inputs_should_call_get_on_builder()
        {
            _systemUnderTest.Post("", ctx => ctx.Response.WriteAsync("Hello"));

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Post)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Post_with_one_input_and_no_output_should_call_get_on_builder()
        {
            _systemUnderTest.Post<TestMessageWithNoResponse>("");

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Post)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Post_with_one_input_and_one_output_should_call_get_on_builder()
        {
            _systemUnderTest.Post<TestMessageWithResponse, bool>("");

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Post)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Put_with_no_inputs_should_call_get_on_builder()
        {
            _systemUnderTest.Put("", ctx => ctx.Response.WriteAsync("Hello"));

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Put)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Put_with_one_input_and_no_output_should_call_get_on_builder()
        {
            _systemUnderTest.Put<TestMessageWithNoResponse>("");

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Put)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Put_with_one_input_and_one_output_should_call_get_on_builder()
        {
            _systemUnderTest.Put<TestMessageWithResponse, bool>("");

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Put)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Delete_with_no_inputs_should_call_get_on_builder()
        {
            _systemUnderTest.Delete("", ctx => ctx.Response.WriteAsync("Hello"));

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Delete)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Delete_with_one_input_and_no_output_should_call_get_on_builder()
        {
            _systemUnderTest.Delete<TestMessageWithNoResponse>("");

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Delete)))
                .MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Delete_with_one_input_and_one_output_should_call_get_on_builder()
        {
            _systemUnderTest.Delete<TestMessageWithResponse, bool>("");

            A
                .CallTo(_endpointsBuilder)
                .Where(call => call.MatchesEndpointMethodByName(nameof(IEndpointsBuilder.Delete)))
                .MustHaveHappenedOnceExactly();
        }
    }
}