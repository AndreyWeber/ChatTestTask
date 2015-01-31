using System.Data.Entity.Migrations;

namespace ChatTestTask.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<ChatTestTaskDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
