using ProjectTanner.Models;

namespace ProjectTanner.Utils
{
    public class UserUtils
    {
        public static async Task<bool> CreateUser(Context.AppContext context, UserCreateModel model)
        {
            context.Users.Add(new User() { Name = model.Name, TId = model.TName });
            await context.SaveChangesAsync();
            return true;
        }
    }
}
