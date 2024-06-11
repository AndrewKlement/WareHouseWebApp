using Microsoft.AspNetCore.Mvc;
using MiniProject_IT_DIV.Models;

namespace MiniProject_IT_DIV.Views.Shared.Components.DeleteCategoryComponent
{
    public class DeleteCategoryComponent : ViewComponent
    {
        public IViewComponentResult Invoke(CategoryModel category)
        {
            return View("DeleteCategoryComponent", category);
        }
    }
}
