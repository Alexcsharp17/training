using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.DAL.Procedures
{
    public interface IProcedures<T>
    {
        string Insert { get; }
        string Get { get; }
        string Update { get; }
        string GetEntities { get; }
        string Delete { get; }
        string Find { get; }
        string Count { get; }
    }
}
