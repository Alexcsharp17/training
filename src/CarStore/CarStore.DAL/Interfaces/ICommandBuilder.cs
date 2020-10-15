using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace CarStore.DAL.Interfaces
{
    public interface ICommandBuilder
    {
        DataTable DbDataReaderCommand(string procedure, Dictionary<string, object> parameters = null);
        int DbDataScalarCommand(string procedure, Dictionary<string, object> parameters = null);
    }
}
