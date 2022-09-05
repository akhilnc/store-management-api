using StoreManagement.Data.DbContexts;
using StoreManagement.Data.Models;
using StoreManagement.Data.Repositories.Base;

namespace StoreManagement.Data.Repositories.Admin.Token
{
    public class TokenRepo : RepositoryBase<AdminUserRefreshToken>, ITokenRepo
    {
        private readonly StoreAppContext _appContext;
        public TokenRepo(StoreAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }
    }
}
