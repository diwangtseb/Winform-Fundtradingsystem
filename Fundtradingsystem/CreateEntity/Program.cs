using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundtradingsystem;

namespace CreateEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SqlSugarDbFirst.GetSqlConction();
            db.DbFirst.CreateClassFile(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 10), "Fundtradingsystem");
        }
    }
}
