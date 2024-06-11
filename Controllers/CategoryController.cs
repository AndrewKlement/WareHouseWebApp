using Microsoft.AspNetCore.Mvc;
using MiniProject_IT_DIV.Models.DBmodels;
using MiniProject_IT_DIV.Models;
using MiniProject_IT_DIV.DB;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiniProject_IT_DIV.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly Db_Cntx db_Cntx;
        public CategoryController(Db_Cntx db_Cntx)
        {
            this.db_Cntx = db_Cntx;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await db_Cntx.Persons
                .Include(p => p.PersonCategories)
                .FirstOrDefaultAsync(p => p.Email == userEmail);
            
            List<CategoryModel> categories = new ();

            if (user.PersonCategories != null) {
                foreach (var item in user.PersonCategories)
                {
                    var category = await db_Cntx.Categories.FirstOrDefaultAsync(c => c.Category_Id == item.Category_Id);
                    categories.Add(new CategoryModel() {Category_Id = category.Category_Id, Category_Name = category.Category_Name});
                }
            }                    

            CategoryViewModel categoryViewModel = new () {
                AddCategory = new CategoryModel(),
                ListCategories = new Categories() { Category = categories}
            };

            Console.WriteLine(categories);
            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddModal(CategoryModel categoryView)
        {
            if (categoryView != null)
            {
                var userEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Person user = await db_Cntx.Persons.FirstOrDefaultAsync(p => p.Email == userEmail);

                var existingCategory = await db_Cntx.Categories.FirstOrDefaultAsync(p => p.Category_Name == categoryView.Category_Name);

                if (existingCategory == null)
                {
                    Category category = new ()
                    {
                        Category_Name = categoryView.Category_Name
                    };

                    await db_Cntx.Categories.AddAsync(category);
                    await db_Cntx.SaveChangesAsync();

                    Category addedCategory = await db_Cntx.Categories.FirstOrDefaultAsync(p => p.Category_Name == categoryView.Category_Name);

                    PersonCategory personCategory = new ()
                    {
                        User_Id = user.User_Id,
                        Category_Id = addedCategory.Category_Id,
                    };

                    await db_Cntx.PersonCategories.AddAsync(personCategory);
                    await db_Cntx.SaveChangesAsync();


                }
                else
                {
                    PersonCategory personCategory = new () {
                        User_Id = user.User_Id,
                        Category_Id = existingCategory.Category_Id,
                    };

                    await db_Cntx.PersonCategories.AddAsync(personCategory);
                    await db_Cntx.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index", "Category");
        }

        [HttpPut]
        public async Task<IActionResult> EditModal([FromBody] CategoryModel categoryView)
        {
            var userEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Category existingCategory = await db_Cntx.Categories.FindAsync(categoryView.Category_Id);

            if (existingCategory != null)
            {
                existingCategory.Category_Name = categoryView.Category_Name;

                await db_Cntx.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Category");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteModal([FromBody] CategoryModel categoryView)
        {
            PersonCategory existingCategory = await db_Cntx.PersonCategories.FirstOrDefaultAsync(p => p.Category_Id == categoryView.Category_Id);
            if (existingCategory != null)
            {
                db_Cntx.PersonCategories.Remove(existingCategory);
                await db_Cntx.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Category");
        }
    }
}
