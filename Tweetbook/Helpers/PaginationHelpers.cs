using System;
using System.Collections.Generic;
using System.Linq;
using Tweetbook.Contracts.V1.Requests.Queries;
using Tweetbook.Contracts.V1.Responses;
using Tweetbook.Domain;
using Tweetbook.Services;

namespace Tweetbook.Helpers
{
    public class PaginationHelpers
    {
        public static PagedResponse<T> CreatePaginatedResponse<T>(IUriService uriService, PaginationFilter pagination, List<T> reponses)
        {
            var nextPage = uriService.GetAllPostsUri(new PaginationQuery(pagination.PageNumber + 1, pagination.PageSize)).ToString();

            var previousPage = pagination.PageNumber - 1 >= 1 ?
                uriService.GetAllPostsUri(new PaginationQuery(pagination.PageNumber - 1, pagination.PageSize)).ToString()
                : null;

            return new PagedResponse<T>
            {
                Data = reponses,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                NextPage = reponses.Any() ? nextPage : null,
                PreviousPage = pagination.PageNumber > 1 ? previousPage : null
            };
        }
    }
}
