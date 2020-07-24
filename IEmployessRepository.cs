using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    interface IEmployessRepository
    {
        IEnumerable<Employees> GetALLEmployees();
    }
}
