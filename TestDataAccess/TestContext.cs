using System.Data.Entity;

namespace TestDataAccess
{
    public class TestContext : DbContext
    {
        public TestContext()
            :base("DBConnection")
        {

        }

        public DbSet<SentenceEntity> Sentences { get; set; }
    }
}
