using InformationKiosk.BE;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DAL.Repositories
{
    public class ReviewsRepository
    {
        private IceCreamRepository iceCreamRepository;

        public ReviewsRepository()
        {
            iceCreamRepository = new IceCreamRepository();
        }

        public async Task AddReviewToIceCreamAsync(IceCream iceCream, Review review)
        {
            using (var db = new AppDbContext())
            {
                var dbIceCream = await db.IceCreams.Include(i => i.Reviews).Where(i => i.Id == iceCream.Id).FirstOrDefaultAsync();
                dbIceCream.Reviews.Add(review);
                await db.SaveChangesAsync();
            }
            await iceCreamRepository.UpdateScoreAsync(iceCream);
        }

        public async Task<List<Review>> GetIceCreamReviewsAsync(IceCream iceCream)
        {
            using (var db = new AppDbContext())
            {
                return await db.IceCreams.Include(i => i.Reviews).Where(i => i.Id == iceCream.Id).Select(i => i.Reviews).FirstOrDefaultAsync();
            }
        }
    }
}
