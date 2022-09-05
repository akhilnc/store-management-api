using StoreManagement.Data.DbContexts;
using StoreManagement.Data.Generics.General;
using StoreManagement.Data.Models;
using StoreManagement.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Repositories.Masters.User
{
    public class UserRepo: RepositoryBase<MstUser>,IUserRepo
    {
        private readonly StoreAppContext _appContext;

        public UserRepo(StoreAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        #region Validations
        public async Task<bool> CheckDuplication(DuplicateValidation input)
        {
            var query =
                $"SELECT * FROM mst_user WHERE  {input.ColumnName} = '{input.Value}' AND {input.IdentifierColumnName} <> '{input.Identifier}' ";
            var result = await _appContext.MstUser.FromSqlRaw(query).ToListAsync();
            return result.Count==0;
        }
        #endregion
    }
}
