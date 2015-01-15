using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCore.Models;

namespace TestCore.Interfaces
{
    interface IFlightApiTestService
    {
        Task<string> GetAuthenticationKeyAsync();
        Task<string> GetSearchDataAsync();

    }

}
