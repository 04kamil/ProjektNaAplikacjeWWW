using ProjektNaAplikacjeWWW.DAL;
using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjektNaAplikacjeWWW.Controllers
{
    public class DatabaseController : Controller
    {



        [HttpGet]
        public ActionResult Authors()
        {
            return View(AuthorRepository.ReadAll());
        }


        public ActionResult AuthorCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AuthorCreate([Bind(Include = "Name,DateOfBirth,DateOfDeath,Descryption")] Author author)
        {
            if(ModelState.IsValid)
            {
                await AuthorRepository.Create(author);
                return Redirect ("AuthorCreate");
            }
            return Redirect("AuthorCreate");
        }

        
        public ActionResult AuthorEdit(Guid id)
        {

            Author a = AuthorRepository.Read(id);
            if(a==null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AuthorEdit([Bind(Include = "AuthorID,Name,DateOfBirth,DateOfDeath,Descryption")] Author author)
        {
            if(ModelState.IsValid)
            {
                await AuthorRepository.Update(author);
                return View("Authors", AuthorRepository.ReadAll());
            }


            return View("Authors");
        }

        
        public async Task<ActionResult> AuthorDelete (Guid id)
        {
            await AuthorRepository.Delete(id);
            return View("Authors", AuthorRepository.ReadAll());
        }

        
       //Books

        
        public ActionResult Books()
        {
            var lst = BookRepositorycs.ReadAll();
            return View(lst);
        }

        public ActionResult BookCreate()
        {
            ViewBag.list2 = new SelectList(AuthorRepository.ReadAll(), "AuthorID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BookCreate([Bind(Include = "Descryption,ISBN,ImgURL,Lang,Pages,Title")] Book book,Guid _DropDownList)
        {
            if (ModelState.IsValid)
            {
                book.BookAuthor = (from p in AuthorRepository.ReadAll() where p.AuthorID == _DropDownList select p).SingleOrDefault();
                await BookRepositorycs.Create(book);
                return Redirect("BookCreate");
            }
            return Redirect("BookCreate");
        }

        public ActionResult BookEdit(Guid id)
        {

            Author a = AuthorRepository.Read(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BookEdit([Bind(Include = "BookID,Name,DateOfBirth,DateOfDeath,Descryption")] Book book)
        {
            if (ModelState.IsValid)
            {
                await BookRepositorycs.Update(book);
                return View("Authors", AuthorRepository.ReadAll());
            }


            return View("Authors");
        }

        public async Task<ActionResult> DeleteBook(Guid id)
        {
            await BookRepositorycs.Delete(id);
            return View("books", BookRepositorycs.ReadAll());
        }

    }
}