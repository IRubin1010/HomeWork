using InformationKiosk.DataProtocol;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task AddReviewToIceCreamAsync(IceCream iceCream, Reviews review)
        {
            using (var db = new AppDbContext())
            {
                var dbIceCream = await db.IceCreams.Include(i => i.Reviews).Where(i => i.Id == iceCream.Id).FirstOrDefaultAsync();
                dbIceCream.Reviews.Add(review);
                await db.SaveChangesAsync();
            }
            await iceCreamRepository.UpdateScoreAsync(iceCream);
        }
    }
}
