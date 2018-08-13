// Interface Name IBaseRepository
// Author- Ahmar Husain
// Compnay - (EY GDS)

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
