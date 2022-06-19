using System;
namespace NetCoreMySql.Model
{
    public class Movimiento
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string tipo_movimiento { get; set; }
        public string valor { get; set; }
        public string saldo { get; set; }
        public string numero_cuenta { get; set; }
    }
}
