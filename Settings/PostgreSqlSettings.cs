namespace api.Settings{
    public class PostgreSqlSettings : DbSettings{
        public string ConnectionString{
            get
            {
                return $"Server={Host};Port={Port};Database={DbName};User Id={User};Password={Password}";
            }
        }        
    }
}