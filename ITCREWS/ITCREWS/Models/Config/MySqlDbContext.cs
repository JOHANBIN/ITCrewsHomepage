using CrewModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCREWS.Models.Config
{
    public class MySqlDbContext : IDBContext
    {
        public DBConfig Config { get; set; }

        public string GetConnString()
        {
            return $"Server={Config.EndPoint}; Database={Config.Database}; Uid={Config.Id}; Pwd={Config.Password};";
        }
    }
}
