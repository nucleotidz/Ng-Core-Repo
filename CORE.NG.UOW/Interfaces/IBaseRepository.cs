﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.NG.UOW
{
    /// <summary>
    /// Interface base repository class
    /// </summary>
    public interface IBaseRepository
    {
        /// <summary>
        /// Commits task
        /// </summary>
        /// <returns>No of rows effected</returns>
        int Commit();
    }
}
