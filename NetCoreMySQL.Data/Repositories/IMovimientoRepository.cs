using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreMySql.Model;

namespace NetCoreMySQL.Data.Repositories
{
    public interface IMovimientoRepository
    {
        Task<IEnumerable<Movimiento>> GetAllMovimiento();

        Task<bool> InsertAccount(Movimiento movimiento);

        Task<bool> UpdateAccount(Movimiento movimiento);

        Task<bool> DeleteAccount(Movimiento movimiento);
    }
}
