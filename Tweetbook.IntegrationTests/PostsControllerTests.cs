using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tweetbook.Contracts.V1;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Contracts.V1.Responses;
using Tweetbook.Domain;
using Xunit;

namespace Tweetbook.IntegrationTests
{
    public class PostsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyReponse()
        {
            // Arrange
            await AuthenticateAsync();

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Posts.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            (await response.Content.ReadAsAsync<PagedResponse<PostResponse>>()).Data.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_ReturnsPost_WhenPostExistInTheDatabase()
        {
            // Arrange
            await AuthenticateAsync();
            var createdPost = await CreatePostAsync(new CreatePostRequest 
            { 
                Name = "Test post",
                Tags = new [] { "testtag" }
            });

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Posts.Get.Replace("{postId}", createdPost.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var returnedPost = await response.Content.ReadAsAsync<Response<PostResponse>>();
            returnedPost.Data.Id.Should().Be(createdPost.Id);
            returnedPost.Data.Name.Should().Be("Test post");
            returnedPost.Data.Tags.Single().Name.Should().Be("testtag");
        }
    }
}
