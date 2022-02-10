using System.Transactions;

namespace TodoList.Applications.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="typeOfDbContext">The type of database context.</param>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        IDisposable BeginTransaction(IsolationLevel level);

        /// <summary>
        /// Commits the changes.
        /// </summary>
        /// <param name="typeOfDbContext">The type of database context.</param>
        void CommitChanges();

        /// <summary>
        /// Commits the changes.
        /// </summary>
        /// <param name="typeOfDbContext">The type of database context.</param>
        Task CommitChangesAsync();

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        /// <param name="typeOfDbContext">The type of database context.</param>
        void CommitTransaction();

        Task CommitTransactionAsync();

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        /// <param name="typeOfDbContext">The type of database context.</param>
        void RollbackTransaction();
    }
}
