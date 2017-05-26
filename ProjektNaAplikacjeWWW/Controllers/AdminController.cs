using ProjektNaAplikacjeWWW.DAL;
using ProjektNaAplikacjeWWW.Models;
using ProjektNaAplikacjeWWW.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjektNaAplikacjeWWW.Controllers
{
    public class AdminController : Controller
    {
        AuthorRepository ar = new AuthorRepository();
        BookRepositorycs br = new BookRepositorycs();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ControlPanel()
        {
            //IEnumerable<SelectListItem> sl = ar.GetAuthorList().Select(i => new SelectListItem()
            //{
            //    Text = i.Name,
            //    Value = i.AuthorID.ToString()
            //});


            //SelectList slist = new SelectList(sl);
            //ViewBag.list2 = slist;


            //TU dziala
            //ViewBag.list = ar.GetAuthorList().Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.AuthorID.ToString()

            //});

            ViewBag.list2 = new SelectList(ar.GetAuthorList(), "AuthorID", "Name");

            ControlPanelViewModel vm = new ControlPanelViewModel();
            return View();
        }


        public async Task<ActionResult> AddAuthor(Author a)
        {
            
            await ar.AddAuthor(a);
            return Redirect("ControlPanel");
        }

        public async Task<ActionResult> AddBook(Book b,string _DropDownList)
        {
            Guid selectedAuthor = new Guid(_DropDownList);
            b.BookAuthor = ar.GetAuthor(selectedAuthor);
            await br.AddBook(b);
            return Redirect("ControlPanel");
        }
    }
}