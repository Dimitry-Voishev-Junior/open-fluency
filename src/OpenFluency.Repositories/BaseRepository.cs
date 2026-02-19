using System;
using System.Collections.Generic;
using System.Text;

namespace OpenFluency.Repositories
{
    public class BaseRepository
    {
        private readonly string _connectionString;
        public BaseRepository(string connectionString) 
        { 
            _connectionString = connectionString;
        }

        public string ConnectionString { get { return _connectionString;} }
    }
}
