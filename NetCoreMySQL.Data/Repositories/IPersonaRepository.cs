using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreMySql.Model;

namespace NetCoreMySQL.Data.Repositories
{
    public interface IPersonaRepository
    {

        Task <IEnumerable<Persona>> GetAllPerson();

        Task<bool> InsertPerson(Persona persona);

        Task<bool> UpdatePerson(Persona persona);

        Task<bool> DeletePerson(Persona persona);
    }
}
