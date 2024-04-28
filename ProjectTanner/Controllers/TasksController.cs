using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTanner.Utils;

namespace ProjectTanner.Controllers
{
    [Route("api")]
    public class TasksController : Controller
    {

        private readonly ILogger<TasksController> _logger;
        private readonly Context.AppContext _appContext;



        //crud
        //add routes

        public TasksController(ILogger<TasksController> logger, Context.AppContext appContext)
        {
            _logger = logger;
            _appContext = appContext;
        }

        // GET: TasksController
        public ActionResult Index()
        {
            return View();
        }
        //??







































        // GET: TasksController/Details/5
        public ActionResult Details(int id)
        {
            Models.Task? task = null;
            try
            {
                task = TaskUtils.GetTaskById(_appContext, id);
            }
            catch (Exception ex)
            {
                throw;
            }
            
            
            return View();
        }

        // GET: TasksController/Create
        //post
        //gets json object
        //returns 201
        //400
        //
        public ActionResult Create()
        {
            return View();
        }



        // POST: TasksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //post -> send json object 
        // GET: TasksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //delete 
        // GET: TasksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TasksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
