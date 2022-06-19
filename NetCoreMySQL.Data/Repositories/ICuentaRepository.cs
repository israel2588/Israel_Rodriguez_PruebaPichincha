using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreMySql.Model;

namespace NetCoreMySQL.Data.Repositories
{
    public interface ICuentaRepository
    {
        Task<IEnumerable<Cuenta>> GetAllAccount();

        Task<bool> InsertAccount(Cuenta cuenta);

        Task<bool> UpdateAccount(Cuenta cuenta);

        Task<bool> DeleteAccount(Cuenta cuenta);
    }
}
