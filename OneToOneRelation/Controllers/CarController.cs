using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToOneRelation.Data;
using OneToOneRelation.Data.Entities;
using OneToOneRelation.ViewModels;

namespace OneToOneRelation.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(CarTableViewModel model)
        {
            IQueryable<Car> query = _context.Set<Car>();
            query = query.Include(c => c.Registration);
            model.Data = query.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            CarViewModel model = new CarViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CarViewModel viewModel)
        {
            Car entity = new Car();
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.MapTo(entity);
                    _context.Cars.Add(entity);
                    _context.SaveChanges();
                    TempData["success"] = $"Кола \"{entity.Model}\" е добавена успешно!";
                }
                catch
                {
                    TempData["error"] = "Колата не може да бъде добавена!";
                }
            }
            return View(viewModel);
        }

        public IActionResult Update(int Id)
        {
            Car? entity = _context.Cars
                .Include(c => c.Registration)
                .FirstOrDefault(c => c.Id == Id);

            if (entity == null)
            {
                TempData["error"] = "Колата не може да бъде намерена!";
                return RedirectToAction("Index");
            }
            CarViewModel viewModel = new CarViewModel();
            viewModel.MapFrom(entity);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(CarViewModel viewModel)
        {
            Car entity = _context.Cars
                .Include(c => c.Registration)
                .FirstOrDefault(c => c.Id == viewModel.CarId);

            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.MapTo(entity);
                    _context.Cars.Update(entity);
                    _context.SaveChanges();
                    TempData["success"] = $"Кола \"{entity.Model}\" е записана успешно!";
                }
                catch
                {
                    TempData["error"] = "Промените не бяха записани!";
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Car? entity = _context.Cars.Find(Id);
            if (entity == null)
            {
                TempData["error"] = "Такава картина не съществува!";
                return RedirectToAction("Index");
            }
            try
            {
                _context.Cars.Remove(entity);
                _context.SaveChanges();
                TempData["success"] = $"Кола \"{entity.Model}\" е изтрита успешно!";
            }
            catch
            {
                TempData["error"] = $"Възникна грешка при изтриването!";
            }
            return RedirectToAction("Index");
        }
    }
}
