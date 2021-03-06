﻿using InformationKiosk.DAL.HttpServices;
using InformationKiosk.DAL.Repositories;
using InformationKiosk.BE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.BL
{
    public class IceCreamService
    {
        private IceCreamRepository iceCreamRepository;
        private NutritionsService nutritionsService;

        public IceCreamService()
        {
            iceCreamRepository = new IceCreamRepository();
            nutritionsService = new NutritionsService();
        }

        public async Task AddIceCreamAsync(Store store, IceCream iceCream)
        {
            var nutritions = await nutritionsService.GetNutritionsInformationAsync(iceCream.NutritionId);
            iceCream.Nutrients = nutritions;
            await iceCreamRepository.AddIceCreamAsync(store, iceCream);
        }

        public async Task<List<IceCream>> GetIceCreamsAsync(Store store)
        {
            return await iceCreamRepository.GetIceCreamsAsync(store);
        }

        public async Task<IceCream> GetIceCreamAsync(Guid iceCreamId)
        {
            return await iceCreamRepository.GetIceCreamAsync(iceCreamId);
        }

        public async Task<List<IceCream>> GetIceCreamsAsync()
        {
            return await iceCreamRepository.GetIceCreamsAsync();
        }

        public async Task<List<IceCream>> GetIceCreamsByMaxScoreAsync()
        {
            var icecreams = await iceCreamRepository.GetIceCreamsAsync();
            var maxScore = icecreams.Select(i => i.Score).Max();
            return icecreams.Where(i => i.Score == maxScore).ToList();
        }

        public async Task<List<IceCream>> GetIceCreamsByLowScoreAsync()
        {
            var icecream = await iceCreamRepository.GetIceCreamsAsync();
            var lowScore = icecream.Select(i => i.Score).Min();
            return icecream.Where(i => i.Score == lowScore).ToList();
        }

        public async Task<List<IceCream>> GetIceCreamByDescription(string description)
        {
            return await iceCreamRepository.GetIceCreamsByDescrption(description);
        }
    }
}
