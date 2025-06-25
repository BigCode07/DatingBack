using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class UserRepository(DataContext context) :IUserRepository
    {
    

        public async Task<AppUser?> GetUserByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<AppUser?> GetUserByUsernameAsync(string username)
        {
            return await context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            // Guarda los cambios en el contexto de la base de datos.
            return await context.SaveChangesAsync() > 0;
        }

        public void Update (AppUser user)
        {
            // Marca el usuario como modificado.
            context.Entry(user).State = EntityState.Modified;
        }
    }

}
