using InformationKiosk.DAL.Repositories;
using InformationKiosk.DataProtocol;
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
        private IceCreamRepository iceCreamRepository;
        public searchService()
        {
            storeRepository = new StoreRepository();
            iceCreamRepository = new IceCreamRepository();
        }

        public  async Task<List<IceCream>> GetIceCreamsByMaxScoreAsync()
        {
            var icecreams = await iceCreamRepository.GetIceCreamsAsync();
            var maxScore =  icecreams.Select(i => i.Score).Max();
            return icecreams.Where(i => i.Score == maxScore).ToList();
        }

        public async Task<List<IceCream>> GetIceCreamsByLowScoreAsync()
        {
            var icecream = await iceCreamRepository.GetIceCreamsAsync();
            var lowScore = icecream.Select(i => i.Score).Max();
            return icecream.Where(i => i.Score == lowScore).ToList();
        }

        public async Task<Dictionary<IceCream,Store>> GetIceCreamByDescription(string description)
        {
            var iceCreams = new Dictionary<IceCream, Store>();
            var iceCreamsList= await iceCreamRepository.GetIceCreamsByDescrption(description);
            foreach (var icecream in iceCreamsList)
            {
                var store = await storeRepository.GetStoreAsync(icecream.StoreId);
                iceCreams.Add(icecream, store);
            }
            return iceCreams;
        }
    }
}
