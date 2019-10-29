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
        private AdministratorRepository administratorService;

        public IceCreamRepository()
        {
            administratorService = new AdministratorRepository();
        }

        public async Task AddIceCreamAsync(Administrator administrator, IceCream iceCream)
        {
            if(await administratorService.IsAdministratorAsync(administrator))
            {
                using(var db = new AppDbContext())
                {
                    db.IceCreams.Add(iceCream);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<List<IceCream>> GetStoreIceCreamsAsync(Store store)
        {
            using(var db = new AppDbContext())
            {
                return await db.IceCreams.Where(iceCream => store.IceCreams.Contains(iceCream.Id)).ToListAsync();
            }
        }
    }
}
