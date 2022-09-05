using StoreManagement.Data.Generics.General;
using StoreManagement.Data.Models;
using StoreManagement.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Repositories.Masters.User
{
    public interface IUserRepo : IRepositoryBase<MstUser>
    {
        Task<bool> CheckDuplication(DuplicateValidation input);
    }
}
