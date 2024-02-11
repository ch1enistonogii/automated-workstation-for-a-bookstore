using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automated_workstation_for_a_bookstore
{
    public interface IConnectionProvider
    {
        NpgsqlConnection GetConnection();
    }
}