using MiniProject_IT_DIV.Models.DBmodels;

namespace MiniProject_IT_DIV.Models
{
    public class CategoryViewModel
    {
        public CategoryModel AddCategory { get; set; }
        public Categories ListCategories { get; set; }
    }

    public class CategoryModel
    {
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
    }

    public class Categories
    {
        public List<CategoryModel> Category { get; set; }
    }
}
