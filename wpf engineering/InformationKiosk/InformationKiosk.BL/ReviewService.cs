using InformationKiosk.BE;
using InformationKiosk.DAL.Repositories;
using System.Drawing;
using System.Threading.Tasks;

namespace InformationKiosk.BL
{
    public class ReviewService
    {
        private ReviewsRepository reviewsRepository;

        public ReviewService()
        {
            reviewsRepository = new ReviewsRepository();
        }

        public async Task AddReviewToIceCreamAsync(IceCream iceCream, string description, int score, Bitmap img)
        {
            var review = new Reviews
            {
                Description = description,
                Score = score,
                Img = img
            };

            await reviewsRepository.AddReviewToIceCreamAsync(iceCream, review);
        }
    }
}
