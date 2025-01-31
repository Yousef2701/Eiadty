using Medical.Core.Interfaces;
using Medical.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Medical.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        #region Dependancey injuction

        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion


        #region Create Async

        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        #endregion

        #region Get By Id Async

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        #endregion

        #region Get All Async

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        #endregion

    }
}
