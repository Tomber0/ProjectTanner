using Microsoft.EntityFrameworkCore;
using ProjectTanner.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.IO;
using System.Xml.Linq;

namespace ProjectTanner.Utils
{
    public class TaskUtils
    {
        // TODO : void -> bool
        public static async void CreateTask(Context.AppContext context, TaskCreateModel model) 
        {
            var user = context.Users.Include(u=>u.Tasks).FirstOrDefault(u=>u.Id == model.UserId);
            var entity = context.Tasks.Add(new Models.Task() 
            {
                Name = model.Name,
                Description = model.Description,
                IsRepeated = model.IsRepeated,
                User = user
            });
            await context.SaveChangesAsync();
        }
        
        public static async void DeleteTaskById(Context.AppContext context,int id) 
        {
            var task = await context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }
        public static async void UpdateTask(Context.AppContext context, Models.Task model)
        {
            var user = context.Users.Include(u => u.Tasks).FirstOrDefault(u => u.Id == model.User.Id);
            var entity = context.Tasks.FirstOrDefault(t => t.Id == model.Id);
            if (entity is not null)
            {
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.IsRepeated = model.IsRepeated;
                entity.User = model.User;
                entity.ExpDate = model.ExpDate;
                entity.IsComplete = model.IsComplete;
                entity.Status = model.Status;
                entity.Streak = model.Streak;
            }
            else 
            {
                context.Tasks.Add(new Models.Task()
                {
                    Name = model.Name,
                    Description = model.Description,
                    IsRepeated = model.IsRepeated,
                    User = model.User,
                    ExpDate = model.ExpDate,
                    IsComplete = model.IsComplete,
                    Status = model.Status,
                    Streak = model.Streak,
                });
            }

            await context.SaveChangesAsync();


        }
        //TODO END

        public static List<Models.Task> GetAllTasksByUserTName(Context.AppContext context,string tName) 
        {
            return context.Users.Include(u => u.Tasks).FirstOrDefault(u => u.TId == tName)?.Tasks ?? new List<Models.Task>();
        }
        public static Models.Task? GetTaskById(Context.AppContext context, int taskId) 
        {
            return context.Tasks.FirstOrDefault(t => t.Id == taskId);
        }
    }
}
