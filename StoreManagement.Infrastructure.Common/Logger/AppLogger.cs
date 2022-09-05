using System;
using System.Threading.Tasks;
using StoreManagement.Data.Generics.Enum;
using StoreManagement.Data.Generics.General;
using StoreManagement.Data.Models;
using StoreManagement.Data.Repositories.Admin.Logger;
using StoreManagement.Infrastructure.Common.Utlilities.TokenUserClaims;

namespace StoreManagement.Infrastructure.Common.Logger
{
    public class AppLogger : IAppLogger
    {
        private readonly IAppLoggerRepo _repo;
        private readonly UserBase _user;

        public AppLogger(ITokenUserClaims claims, IAppLoggerRepo repo)
        {
            _user = claims.GetClaims();
            _repo = repo;
        }

        public async Task<AppErrorResponse> Error(string message, Exception ex)
        {
            var logInput = new AdminAppLogs
            {
                Message = message,
                Exception = ex.ToString(),
                UserUId = _user.UserGuid,
                LogLevel = nameof(AppLogLevel.Error)
            };
            var logSave = await _repo.SaveLog(logInput);
            return new AppErrorResponse
            {
                CustomMessage = message,
                Identifier = logSave.UId,
                Level = logSave.LogLevel
            };
        }

        public async Task<AppErrorResponse> Warning(string message)
        {
            var logInput = new AdminAppLogs
            {
                Message = message,
                Exception = "",
                UserUId = _user.UserGuid,
                LogLevel = nameof(AppLogLevel.Warn)
            };
            var logSave = await _repo.SaveLog(logInput);
            return new AppErrorResponse
            {
                CustomMessage = message,
                Identifier = logSave.UId,
                Level = logSave.LogLevel
            };
        }

        public async Task<AppErrorResponse> Info(string message)
        {
            var logInput = new AdminAppLogs
            {
                Message = message,
                Exception = "",
                UserUId = _user.UserGuid,
                LogLevel = nameof(AppLogLevel.Info)
            };
            var logSave = await _repo.SaveLog(logInput);
            return new AppErrorResponse
            {
                CustomMessage = message,
                Identifier = logSave.UId,
                Level = logSave.LogLevel
            };
        }
    }
}