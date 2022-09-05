using System;
using System.Threading.Tasks;
using StoreManagement.Data.Generics.General;

namespace StoreManagement.Infrastructure.Common.Logger
{
    public interface IAppLogger
    {
        Task<AppErrorResponse> Error(string message, Exception ex);
        Task<AppErrorResponse> Warning(string message);
        Task<AppErrorResponse> Info(string message);
    }
}