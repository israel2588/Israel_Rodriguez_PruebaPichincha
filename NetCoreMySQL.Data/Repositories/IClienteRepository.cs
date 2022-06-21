using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreMySql.Model;

namespace NetCoreMySQL.Data.Repositories
{
    public interface IClienteRepository
    {

        Task <IEnumerable<Cliente>> GetAllClient();

        Task<bool> InsertClient(Cliente cliente);

        Task<bool> UpdateClient(Cliente cliente);
        Task<bool> DeleteClient(Cliente cliente);
    }
}
