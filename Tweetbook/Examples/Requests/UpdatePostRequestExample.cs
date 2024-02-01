using Swashbuckle.AspNetCore.Filters;
using Tweetbook.Contracts.V1.Requests;

namespace Tweetbook.Examples.Requests
{
    public class UpdatePostRequestExample : IExamplesProvider<UpdatePostRequest>
    {
        public UpdatePostRequest GetExamples()
        {
            return new UpdatePostRequest
            {
                Name = "NewPostName",
            };
        }
    }
}