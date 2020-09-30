using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CarStore.DAL.Interfaces
{
    public interface ICommandBuilder
    {
        DbDataReader DbDataRequestCommand(string procedure, Dictionary<string, object> parameters = null);
        void DbDataPostCommand(string procedure, Dictionary<string, object> parameters = null);
    }
}
