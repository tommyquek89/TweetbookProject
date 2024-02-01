using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using Tweetbook.Contracts.V1.Requests;

namespace Tweetbook.Examples.Requests
{
    public class CreatePostRequestExample : IExamplesProvider<CreatePostRequest>
    {
        public CreatePostRequest GetExamples()
        {
            return new CreatePostRequest
            {
                Name = "new post",
                Tags = new List<string>
                {
                    "tag name"
                }
            };
        }
    }
}
