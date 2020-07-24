using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BestBuyBestPractices
{
  public  interface IDepartmentRepository
    {
        IEnumerable<Departments> GetALLDepartments();
       

    }
}
