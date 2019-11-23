using InformationKiosk.BE;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InformationKiosk.DAL.Repositories
{
    public class AdministratorRepository
    {
        public async Task<bool> IsAdministratorAsync(Administrator administrator)
        {
            using (var db = new AppDbContext())
            {
                return (await db.Administrators.FirstOrDefaultAsync(admin => admin.Id == administrator.Id)) != null;
            }
        }

        public async Task AddAdministratorAsync(Administrator admin, Administrator administratorToAdd)
        {
            if (await IsAdministratorAsync(admin))
            {
                using (var db = new AppDbContext())
                {
                    db.Administrators.Add(administratorToAdd);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task AddNewAdministratorAsync(Administrator administratorToAdd)
        {
            using (var db = new AppDbContext())
            {
                db.Administrators.Add(administratorToAdd);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Administrator> GetAdministratorAsync(string userName, string password)
        {
            using (var db = new AppDbContext())
            {
                return await db.Administrators.FirstOrDefaultAsync(a => a.FirstName == userName && a.Password == password);
            }
        }
    }
}
