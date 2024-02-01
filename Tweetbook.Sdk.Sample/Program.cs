using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetbook.Contracts.V1.Requests;

namespace Tweetbook.Sdk.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cachedToken = string.Empty;

            var identityApi = RestService.For<IIdentityApi>("https://localhost:5001");
            var tweetbookApi = RestService.For<ITweetbookApi>("https://localhost:5001", new RefitSettings
            {
                AuthorizationHeaderValueGetter = (rq, ct) => Task.FromResult(cachedToken)
            });

            var registerResponse = await identityApi.RegisterAsync(new UserRegistrationRequest
            {
                Email = "sdkaccount@example.com",
                Password = "Pass12345!"
            });

            var loginResponse = await identityApi.LoginAsync(new UserLoginRequest
            {
                Email = "sdkaccount@example.com",
                Password = "Pass12345!"
            });

            cachedToken = loginResponse.Content.Token;

            var allPosts = await tweetbookApi.GetAllPostsAsync();

            var createdPost = await tweetbookApi.CreatePostAsync(new CreatePostRequest
            {
                Name = "Created By SDK example",
                Tags = new []
                {
                    "sdk"
                }
            });

            var retrievedPost = await tweetbookApi.GetPostAsync(createdPost.Content.Id);

            var updatedPost = await tweetbookApi.UpdatePostAsync(createdPost.Content.Id, new UpdatePostRequest
            {
                Name = "Updated by SDK example"
            });

            var deletedPost = await tweetbookApi.DeletePostAsync(createdPost.Content.Id);


            var allTags = await tweetbookApi.GetAllTagsAsync();

            var createdTag = await tweetbookApi.CreateTagAsync(new CreateTagRequest
            {
                TagName = "Tag created by SDK example"
            });

            var retrievedTag = await tweetbookApi.GetTagAsync(createdTag.Content.Name);

            var deletedTag = await tweetbookApi.DeleteTagAsync(createdTag.Content.Name);
        }
    }
}
