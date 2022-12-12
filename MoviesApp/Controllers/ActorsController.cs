using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApp.Data;
using MoviesApp.Filters;
using MoviesApp.Models;
using MoviesApp.ViewModels.Actors;

namespace MoviesApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MoviesContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;


        public ActorsController(MoviesContext context, ILogger<HomeController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        // GET: Actors
        public IActionResult Index()
        {
            var actors = _mapper.Map<IEnumerable<Actor>, IEnumerable<ActorViewModel>>(_context.Actors.ToList());
            return View(actors);
        }

        [HttpGet]
        // GET: Actors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ActorViewModel>(_context.Actors.FirstOrDefault(a => a.Id == id));
            
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
        [EnsureAppropriateAge]
        public IActionResult Create([Bind("Name,Surname,BirthDate")] InputActorViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Actor>(inputModel));
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

            var editModel = _mapper.Map<EditActorViewModel>(_context.Actors.FirstOrDefault(a => a.Id == id));
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
        [EnsureAppropriateAge]
        public IActionResult Edit(int id, [Bind("Name,Surname,BirthDate")] EditActorViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var actor = _mapper.Map<Actor>(editModel);
                    actor.Id = id;
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

            var deleteModel = _mapper.Map<DeleteActorViewModel>(_context.Actors.FirstOrDefault(a => a.Id == id));
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