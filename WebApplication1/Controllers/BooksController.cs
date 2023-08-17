using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
private static List<Book> books = new List<Book>
{
    new Book { Id = 1, Title = "Journey to the Unknown", Author = "Alice Johnson", Price = 14.99M },
    new Book { Id = 2, Title = "The Last Mountain", Author = "Bob Smith", Price = 19.99M },
    new Book { Id = 3, Title = "Mysteries of the Deep", Author = "Charles Brown", Price = 13.99M },
    new Book { Id = 4, Title = "Winds of the North", Author = "Diana White", Price = 22.99M },
    new Book { Id = 5, Title = "Lost in the City", Author = "Ethan Green", Price = 11.99M },
    new Book { Id = 6, Title = "Chronicles of Time", Author = "Fiona Stewart", Price = 15.99M },
    new Book { Id = 7, Title = "Echoes from the Past", Author = "George Wallace", Price = 17.99M },
    new Book { Id = 8, Title = "Sands of the Desert", Author = "Hannah Clarke", Price = 16.99M },
    new Book { Id = 9, Title = "Whispers in the Night", Author = "Ian McEwan", Price = 20.99M },
    new Book { Id = 10, Title = "Guardians of the Forest", Author = "Jane Doe", Price = 21.99M },
    new Book { Id = 11, Title = "Echoes from the Abyss", Author = "Kevin Mason", Price = 13.99M },
    new Book { Id = 12, Title = "Frozen Memories", Author = "Laura Nolan", Price = 18.49M },
    new Book { Id = 13, Title = "Glimmers of Hope", Author = "Martin O'Reilly", Price = 16.49M },
    new Book { Id = 14, Title = "Labyrinths of the Mind", Author = "Nora Pinto", Price = 19.99M },
    new Book { Id = 15, Title = "Ripples in Reality", Author = "Oliver Quinn", Price = 15.59M },
    new Book { Id = 16, Title = "Dances with Dragons", Author = "Patricia Ramirez", Price = 17.99M },
    new Book { Id = 17, Title = "Visions of Venus", Author = "Quincy Roberts", Price = 14.89M },
    new Book { Id = 18, Title = "Stardust Chronicles", Author = "Rachel Stevens", Price = 20.99M },
    new Book { Id = 19, Title = "Whispers of Yesterday", Author = "Samuel Thompson", Price = 15.49M },
    new Book { Id = 20, Title = "Legends of the Last", Author = "Tina Underwood", Price = 19.49M },
    new Book { Id = 21, Title = "Gates of the Galaxy", Author = "Ulysses Vincent", Price = 14.39M },
    new Book { Id = 22, Title = "Shadows of Silence", Author = "Victoria Williams", Price = 16.79M },
    new Book { Id = 23, Title = "Mysteries of Mars", Author = "Walter Xavier", Price = 18.89M },
    new Book { Id = 24, Title = "Dunes of Destiny", Author = "Xena Yates", Price = 19.89M },
    new Book { Id = 25, Title = "Tales of Twilight", Author = "Yara Zimmerman", Price = 15.89M },
    new Book { Id = 26, Title = "Dreams of the Deep", Author = "Zane Anderson", Price = 17.59M },
    new Book { Id = 27, Title = "Songs of Saturn", Author = "Amelia Brown", Price = 20.39M },
    new Book { Id = 28, Title = "Light of the Lost", Author = "Charles Davidson", Price = 16.29M },
    new Book { Id = 29, Title = "Nightfall Nemesis", Author = "Danielle Evans", Price = 14.99M },
    new Book { Id = 30, Title = "Suns of Serendipity", Author = "Edward Fitzgerald", Price = 18.59M },
    new Book { Id = 31, Title = "Rains of Revolution", Author = "Felicia Garcia", Price = 15.39M },
    new Book { Id = 32, Title = "Mountains of Madness", Author = "Gregory Harris", Price = 17.89M },
    new Book { Id = 33, Title = "Valleys of Virtue", Author = "Isabelle Jackson", Price = 16.39M },
    new Book { Id = 34, Title = "Winds of War", Author = "Jonathan King", Price = 19.59M },
    new Book { Id = 35, Title = "Eclipses of Eternity", Author = "Liliana Lewis", Price = 15.79M },
    new Book { Id = 36, Title = "Stars of Solitude", Author = "Miguel Martinez", Price = 18.99M },
    new Book { Id = 37, Title = "Fires of Fate", Author = "Natalie Norton", Price = 14.69M },
    new Book { Id = 38, Title = "Moons of Mystery", Author = "Orlando Olson", Price = 19.29M },
    new Book { Id = 39, Title = "Oceans of Oblivion", Author = "Penelope Peterson", Price = 17.29M },
    new Book { Id = 40, Title = "Clouds of Courage", Author = "Quentin Quinn", Price = 18.79M },
    new Book { Id = 41, Title = "Rocks of Resilience", Author = "Rebecca Roberts", Price = 19.09M },
    new Book { Id = 42, Title = "Mists of Miracles", Author = "Steven Simmons", Price = 16.09M },
    new Book { Id = 43, Title = "Grains of Gravitas", Author = "Tatiana Torres", Price = 14.79M },
    new Book { Id = 44, Title = "Tides of Time", Author = "Ursula Underwood", Price = 19.89M },
    new Book { Id = 45, Title = "Flames of the Future", Author = "Vincent Vega", Price = 18.69M },
    new Book { Id = 46, Title = "Leaves of Legacy", Author = "Whitney Wilson", Price = 17.49M },
    new Book { Id = 47, Title = "Roots of the Rift", Author = "Xander Xion", Price = 16.89M },
    new Book { Id = 48, Title = "Bridges to Beyond", Author = "Yasmin Young", Price = 15.69M },
    new Book { Id = 49, Title = "Glaciers of the Gods", Author = "Zachary Zane", Price = 19.39M },
    new Book { Id = 50, Title = "Paths of Perseverance", Author = "Amber Adams", Price = 18.49M }
};


    // GET: api/books
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return books;
    }

    // GET: api/books/1
    [HttpGet("{id}")]
    public ActionResult<Book> GetBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return book;
    }

    // POST: api/books
    [HttpPost]
    public ActionResult<Book> PostBook(Book book)
    {
        book.Id = books.Max(b => b.Id) + 1; // For simplicity. In real-world scenarios, this would be auto-incremented by a database.
        books.Add(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    // PUT: api/books/1
    [HttpPut("{id}")]
    public IActionResult PutBook(int id, Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        var existingBook = books.FirstOrDefault(b => b.Id == id);
        if (existingBook == null)
        {
            return NotFound();
        }

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.Price = book.Price;

        return NoContent();
    }

    // DELETE: api/books/1
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        books.Remove(book);
        return NoContent();
    }
}
