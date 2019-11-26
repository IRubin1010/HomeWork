using InformationKiosk.BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationKiosk.DAL.Repositories
{
    public class StoreRepository
    {

        public async Task AddStoreAsync(Store store)
        {
            using (var db = new AppDbContext())
            {
                db.Stores.Add(store);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Store>> GetStoresAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.Stores
                    .Include(s => s.IceCreams)
                        .ThenInclude(i => i.Nutrients)
                    .Include(s => s.IceCreams)
                        .ThenInclude(i => i.Reviews)
                    .ToListAsync();
            }
        }

        public async Task<Store> GetStoreAsync(Store store)
        {
            using (var db = new AppDbContext())
            {
                return await db.Stores.Include(s => s.IceCreams).FirstOrDefaultAsync(s => s.Id == store.Id);
            }
        }

        public async Task<Store> GetStoreAsync(Guid storeId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Stores.FirstOrDefaultAsync(s => s.Id == storeId);
            }
        }
    }
}
