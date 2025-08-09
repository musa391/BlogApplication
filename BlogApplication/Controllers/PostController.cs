using BlogApplication.Context;
using Microsoft.AspNetCore.Mvc;
using BlogApplication.Models;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authorization;

namespace BlogApplication.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDbContext _context;

        public PostController(BlogDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //veritabanındaki tüm kayıtları listeler.
            var posts = _context.Posts.ToList();
            return View(posts);
        }
        
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
           
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken] //Siber saldırılara karşı korur
        public IActionResult Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Post post)
        {
            if(id != post.Id)
            {
                return NotFound();
            }
            _context.Update(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            //id parametresine göre veritabanından bir kayıt getirir.
            //Eğer kayıt bulunursa Details.cshtml kullanıcıya sayfayı gösterir.
            var post =_context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var post=_context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
