using System.Configuration;

namespace SalaryApp
{
    public static class DB
    {
        // Можно вынести строку подключения в app.config и доставать её вот так:
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["SalaryDb"].ConnectionString;
    }
}