using InformationKiosk.DAL.HttpServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.BL
{
    public class ImageService
    {
        private readonly FirebaseService firebaseService;
        private readonly ImaggaService imaggaService;
        public ImageService()
        {
            firebaseService = new FirebaseService();
            imaggaService = new ImaggaService();
        }
        public async Task<string> UploadImageToFirebase(string imagePath)
        {
            return await firebaseService.UploadImageToFirebase(imagePath);
        }

        public async Task<bool> IsIceCreamImage(string imageUrl)
        {
            return await imaggaService.IsImageContainsItem(imageUrl, "ice cream");
        }
    }
}
