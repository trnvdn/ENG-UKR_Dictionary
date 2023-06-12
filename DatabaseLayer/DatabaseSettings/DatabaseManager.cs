using System;
using System.Data.SQLite;

namespace DatabaseLayer
{
    public static class DatabaseManager
    {
        private static string _defaultConnectionString = @"Data Source=..\..\..\..\DatabaseLayer\Database\MaintainDatabase.db;Version=3;";
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    return _defaultConnectionString;
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
    }
}