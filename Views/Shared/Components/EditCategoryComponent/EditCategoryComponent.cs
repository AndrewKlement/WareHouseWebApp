using Microsoft.AspNetCore.Mvc;
using MiniProject_IT_DIV.Models;

namespace MiniProject_IT_DIV.Views.Shared.Components.EditCategoryComponent
{
    public class EditCategoryComponent : ViewComponent
    {
        public IViewComponentResult Invoke(CategoryModel category)
        {
            return View("EditCategoryComponent", category);
        }
    }
}
