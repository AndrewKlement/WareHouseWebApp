using Microsoft.EntityFrameworkCore;
using MiniProject_IT_DIV.Models.DBmodels;

namespace MiniProject_IT_DIV.DB
{
    public class Db_Cntx : DbContext
    {
        public Db_Cntx(DbContextOptions options) : base(options){}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PersonCategory> PersonCategories { get; set; }
    }
}
