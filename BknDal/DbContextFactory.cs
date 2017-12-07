using BknDal.Models;

namespace BknDal
{
    public class DbContextFactory
    {
        public static DatabaseEntities OpenContext()
        {
            var context = new DatabaseEntities();

            context.Configuration.AutoDetectChangesEnabled = true;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Configuration.LazyLoadingEnabled = false;

            return context;
        }
    }
}
