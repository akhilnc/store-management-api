using System.Threading.Tasks;
using StoreManagement.Data.Models;

namespace StoreManagement.Data.Repositories.Admin.Logger
{
    public interface IAppLoggerRepo
    {
        Task<AdminAppLogs> SaveLog(AdminAppLogs input);
    }
}