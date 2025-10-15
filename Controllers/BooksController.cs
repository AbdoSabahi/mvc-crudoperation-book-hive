using CRUDOperations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDOperations.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var books = _context.Books
        .Include(b => b.Category)
        .ToList();


            return View(books);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var viewmodel = new BooksFormViewModels
            {
                Categories = _context.Categories
                    .Where(c => c.IsActive)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToList()
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(BooksFormViewModels model)
        {

            if (!ModelState.IsValid)
            {
                model.Categories = _context.Categories
                    .Where(c => c.IsActive)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToList();

                return View("Create", model);
            }

            if (model.Id == 0)
            {

                var newBook = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Description = model.Description,
                    CategoryId = model.CategoryId
                };
                _context.Books.Add(newBook);
            }
            else
            {

                var existingBook = _context.Books.Find(model.Id);

                if (existingBook == null)
                    return NotFound();

                existingBook.Title = model.Title;
                existingBook.Author = model.Author;
                existingBook.Description = model.Description;
                existingBook.CategoryId = model.CategoryId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            var viewmodel = new BooksFormViewModels
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                CategoryId = book.CategoryId,
                Categories = _context.Categories
                    .Where(c => c.IsActive)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToList()
            };

            return View("Create", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(b => b.Category)
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

    }
}
