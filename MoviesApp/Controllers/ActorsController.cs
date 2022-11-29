using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MoviesContext _context;
        private readonly ILogger<HomeController> _logger;


        public ActorsController(MoviesContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        // GET: Actors
        public IActionResult Index()
        {
            return View(_context.Actors.Select(m => new ActorViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Surname = m.Surname,
                BirthDate = m.BirthDate
            }).ToList());
        }

        [HttpGet]
        // GET: Actors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var viewModel = _context.Actors.Where(m => m.Id == id).Select(m => new ActorViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Surname = m.Surname,
                BirthDate = m.BirthDate
            }).FirstOrDefault();
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Actors/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Surname,BirthDate")] InputActorViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Actor
                {
                    Name = inputModel.Name,
                    Surname = inputModel.Surname,
                    BirthDate = inputModel.BirthDate
                });
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(inputModel);
        }

        [HttpGet]
        // GET: Actors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var editModel = _context.Actors.Where(m => m.Id == id).Select(m => new EditActorViewModel
            {
                Name = m.Name,
                Surname = m.Surname,
                BirthDate = m.BirthDate
            }).FirstOrDefault();
            if (editModel == null)
            {
                return NotFound();
            }

            return View(editModel);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Surname,BirthDate")] EditActorViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var actor = new Actor
                    {
                        Id = id,
                        Name = editModel.Name,
                        Surname = editModel.Surname,
                        BirthDate = editModel.BirthDate
                    };
                    _context.Update(actor);
                    _context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    if (!ActorExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(editModel);
        }

        [HttpGet]
        // GET: Actors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var deleteModel = _context.Actors.Where(m => m.Id == id).Select(m => new DeleteActorViewModel
            {
                Name = m.Name,
                Surname = m.Surname,
                BirthDate = m.BirthDate
            }).FirstOrDefault();
            if (deleteModel == null)
            {
                return NotFound();
            }

            return View(deleteModel);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Actors == null)
            {
                return Problem("Entity set 'MoviesContext.Actor'  is null.");
            }

            var actor = _context.Actors.Find(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
            }

            _context.SaveChanges();
            _logger.LogWarning($"Actor with id {actor.Id} has been deleted!");
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}