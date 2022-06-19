using System;
namespace NetCoreMySql.Model
{
    public class Cuenta
    {
        public string numero_cuenta { get; set; }
        public string tipo_cuenta { get; set; }
        public string saldo_Inicial { get; set; }
        public string estado { get; set; }
        public int idCuenta { get; set; }
    }
}
