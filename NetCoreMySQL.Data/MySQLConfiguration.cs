using System;
namespace NetCoreMySQL.Data
{
    public class MySQLConfiguration
    {
      
		public MySQLConfiguration(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; set; }

     
}
}
