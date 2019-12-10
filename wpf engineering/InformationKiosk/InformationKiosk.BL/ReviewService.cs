using InformationKiosk.BE;
using InformationKiosk.DAL.Repositories;
using System.Collections.Generic;
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

        public async Task AddReviewToIceCreamAsync(IceCream iceCream, Review review)
        {
            await reviewsRepository.AddReviewToIceCreamAsync(iceCream, review);
        }

        public async Task<List<Review>> GetIceCreamReviews(IceCream iceCream)
        {
            return await reviewsRepository.GetIceCreamReviewsAsync(iceCream);
        }
    }
}
