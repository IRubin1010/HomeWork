using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DAL.HttpServices
{
    public class FirebaseService
    {
        public async Task<string> UploadImageToFirebase(string imagePaht)
        {
            var stream = File.Open(imagePaht, FileMode.Open);

            return await new FirebaseStorage("icecreamkiosk-e7c63.appspot.com")
                .Child("images")
                .Child($"{Guid.NewGuid()}.jpg")
                .PutAsync(stream);
        }
    }
}
