using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetbook.Contracts.V1;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Contracts.V1.Responses;

namespace Tweetbook.Sdk
{
    [Headers("Authorization: Bearer")]
    public interface ITweetbookApi
    {
        [Get("/" + ApiRoutes.Posts.GetAll)]
        Task<ApiResponse<List<PostResponse>>> GetAllPostsAsync();

        [Get("/" + ApiRoutes.Posts.Get)]
        Task<ApiResponse<PostResponse>> GetPostAsync(Guid postId);

        [Post("/" + ApiRoutes.Posts.Create)]
        Task<ApiResponse<PostResponse>> CreatePostAsync([Body] CreatePostRequest createPostRequest);

        [Put("/" + ApiRoutes.Posts.Update)]
        Task<ApiResponse<PostResponse>> UpdatePostAsync(Guid postId, [Body] UpdatePostRequest updatePostRequest);

        [Delete("/" + ApiRoutes.Posts.Delete)]
        Task<ApiResponse<string>> DeletePostAsync(Guid postId);


        [Get("/" + ApiRoutes.Tags.GetAll)]
        Task<ApiResponse<List<TagResponse>>> GetAllTagsAsync();

        [Get("/" + ApiRoutes.Tags.Get)]
        Task<ApiResponse<TagResponse>> GetTagAsync(string tagName);

        [Post("/" + ApiRoutes.Tags.Create)]
        Task<ApiResponse<TagResponse>> CreateTagAsync([Body] CreateTagRequest createTagRequest);

        [Delete("/" + ApiRoutes.Tags.Delete)]
        Task<ApiResponse<string>> DeleteTagAsync(string tagName);
    }
}
