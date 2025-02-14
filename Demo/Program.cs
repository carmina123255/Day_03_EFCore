using Demo.Data;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using  CompanyDbContext dbContext = new CompanyDbContext();
          CompanDbContextSeed.seed(dbContext);  
        }
    }
}
