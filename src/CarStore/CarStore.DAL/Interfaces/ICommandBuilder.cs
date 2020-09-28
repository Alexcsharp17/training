using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CarStore.DAL.Interfaces
{
    public interface ICommandBuilder
    {
        DbCommand Create(string procedure, Dictionary<string, object> parameters = null);
    }
}
