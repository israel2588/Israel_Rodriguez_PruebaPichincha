using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using NetCoreMySql.Model;

namespace NetCoreMySQL.Data.Repositories
{
    public class ClienteRepository: IClienteRepository
    {
        private MySQLConfiguration _connectionString;

        public ClienteRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Cliente>> GetAllClient()
        {
            var db = dbConnection();

            var sql = @"SELECT clienteid, contrasena, estado FROM cliente";

            return await db.QueryAsync<Cliente>(sql, new { });
        }

        public async Task<bool> UpdateClient(Cliente cliente)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE cliente
                        SET contrasena=@contrasena, estado=@estado)
                        WHERE id=id";


            var result = await db.ExecuteAsync(sql, new {cliente.contrasena, cliente.estado });

            return result > 0;
        }


        public async Task<bool> InsertClient(Cliente cliente)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO cliente (contrasena, estado, idPersona)
                        VALUES (@contrasena, @estado, @idPersona)";

            var result = await db.ExecuteAsync(sql, new { cliente.contrasena, cliente.estado, cliente.idPersona });

            return result > 0;
        }



        public async Task<bool> DeleteClient(Cliente cliente)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE cliente
                        SET estado=@estado)
                        WHERE id=@id";
            var result = await db.ExecuteAsync(sql, new { cliente.estado });

            return result > 0;
        }



    }
}
