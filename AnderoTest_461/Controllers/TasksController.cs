using AnderoTest_461.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AnderoTest_461.Controllers
{
	public class TasksController : Controller
	{
		private TasksContext db = new TasksContext();

		// GET: Tasks
		public ActionResult Index()
		{
			return View(db.Tasks.ToList());
		}

		// GET: Tasks/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Task task = db.Tasks.Find(id);
			if (task == null)
			{
				return HttpNotFound();
			}
			return View(task);
		}

		// GET: Tasks/Create
		public ActionResult Create()
		{
			Task task = new Task
			{
				Created = DateTime.UtcNow,
				Modified = DateTime.UtcNow,
				Expired = DateTime.UtcNow
			};
			return View(task);
		}

		// POST: Tasks/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,Title,SavedDates,Created,Modified,Expired")] Task task)
		{
			if (ModelState.IsValid)
			{
				task.Modified = DateTime.UtcNow;
				task.SavedDates = $"N: {DateTime.UtcNow} || M: {task.Modified} || X: {task.Expired}";

				db.Tasks.Add(task);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(task);
		}

		public static TimeSpan GetOffSetTime(string date)
		{
			DateTime d = Convert.ToDateTime(date);
			TimeZone zone = TimeZone.CurrentTimeZone;
			TimeSpan local = zone.GetUtcOffset(d);
			return local;
		}

		// GET: Tasks/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Task task = db.Tasks.Find(id);
			if (task == null)
			{
				return HttpNotFound();
			}
			return View(task);
		}

		// POST: Tasks/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,Title,SavedDates,Created,Modified,Expired")] Task task)
		{
			if (ModelState.IsValid)
			{
				task.Modified = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

				task.SavedDates = $"N: {DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)} || M: {task.Modified} || X: {task.Expired}";

				db.Entry(task).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(task);
		}

		// GET: Tasks/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Task task = db.Tasks.Find(id);
			if (task == null)
			{
				return HttpNotFound();
			}
			return View(task);
		}

		// POST: Tasks/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Task task = db.Tasks.Find(id);
			db.Tasks.Remove(task);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
