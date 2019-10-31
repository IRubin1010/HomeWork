using InformationKiosk.DataProtocol;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DAL.Repositories
{
    public class IceCreamRepository
    {
        private AdministratorRepository administratorRepository;

        public IceCreamRepository()
        {
            administratorRepository = new AdministratorRepository();
        }

        public async Task AddIceCreamAsync(Administrator administrator, Store store, IceCream iceCream)
        {
            if (await administratorRepository.IsAdministratorAsync(administrator))
            {
                using (var db = new AppDbContext())
                {
                    var dbStore = await db.Stores.Include(s => s.IceCreams).Where(s => s.Id == store.Id).FirstOrDefaultAsync();
                    dbStore.IceCreams.Add(iceCream);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<List<IceCream>> GetIceCreamsAsync(Store store)
        {
            using (var db = new AppDbContext())
            {
                return (await db.Stores.Include(s => s.IceCreams).FirstOrDefaultAsync(s => s.Id == store.Id)).IceCreams;
            }
        }

        public async Task<List<IceCream>> GetIceCreamsAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.IceCreams.ToListAsync();
            }
        }

        public async Task<List<IceCream>> GetIceCreamsByDescrption(string description)
        {
            using (var db = new AppDbContext())
            {
                return await db.IceCreams.Where(i => i.Description.Contains(description)).ToListAsync();
            }
        }
    }
}
