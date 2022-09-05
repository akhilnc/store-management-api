using StoreManagement.Data.Models;
using StoreManagement.Data.Repositories.Base;

namespace StoreManagement.Data.Repositories.Admin.Token
{
    public interface ITokenRepo : IRepositoryBase<AdminUserRefreshToken>
    {
    }
}
