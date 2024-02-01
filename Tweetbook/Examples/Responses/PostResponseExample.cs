using Swashbuckle.AspNetCore.Filters;
using System;
using Tweetbook.Contracts.V1.Responses;

namespace Tweetbook.Examples.Responses
{
    public class PostResponseExample : IExamplesProvider<PostResponse>
    {
        public PostResponse GetExamples()
        {
            return new PostResponse
            {
                Id = Guid.NewGuid(),
                Name = "new post",
                UserId = "user Id",
                Tags = new[]
                {
                    new TagResponse
                    {
                        Name = "tag name"
                    }
                }
            };
        }
    }
}
