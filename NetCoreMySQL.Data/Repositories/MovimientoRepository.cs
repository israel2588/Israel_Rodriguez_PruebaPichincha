using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using NetCoreMySql.Model;

namespace NetCoreMySQL.Data.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private MySQLConfiguration _connectionString;

      

        public MovimientoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

    
        public async Task<IEnumerable<Movimiento>> GetAllMovimiento()
        {
            var db = dbConnection();

            var sql = @"SELECT id,fecha, tipo_movimiento, valor, saldo, numero_cuenta FROM MOVIMIENTO";

            return await db.QueryAsync<Movimiento>(sql, new { });
        }



        public async Task<bool> InsertAccount(Movimiento movimiento)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO MOVIMIENTO (fecha, tipo_movimiento, valor, saldo, numero_cuenta)
                        VALUES (@fecha, @tipo_movimiento, @valor, @saldo, @numero_cuenta)";

            var result = await db.ExecuteAsync(sql, new { movimiento.fecha, movimiento.tipo_movimiento, movimiento.valor, movimiento.saldo, movimiento.numero_cuenta });

            return result > 0;
        }

        public async Task<bool> UpdateAccount(Movimiento movimiento)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE MOVIMIENTO
                        SET fecha=@fecha, tipo_movimiento=@tipo_movimiento, valor=@valor, saldo=@saldo,
                        numero_cuenta=@numero_cuenta)
                        WHERE id=@id";


            var result = await db.ExecuteAsync(sql, new { movimiento.fecha, movimiento.tipo_movimiento, movimiento.valor, movimiento.saldo, movimiento.numero_cuenta });

            return result > 0;
        }

        public async Task<bool> DeleteAccount(Movimiento movimiento)
        {
            var db = dbConnection();

         
            var sql = @"
                        UPDATE MOVIMIENTO
                        SET fecha=@fecha, tipo_movimiento=@tipo_movimiento, valor=@valor, saldo=@saldo,
                        numero_cuenta=@numero_cuenta)
                        WHERE id=@id";


            var result = await db.ExecuteAsync(sql, new { movimiento.fecha, movimiento.tipo_movimiento, movimiento.valor, movimiento.saldo, movimiento.numero_cuenta });

            return result > 0;
        }

    }
}
