using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using NetCoreMySql.Model;

namespace NetCoreMySQL.Data.Repositories
{
    public class PersonaRepository: IPersonaRepository
    {
        private MySQLConfiguration _connectionString;
       
        public PersonaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Persona>> GetAllPerson()
        {
            var db = dbConnection();

            var sql = @"SELECT id,nombre, genero, edad, identificacion, direccion, telefono FROM persona";

            return await db.QueryAsync<Persona>(sql, new { });
        }


        public async Task<bool> InsertPerson(Persona persona)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO persona (nombre, genero, edad, identificacion, direccion, telefono)
                        VALUES (@nombre, @genero, @edad, @identificacion, @direccion, @telefono)";

            var result = await db.ExecuteAsync(sql, new { persona.nombre, persona.genero, persona.edad, persona.identificacion, persona.direccion, persona.telefono });

            return result > 0;
        }

        public async Task<bool> UpdatePerson(Persona persona)
        {
       
            var db = dbConnection();

            var sql = @"
                        UPDATE persona
                        SET nombre=@nombre, genero=@genero, edad=@edad, identificacion=@identificacion,
                        direccion=@direccion, telefono=@telefono)
                        WHERE id=@id";
                 

            var result = await db.ExecuteAsync(sql, new { persona.nombre, persona.genero, persona.edad, persona.identificacion, persona.direccion, persona.telefono });

            return result > 0;
        }

        public Task<bool> DeletePerson(Persona persona)
        {
            throw new NotImplementedException();
        }
    }
    
}
