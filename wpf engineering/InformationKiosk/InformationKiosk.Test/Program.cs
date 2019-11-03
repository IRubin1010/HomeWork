using InformationKiosk.BL;
using InformationKiosk.DAL.HttpServices;
using InformationKiosk.DAL.Repositories;
using InformationKiosk.DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

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
            var admiService = new AdministratorService();
            var storService = new StoreRepository();
            var icecreamService = new IceCreamService();
            var reviewService = new ReviewService();

            //var admin = await admiService.GetAdministratorAsync("meshimon@microsoft.com", "123456");
            var admin = await admiService.AddNewAdministratorcAsync("Meir", "Shimon", "meshimon@microsoft.com", "123456");


            var store = new Store
            {
                Id = Guid.NewGuid(),
                Address = "adress",
                PhoneNumber = "phoneNumber",
                Website = "http://localhost:3000",
                Img = ConvertToBitmap("C:\\Users\\meir\\Downloads\\8eb5e48828b5a90b57a7fc6402b49055.jpg"),
                IceCreams = new List<IceCream>()
            };

            await storService.AddStoreAsync(admin, store);

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

            var img = ConvertToBitmap("C:\\Users\\meir\\Downloads\\8eb5e48828b5a90b57a7fc6402b49055.jpg");
            await icecreamService.AddIceCreamAsync(admin, store, "Vanila IceCream", "", 5, 19095, img);
            await icecreamService.AddIceCreamAsync(admin, store, "Strawberry IceCream", "", 5, 19271, img);

            var iceCreams = await icecreamService.GetIceCreamsAsync(store);
            await reviewService.AddReviewToIceCreamAsync(iceCreams[0], "Good ice cream", 2);
            await reviewService.AddReviewToIceCreamAsync(iceCreams[0], "Good ice cream", 4);

            var dbStore = await storService.GetStoreAsync(store);
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
