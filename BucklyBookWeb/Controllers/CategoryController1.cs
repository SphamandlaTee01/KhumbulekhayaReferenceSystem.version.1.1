using BucklyBookWeb.Data;
using BucklyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BucklyBookWeb.Controllers
{
    public class CategoryController1 : Controller
    {

        private readonly ApplicationDBContext _db;


        public CategoryController1( ApplicationDBContext db)
        {
            _db = db;
        }





        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);    
        }

        //Get action Method
        public IActionResult Create()
        {
            return View();
        }

        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.Surname)
            {
                ModelState.AddModelError("name", " The Name cannot exactly match the Surname.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj); 
        }


        //Edit Get & Post Methos------------------------------------------------------------





        //Get action Method
        //public IActionResult Edit()
        //{
        //    return View();
        //}

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.Surname)
            {
                ModelState.AddModelError("name", " The Name cannot exactly match the Surname.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete Get an Post Methods---------------------------------------------
       


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post 
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        { 

            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
