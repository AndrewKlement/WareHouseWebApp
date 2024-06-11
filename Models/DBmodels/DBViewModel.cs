using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject_IT_DIV.Models.DBmodels
{
    public class Person
    {
        [Key]
        public int User_Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public List<PersonCategory> PersonCategories { get; set; }
    }

    public class Category
    {
        [Key]
        public int Category_Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Category_Name { get; set; }

        public List<PersonCategory> PersonCategories { get; set; }
    }

    public class PersonCategory
    {
        [Key]
        public int PersonCategory_Id { get; set; }

        [ForeignKey("Person")]
        public int User_Id { get; set; }

        [ForeignKey("Category")]
        public int Category_Id { get; set; }

        public Person Person { get; set; }

        public Category Category { get; set; }
    }
}
