using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Medical.EF.Data;
using Medical.EF.Models;
using Medical.EF.Repositories;


namespace Medical.Core.Repositories
{
    public class PostRepository : BaseRepository<Post> , IPostRepository
    {

        private readonly IImageRepository _imageRepository;

        public PostRepository(ApplicationDbContext context, IImageRepository imageRepository) : base(context)
        {
            _context = context;
            _imageRepository = imageRepository;
        }

        public async Task<string> CreateNewPost(AddPostDto dto)
        {
            int check = _context.Posts.Where(m => m.DoctorPhone == dto.DoctorPhone).Count();
            int count;
            if (check == 0)
            {
                count = 1;
            }
            else
            {
                string[] posts = _context.Posts.Where(m => m.DoctorPhone == dto.DoctorPhone).OrderByDescending(m => m.PostId).Select(m => m.PostId).ToArray();
                string c = posts[0].Substring(12);
                count = Convert.ToInt32(c) + 1;
            }
            

            string type;

            if (dto.image != null & dto.vedio != null)
                type = "ImageAndVedio";
            else if (dto.image == null & dto.vedio != null)
                type = "Vedio";
            else if (dto.image != null & dto.vedio == null)
                type = "Image";
            else
                type = "Text";


            var post = new Post
            {
                PostId = dto.DoctorPhone + "_" + count,
                Text = dto.Text,
                PostType = type,
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Time = DateTime.Now.ToString("hh:mm"),
                Am_Pm = DateTime.Now.ToString("tt"),
                DoctorPhone = dto.DoctorPhone
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            if(post.PostType == "Image")
            {
                var imageUrl =await _imageRepository.AddImageAsync(dto.image, post.PostId, "PostImages");

                var image = new PostImage
                {
                    PostId = post.PostId,
                    Image_Url = imageUrl
                };
                _context.PostImages.Add(image);
                _context.SaveChanges();
            }
            else if (post.PostType == "Vedio")
            {
                var vedioUrl = await _imageRepository.AddVedioAsync(dto.vedio, post.PostId);

                var vedio = new PostVedio
                {
                    PostId = post.PostId,
                    Vedio_Url = vedioUrl
                };
                _context.PostVedios.Add(vedio);
                _context.SaveChanges();
            }
            else if (post.PostType == "ImageAndVedio")
            {
                var vedioUrl = await _imageRepository.AddVedioAsync(dto.vedio, post.PostId);

                var vedio = new PostVedio
                {
                    PostId = post.PostId,
                    Vedio_Url = vedioUrl
                };
                _context.PostVedios.Add(vedio);

                var imageUrl = await _imageRepository.AddImageAsync(dto.image, post.PostId, "PostImages");

                var image = new PostImage
                {
                    PostId = post.PostId,
                    Image_Url = imageUrl
                };
                _context.PostImages.Add(image);

                _context.SaveChanges();
            }


            return "Succseed";
        }

        public async Task<IEnumerable<GetPostDto>> GetAllDoctorPosts(string phone)
        {
            var posts = _context.Posts.Where(m => m.DoctorPhone == phone).OrderByDescending(m => m.Date).ThenByDescending(m => m.Am_Pm).ThenByDescending(m => m.Time).ToList();
            List<GetPostDto> AllPosts = new List<GetPostDto>();

            foreach(Post item in posts)
            {
                string name = _context.Doctors.Where(m => m.Phone == phone).Select(m => m.Name).FirstOrDefault();

                int LikeNo = _context.Likes.Where(m => m.PostId == item.PostId).Count();
                int CommentNo = _context.Comments.Where(m => m.PostId == item.PostId).Count();

                var post = new GetPostDto
                {
                    PostId = item.PostId,
                    Text = item.Text,
                    PostType = item.PostType,
                    Date = item.Date,
                    Time = item.Time,
                    Am_Pm = item.Am_Pm,
                    DoctorPhone = item.DoctorPhone,
                    DoctorName = name,
                    LikesNum = LikeNo,
                    CommentsNum = CommentNo
                };

                AllPosts.Add(post);
            }

            return AllPosts;
        }

        public async Task<IEnumerable<GetPostDto>> GetAllPosts()
        {
            var posts = _context.Posts.OrderByDescending(m => m.Date).ThenByDescending(m => m.Am_Pm).ThenByDescending(m => m.Time).ToList();
            List<GetPostDto> AllPosts = new List<GetPostDto>();

            foreach (Post item in posts)
            {
                string name = _context.Doctors.Where(m => m.Phone == item.DoctorPhone).Select(m => m.Name).FirstOrDefault();

                int LikeNo = _context.Likes.Where(m => m.PostId == item.PostId).Count();
                int CommentNo = _context.Comments.Where(m => m.PostId == item.PostId).Count();

                var post = new GetPostDto
                {
                    PostId = item.PostId,
                    Text = item.Text,
                    PostType = item.PostType,
                    Date = item.Date,
                    Time = item.Time,
                    Am_Pm = item.Am_Pm,
                    DoctorPhone = item.DoctorPhone,
                    DoctorName = name,
                    LikesNum = LikeNo,
                    CommentsNum = CommentNo
                };

                AllPosts.Add(post);
            }

            return AllPosts;
        }

        public async Task<string> DeletePost(string postId)
        {
            var post = _context.Posts.Find(postId);

            if (post != null)
            {
                var likes = _context.Likes.Where(m => m.PostId == postId).ToList();
                if(likes != null)
                {
                    foreach (Like item in likes)
                    {
                        _context.Likes.Remove(item);
                        _context.SaveChanges();
                    }
                }               

                var comments = _context.Comments.Where(m => m.PostId == postId).ToList();
                if(comments != null)
                {
                    foreach(Comment item in comments)
                    {
                        _context.Comments.Remove(item);
                        _context.SaveChanges();
                    }
                }

                var image = _context.PostImages.Where(m => m.PostId == postId).FirstOrDefault();
                if (image != null)
                {
                    _context.PostImages.Remove(image);
                    _context.SaveChanges();
                }

                var vedio = _context.PostVedios.Where(m => m.PostId == postId).FirstOrDefault(); 
                if (vedio != null)
                {
                    _context.PostVedios.Remove(vedio);
                    _context.SaveChanges();
                }

                _context.Posts.Remove(post);
                _context.SaveChanges();

                return "Success";
            }

            return "This Post Not Found";
        }

        public async Task<string> PostLike(string postId, string phone)
        {
            var check = _context.Likes.Where(m => m.PostId == postId & m.Patient_Phone == phone).FirstOrDefault();

            if(check is null)
            {
                var like = new Like
                {
                    PostId = postId,
                    Patient_Phone = phone
                };
                _context.Likes.Add(like);
                _context.SaveChanges();

                return "Success";
            }
            else
            {
                _context.Likes.Remove(check); 
                _context.SaveChanges();

                return "Success";
            }
        }

        public async Task<bool> IfUserAddLike(string postId, string phone)
        {
            var check = _context.Likes.Where(m => m.PostId == postId & m.Patient_Phone == phone).FirstOrDefault();

            if(check is null)
                return false;
            else
                return true;
        }

        public async Task<IEnumerable<GetCommentsDto>> GetPostComments(string postId)
        {
            var comments = _context.Comments.Where(m => m.PostId == postId).ToList();
            List<GetCommentsDto> allcomments = new List<GetCommentsDto>();

            foreach (var comment in comments)
            {
                var c = new GetCommentsDto
                {
                    Number = comment.Number,
                    PostId = postId,
                    PatientPhone = comment.PatientPhone,
                    Comment_Text = comment.Comment_Text,
                    PatientName = _context.Patients.Where(m => m.Phone == comment.PatientPhone).Select(m => m.FName).FirstOrDefault() + " " +
                                  _context.Patients.Where(m => m.Phone == comment.PatientPhone).Select(m => m.LName).FirstOrDefault()
                };
                allcomments.Add(c);
            }
            return allcomments;
        }

        public async Task<string> DeletePostComment(string postId, int commentNumbre)
        {
            var check = _context.Comments.Where(m => m.PostId == postId & m.Number == commentNumbre).FirstOrDefault();

            if(check != null)
            {
                _context.Comments.Remove(check);
                _context.SaveChanges();

                return "Success";
            }

            return "Not Found!";
        }

    }
}
