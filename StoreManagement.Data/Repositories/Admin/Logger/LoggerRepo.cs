using StoreManagement.Data.DbContexts;
using StoreManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Data.Repositories.Admin.Logger
{
    public class AppLoggerRepo : IAppLoggerRepo
    {
        private readonly StoreAppContext _appContext;

        public AppLoggerRepo(StoreAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<AdminAppLogs> SaveLog(AdminAppLogs input)
        {
            DetachEntitys();
            await _appContext.AdminAppLogs.AddAsync(input);
            await _appContext.SaveChangesAsync();
            DetachEntitys();
            return input;
        }

        private void DetachEntitys()
        {
            foreach (var entry in _appContext.ChangeTracker.Entries().ToArray()) entry.State = EntityState.Detached;
        }
    }
}