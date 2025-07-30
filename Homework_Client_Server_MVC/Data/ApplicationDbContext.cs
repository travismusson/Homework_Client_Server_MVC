using Homework_Client_Server_MVC.Models;
using Microsoft.EntityFrameworkCore;
namespace Homework_Client_Server_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }  //DbSet represents a collection of entities, in this case, users
    }
}
