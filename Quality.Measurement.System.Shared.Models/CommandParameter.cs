using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Quality.Measurement.System.Shared.Helpers.Constants;

namespace Quality.Measurement.System.Shared.Models
{
    public class CommandParameter
    {
        public CommandParameter(string commandName, CommandExecutionType commandExecutionType)
        {
            CommandType = CommandType.StoredProcedure;
            CommandName = commandName;
            ExecutionType = commandExecutionType;
        }

        public string CommandName { get; private set; }

        public CommandType CommandType { get; private set; }

        public List<SqlParameter> Parameters { get; set; }

        public CommandExecutionType ExecutionType { get; private set; }

    }
}
