using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInjestion.Sql.Business.Contract
{
    interface IGetData
    {
        Task GetCollection();
    }
}
