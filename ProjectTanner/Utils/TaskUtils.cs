using Microsoft.EntityFrameworkCore;
using ProjectTanner.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.IO;
using System.Xml.Linq;

namespace ProjectTanner.Utils
{
    public class TaskUtils
    {
        public static string UniqueId 
        {
            get 
            {
                return Guid.NewGuid().ToString();
            } 
        }

        public static Models.Task CreateTask(Context.AppContext context, TaskCreateModel model) 
        {
            var user = context.Users.Include(u=>u.Tasks).FirstOrDefault(u=>u.Id == model.UserId);
            var task = new Models.Task()
            {
                Name = model.Name,
                Description = model.Description,
                User = user,
                Streak = -1,
                ExpDate = model.ExpDate,
            };
            if (model.IsRepeated) 
            {
                task.Streak = 0;
            }
            context.Tasks.Add(task);
            context.SaveChanges();
            return task;
        }
        
        public static async void ChangeStreak(Context.AppContext context, int id, int newStreak)
        {
            var task = await context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
            task.Streak = newStreak;
            await context.SaveChangesAsync();
        }

        public static async void DeleteTaskById(Context.AppContext context,int id) 
        {
            var task = await context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }

        public static async void UpdateName(Context.AppContext context, int id, string newName) 
        {
            var task = await context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
            task.Name = newName;
            await context.SaveChangesAsync();
        }

        public static async void UpdateDescription(Context.AppContext context, int id, string newDescription) 
        {
            var task = await context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
            task.Description = newDescription;
            await context.SaveChangesAsync();
        }

        public static async void UpdateStatus(Context.AppContext context, int id, int status) 
        {
            var task = await context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
            task.Status = status;
            await context.SaveChangesAsync();
        }

        public static async void UpdateTime(Context.AppContext context, int id, DateTime newTime) 
        {
            var task = await context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
            task.ExpDate = newTime;
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
                entity.User = model.User;
                entity.ExpDate = model.ExpDate;
                entity.Status = model.Status;
                entity.Streak = model.Streak;
            }
            else 
            {
                context.Tasks.Add(new Models.Task()
                {
                    Name = model.Name,
                    Description = model.Description,
                    User = model.User,
                    ExpDate = model.ExpDate,
                    Status = model.Status,
                    Streak = model.Streak,
                });
            }
            await context.SaveChangesAsync();
        }

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
