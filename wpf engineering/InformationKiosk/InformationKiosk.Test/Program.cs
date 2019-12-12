using InformationKiosk.BL;
using InformationKiosk.DAL.HttpServices;
using InformationKiosk.DAL.Repositories;
using InformationKiosk.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using BingMapsRESTToolkit;

namespace InformationKiosk.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            addData().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static async Task GetNutritions()
        {
            var nutritionsService = new NutritionsService();
            var nut = await nutritionsService.GetNutritionsInformationAsync(19095);
        }

        public static async Task addData()
        {

            var localDir = Directory.GetCurrentDirectory().Replace("InformationKiosk.Test\\bin\\Debug", "");
            var imgPath = localDir + "gettyimages-166017058-612x612.jpg";

            var admiService = new AdministratorService();
            var storService = new StoreRepository();
            var icecreamService = new IceCreamService();
            var reviewService = new ReviewService();
            var imaggaService = new ImaggaService();

            //var admin = await admiService.GetAdministratorAsync("meshimon@microsoft.com", "123456");
            var admin = await admiService.AddNewAdministratorcAsync("Meir", "Shimon", "meshimon@microsoft.com", "123456");

            var store1Img = localDir + "ice-cream-store-1.jpg";
            var store1Location = new SimpleWaypoint("Rabi Akiva 100, Bne Brak, Tel Aviv, Israel");
            await SimpleWaypoint.TryGeocodeWaypoints(new List<SimpleWaypoint>() { store1Location }, "AttsGkqIHCOIEA11KtQZDphl5bi8lppin64jeg-ZOOhiS4cdHA_EXJwHSbyZi4Xo");
            var store = new Store
            {
                Id = Guid.NewGuid(),
                Name = "Ice Creams",
                Location = new StoreLocation()
                {
                    Id = Guid.NewGuid(),
                    Address = store1Location.Address,
                    longitude = store1Location.Coordinate.Longitude,
                    latitude = store1Location.Coordinate.Latitude
                },
                PhoneNumber = "0722366058",
                Website = "http://localhost:3000",
                Img = ConvertToBitmap(store1Img),
                IceCreams = new List<IceCream>()
            };
            
            var store2Img = localDir + "ice-cream-store-2.jpg";
            var store2Location = new SimpleWaypoint("Hazon Ish 50, Bne Brak, Tel Aviv 51511, Israel");
            await SimpleWaypoint.TryGeocodeWaypoints(new List<SimpleWaypoint>() { store2Location }, "AttsGkqIHCOIEA11KtQZDphl5bi8lppin64jeg-ZOOhiS4cdHA_EXJwHSbyZi4Xo");
            var store2 = new Store
            {
                Id = Guid.NewGuid(),
                Name = "icei",
                Location = new StoreLocation()
                {
                    Id = Guid.NewGuid(),
                    Address = store2Location.Address,
                    longitude = store2Location.Coordinate.Longitude,
                    latitude = store2Location.Coordinate.Latitude
                },
                PhoneNumber = "0504178966",
                Website = "http://localhost:3000",
                Img = ConvertToBitmap(store2Img),
                IceCreams = new List<IceCream>()
            };

            await storService.AddStoreAsync(store);
            await storService.AddStoreAsync(store2);

            //var icecream1 = new IceCream
            //{
            //    Id = Guid.NewGuid(),
            //    Score = 1,
            //    Description = "1",
            //};
            //var icecream2 = new IceCream
            //{
            //    Id = Guid.NewGuid(),
            //    Score = 2,
            //    Description = "2",
            //};

            var img = ConvertToBitmap(imgPath);
            var iceCreamVanilaImg = localDir + "ice-cream-vanila-1.jpg";
            var iceCream1 = new IceCream()
            {
                Name = "Vanila IceCream",
                Description = "nice iceCream",
                Score = 5,
                NutritionId = 19095,
                Img = ConvertToBitmap(iceCreamVanilaImg)
            };
            await icecreamService.AddIceCreamAsync(store, iceCream1);
            var iceCreamStrawberryImg = localDir + "ice-cream-strawberry-1.jpg";
            var iceCream2 = new IceCream()
            {
                Name = "Strawberry IceCream",
                Description = "good iceCream",
                Score = 5,
                NutritionId = 19271,
                Img = ConvertToBitmap(iceCreamStrawberryImg)
            };
            await icecreamService.AddIceCreamAsync(store, iceCream2);
            var iceCreamChocolateImg = localDir + "ice-cream-chocolate-1.jpg";
            var iceCream3 = new IceCream()
            {
                Name = "Chocolate IceCream",
                Description = "best iceCream",
                Score = 5,
                NutritionId = 19270,
                Img = ConvertToBitmap(iceCreamChocolateImg)
            };
            await icecreamService.AddIceCreamAsync(store, iceCream3);

            var x = await imaggaService.IsImageContainsItem("https://www.benjerry.co.il/app/uploads/2016/03/56ea8a8d9ba7a_1458211469.png", "ice cream");


            var iceCreams = await icecreamService.GetIceCreamsAsync(store);
            await reviewService.AddReviewToIceCreamAsync(iceCreams[0], new Review()
            {
                Description = "Good ice cream",
                Score = 2,
                Img = img
            });
            await reviewService.AddReviewToIceCreamAsync(iceCreams[0], new Review()
            {
                Description = "very Good ice cream",
                Score = 4,
                Img = img
            });

            var dbStore = await storService.GetStoreAsync(store.Id);
            var dbStores = await storService.GetStoresAsync();

            var storeIcecreams = await icecreamService.GetIceCreamsAsync(store);
            Console.WriteLine(storeIcecreams);
        }

        public static Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);

                bitmap = new Bitmap(image);

            }
            return bitmap;
        }
    }
}
