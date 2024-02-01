using Swashbuckle.AspNetCore.Filters;
using Tweetbook.Contracts.V1.Requests;

namespace Tweetbook.Examples.Requests
{
    public class RefreshTokenRequestExample : IExamplesProvider<RefreshTokenRequest>
    {
        public RefreshTokenRequest GetExamples()
        {
            return new RefreshTokenRequest
            {
                Token = "eNcr-Y+3d_T0keN_m355@g3",
                RefreshToken = "eNcr-Y+3d_reFRe5H_T0keN_m355@g3"
            };
        }
    }
}
