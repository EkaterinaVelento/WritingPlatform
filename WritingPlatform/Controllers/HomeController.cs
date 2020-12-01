using Service.Abstractions;
using System.Web.Mvc;
using System.Linq;
using Models.Writings;
using System.Collections.Generic;
using Models;
using Models.Ratings;
using Models.Comments;


namespace WritingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWritingService _writingService;
        private readonly ICommentService _commentService;
        private readonly IRatingService _ratingService;

        public HomeController(
            IUserService userService, 
            IWritingService writingService, 
            ICommentService commentService, 
            IRatingService ratingService)
        {
            _userService = userService;
            _writingService = writingService;
            _commentService = commentService;
            _ratingService = ratingService;
        }

        [Authorize]
        public ActionResult Index(int page = 1)
        {
            int pageSize = 10;
            List<WritingModel> writings = _writingService.GetAll().ToList();
            IEnumerable<WritingModel> writingsPerPages = writings
                .Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo 
            { 
                PageNumber = page, 
                PageSize = pageSize, 
                TotalItems = writings.Count };
            WritingsViewModel wvm = new WritingsViewModel 
            { 
                PageInfo = pageInfo, 
                Writings = writingsPerPages 
            };
            return View(wvm);
        }

        [HttpGet]
        public ActionResult Id(int id)
        {
            var writing = _writingService.GetAll()
            .FirstOrDefault(item => item.Id == id);
            if (writing == null)
            {
                return HttpNotFound();
            }
            var ratings = _ratingService.GetAllByWritingId(id).ToList();
            double rating = 0;
            if (ratings.Count != 0)
            {
                foreach (var item in ratings)
                {
                    rating += item.Content;
                }
                rating /= ratings.Count();
            }

            var comments = _commentService.GetAllByWritingId(id).ToList();
            var result = new WritingModelWithComments(writing, rating, comments);
            return View(result);
        }

        [HttpGet]
        public ActionResult Read(int id, int page = 1)
        {
            int pageSize = 2800;
            var writing = _writingService.GetAll()
                .FirstOrDefault(item => item.Id == id);
            var content = writing.Content.ToCharArray();
            var contentPerPages = content.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = content.Length
            };
            WritingContentViewModel wcvm = new WritingContentViewModel
            {
                PageInfo = pageInfo,
                Content = contentPerPages
            };
            return View(wcvm);
        }
    }
}