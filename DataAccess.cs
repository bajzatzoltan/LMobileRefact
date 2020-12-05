using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
    public class DataAccess
    {
        protected DataAccess()
        {

        }
		protected long ExecuteDatabaseCommand(string command)
		{
			// Executes a database command using the given query and arguments.
			throw new NotImplementedException(String.Concat("Error: ", this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name, " method."));
		}
		protected IDataReader ExecuteDatabaseReader(string query, IDictionary<string, object> arguments)
		{
			// Executes a database reader using the given query and arguments.
			throw new NotImplementedException(String.Concat("Error: ", this.GetType().Name,".", MethodBase.GetCurrentMethod().Name, " method."));
		}

		protected int ExecuteDatabaseCommand(string command, IDictionary<string, object> arguments)
		{
			// Executes a database command using the given query and arguments.
			throw new NotImplementedException(String.Concat("Error: ", this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name, " method."));
		}

	}
}
