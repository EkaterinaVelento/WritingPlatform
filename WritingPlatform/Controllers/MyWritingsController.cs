using Models;
using Models.Writings;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WritingPlatform.Controllers
{
    public class MyWritingsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWritingService _writingService;
        private readonly ICommentService _commentService;
        private readonly IRatingService _ratingService;

        public MyWritingsController(
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
            int userId = _userService.GetAll()
                .Where(item => item.Login == User.Identity.Name)
                .FirstOrDefault().Id;
            List<WritingModel> writings = _writingService.GetByUserId(userId).ToList();
            IEnumerable<WritingModel> writingsPerPages = writings
                .Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = writings.Count
            };
            WritingsViewModel wvm = new WritingsViewModel 
            { 
                PageInfo = pageInfo, 
                Writings = writingsPerPages 
            };
            return View(wvm);
        }

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
            foreach (var item in ratings)
            {
                rating += item.Content;
            }
            rating /= ratings.Count();

            var comments = _commentService.GetAllByWritingId(id).ToList();
            var result = new WritingModelWithComments(writing, rating, comments);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var writing = _writingService.GetAll()
                .FirstOrDefault(item => item.Id == id);
            if (writing == null)
            {
                return HttpNotFound();
            }
            return View(writing);

        }
    }
}