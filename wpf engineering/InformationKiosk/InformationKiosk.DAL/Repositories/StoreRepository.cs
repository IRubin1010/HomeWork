using InformationKiosk.DataProtocol;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DAL.Repositories
{
    public class StoreRepository
    {
        private AdministratorRepository administratorService;

        public StoreRepository()
        {
            administratorService = new AdministratorRepository();
        }

        public async Task AddStoreAsync(Administrator administrator, Store store)
        {
            if(await administratorService.IsAdministratorAsync(administrator))
            {
                using(var db = new AppDbContext())
                {
                    db.Stores.Add(store);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Store>> GetStoresAsync()
        {
            using(var db = new AppDbContext())
            {
                return await db.Stores.ToListAsync();
            }
        }
    }
}
