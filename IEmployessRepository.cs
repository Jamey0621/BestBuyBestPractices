using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
   public  interface IEmployessRepository
    {
        IEnumerable<Employees> GetALLEmployees();
    }
}
