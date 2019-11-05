using InformationKiosk.BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                var a = (await db.Stores.Where(s => s.Id == store.Id)
                    .Include(s => s.IceCreams)
                        .ThenInclude(i => i.Nutrients)
                    .Include(s => s.IceCreams)
                        .ThenInclude(i => i.Reviews)
                        .FirstOrDefaultAsync()).IceCreams;
                return a;
            }
        }

        public async Task<List<IceCream>> GetIceCreamsAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.IceCreams.Include(i => i.Nutrients).ToListAsync();
            }
        }

        public async Task<IceCream> GetIceCreamAsync(IceCream iceCream)
        {
            using (var db = new AppDbContext())
            {
                return await db.IceCreams.FirstOrDefaultAsync(i => i.Id == iceCream.Id);
            }
        }

        public async Task<List<IceCream>> GetIceCreamsByDescrption(string description)
        {
            using (var db = new AppDbContext())
            {
                return await db.IceCreams.Where(i => i.Description.Contains(description)).Include(i => i.Nutrients).ToListAsync();
            }
        }

        public async Task UpdateScoreAsync(IceCream iceCream)
        {
            using (var db = new AppDbContext())
            {
                var iceCreamDB = await db.IceCreams.Include(i => i.Reviews).FirstOrDefaultAsync(i => i.Id == iceCream.Id);
                var newScore = iceCreamDB.Reviews.Sum(x => x.Score)/ iceCreamDB.Reviews.Count;
                iceCreamDB.Score = newScore;
                await db.SaveChangesAsync();
            }
        }
    }
}
