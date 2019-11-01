using InformationKiosk.BL;
using InformationKiosk.DAL.Repositories;
using InformationKiosk.DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            addData().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static async Task addData()
        {
            var admiService = new AdministratorService();
            var storService = new StoreRepository();
            var icecreamService = new IceCreamRepository();

            var admin = await admiService.AddAdministratorcAsync("Meir", "Shimon", "meshimon@microsoft.com", "123456");
            
            var store = new Store
            {
                Id = Guid.NewGuid(),
                Address = "adress",
                PhoneNumber = "phoneNumber",
                Website = "website",
                IceCreams = new List<IceCream>()
            };

            await storService.AddStoreAsync(admin, store);

            var icecream1 = new IceCream
            {
                Id = Guid.NewGuid(),
                Score = 1,
                Description = "1",
            };
            var icecream2 = new IceCream
            {
                Id = Guid.NewGuid(),
                Score = 2,
                Description = "2",
            };

            await icecreamService.AddIceCreamAsync(admin, store, icecream1);
            await icecreamService.AddIceCreamAsync(admin, store, icecream2);

            var dbStore = await storService.GetStoreAsync(store);
            var dbStores = await storService.GetStoresAsync();

            var storeIcecreams = await icecreamService.GetIceCreamsAsync(store);
            Console.WriteLine(storeIcecreams);
        }
    }
}
