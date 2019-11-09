using InformationKiosk.BE;
using InformationKiosk.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.BL
{
    public class searchService
    {
        private StoreRepository storeRepository;
        private IceCreamService iceCreamService;
        public searchService()
        {
            storeRepository = new StoreRepository();
            iceCreamService = new IceCreamService();
        }

        public async Task<Dictionary<IceCream, Store>> GetIceCreamsByMaxScoreAsync()
        {
            return await EnrichIceCreams(await iceCreamService.GetIceCreamsByMaxScoreAsync());

        }

        public async Task<Dictionary<IceCream, Store>> GetIceCreamsByLowScoreAsync()
        {
            return await EnrichIceCreams(await iceCreamService.GetIceCreamsByLowScoreAsync());
        }

        public async Task<Dictionary<IceCream, Store>> GetIceCreamByDescription(string description)
        {
            return await EnrichIceCreams(await iceCreamService.GetIceCreamByDescription(description));
        }

        private async Task<Dictionary<IceCream, Store>> EnrichIceCreams(List<IceCream> iceCreamsList)
        {
            Dictionary<IceCream, Store> iceCreams = new Dictionary<IceCream, Store>();
            foreach (var icecream in iceCreamsList)
            {
                var store = await storeRepository.GetStoreAsync(icecream.StoreId);
                iceCreams.Add(icecream, store);
            }
            return iceCreams;
        }
    }
}
