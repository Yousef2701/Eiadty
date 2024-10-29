using Medical.Core.Dtos;
using Medical.Core.Models;

namespace Medical.Core.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        public Task<string> CreateNewPost(AddPostDto dto);

        public Task<IEnumerable<GetPostDto>> GetAllDoctorPosts(string phone);

        public Task<IEnumerable<GetPostDto>> GetAllPosts();

        public Task<string> DeletePost(string postId);

        public Task<string> PostLike(string postId,string phone);

        public Task<bool> IfUserAddLike(string postId, string phone);

        public Task<IEnumerable<GetCommentsDto>> GetPostComments(string postId);

        public Task<string> DeletePostComment(string postId,int commentNumbre);
    }
}
