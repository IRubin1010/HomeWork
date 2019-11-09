using InformationKiosk.BE;
using InformationKiosk.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.BL
{
    public class StoreService
    {
        private StoreRepository storeRepository;

        public StoreService()
        {
            storeRepository = new StoreRepository();
        }

        public async Task<List<Store>> GetStoresAsync()
        {
            return await storeRepository.GetStoresAsync();
        }
    }
}
