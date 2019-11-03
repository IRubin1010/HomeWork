using InformationKiosk.DAL.Repositories;
using InformationKiosk.DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task AddReviewToIceCreamAsync(IceCream iceCream, string description, int score/*, Bitmap img*/)
        {
            var review = new Reviews
            {
                Description = description,
                Score = score
            };

            await reviewsRepository.AddReviewToIceCreamAsync(iceCream, review);
        }
    }
}
