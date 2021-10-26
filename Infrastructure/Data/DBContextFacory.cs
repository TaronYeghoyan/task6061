using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    internal class DBContextFacory : IDesignTimeDbContextFactory<MyDBContext>
    {
        public MyDBContext CreateDbContext(string[] args)
        {
            var option = new DbContextOptionsBuilder<MyDBContext>();
            option.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=6061DB;Trusted_Connection=True;");
            return new MyDBContext(option.Options);
        }
    }
}