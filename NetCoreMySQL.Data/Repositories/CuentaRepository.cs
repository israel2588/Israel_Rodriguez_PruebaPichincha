
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using NetCoreMySql.Model;

namespace NetCoreMySQL.Data.Repositories
{
    public class CuentaRepository: ICuentaRepository
    {

        private MySQLConfiguration _connectionString;

        public CuentaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }


        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    
        public async Task<bool> UpdateAccount(Cuenta cuenta)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE cuenta
                        SET numero_cuenta=@numero_cuenta, tipo_cuenta=@tipo_cuenta , saldo_Inicial=@saldo_Inicial, estado=@estado)
                        WHERE id=id";


            var result = await db.ExecuteAsync(sql, new { cuenta.numero_cuenta, cuenta.tipo_cuenta, cuenta.saldo_Inicial, cuenta.estado});

            return result > 0;
        }

        public async Task<bool> InsertAccount(Cuenta cuenta)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO cuenta (numero_cuenta=@numero_cuenta, tipo_cuenta=@tipo_cuenta , saldo_Inicial=@saldo_Inicial, estado='ACTIVO')
                        VALUES (@numero_cuenta, @tipo_cuenta, @saldo_Inicial,estado)";

            var result = await db.ExecuteAsync(sql, new { cuenta.numero_cuenta, cuenta.tipo_cuenta, cuenta.saldo_Inicial, cuenta.estado });

            return result > 0;
        }

       
        public async Task<bool> DeleteAccount(Cuenta cuenta)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE cuenta
                        SET  estado=@estado)
                        WHERE id=@id";


            var result = await db.ExecuteAsync(sql, new { cuenta.estado });

            return result > 0;
        }


        public Task<IEnumerable<Cuenta>> GetAllAccount()
        {
            throw new NotImplementedException();
        }

    }
}
