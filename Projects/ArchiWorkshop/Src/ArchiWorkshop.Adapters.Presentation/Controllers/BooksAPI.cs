//using ArchiWorkshop.Adapters.Presentation.Abstractions.Controllers;
//using System.Linq.Expressions;
//using Microsoft.AspNetCore.Mvc;
//using System.Web.Http.Description;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using MediatR;

//namespace ArchiWorkshop.Adapters.Presentation.Controllers;

//public class Author
//{
//    public int AuthorId { get; set; }
//    [Required]
//    public string Name { get; set; }
//}

//public class Book
//{
//    public int BookId { get; set; }
//    [Required]
//    public string Title { get; set; }
//    public decimal Price { get; set; }
//    public string Genre { get; set; }
//    public DateTime PublishDate { get; set; }
//    public string Description { get; set; }
//    public int AuthorId { get; set; }
//    [ForeignKey("AuthorId")]
//    public Author Author { get; set; }
//}

//public class BookDto
//{
//    public string Title { get; set; }
//    public string Author { get; set; }
//    public string Genre { get; set; }
//}

//public class BookDetailDto
//{
//    public string Title { get; set; }
//    public string Genre { get; set; }
//    public DateTime PublishDate { get; set; }
//    public string Description { get; set; }
//    public decimal Price { get; set; }
//    public string Author { get; set; }
//}

//[System.Web.Http.RoutePrefix("api/books")]
//public class BooksController : ControllerBase
//{
//    //private BooksAPIContext db = new BooksAPIContext();

//    IList<Author> Authors = new List<Author>();
//    IList<Book> Books = new List<Book>();

//    // Typed lambda expression for Select() method. 
//    private static readonly Expression<Func<Book, BookDto>> AsBookDto =
//        x => new BookDto
//        {
//            Title = x.Title,
//            Author = x.Author.Name,
//            Genre = x.Genre
//        };

//    //public BooksController(ISender sender) : base(sender)
//    public BooksController()
//    {
//        Authors.Add(new Author() { AuthorId = 1, Name = "Ralls, Kim" });
//        Authors.Add(new Author() { AuthorId = 2, Name = "Corets, Eva" });
//        Authors.Add(new Author() { AuthorId = 3, Name = "Randall, Cynthia" });
//        Authors.Add(new Author() { AuthorId = 4, Name = "Thurman, Paula" });

//        Books.Add(
//        new Book()
//        {
//            BookId = 1,
//            Title = "Midnight Rain",
//            Genre = "Fantasy",
//            PublishDate = new DateTime(2000, 12, 16),
//            AuthorId = 1,
//            Description = "A former architect battles an evil sorceress.",
//            Price = 14.95M
//        });

//        Books.Add(
//        new Book()
//        {
//            BookId = 2,
//            Title = "Maeve Ascendant",
//            Genre = "Fantasy",
//            PublishDate = new DateTime(2000, 11, 17),
//            AuthorId = 2,
//            Description = "After the collapse of a nanotechnology society, the young" +
//                "survivors lay the foundation for a new society.",
//            Price = 12.95M
//        });

//        Books.Add(
//        new Book()
//        {
//            BookId = 3,
//            Title = "The Sundered Grail",
//            Genre = "Fantasy",
//            PublishDate = new DateTime(2001, 09, 10),
//            AuthorId = 2,
//            Description = "The two daughters of Maeve battle for control of England.",
//            Price = 12.95M
//        });

//        Books.Add(
//        new Book()
//        {
//            BookId = 4,
//            Title = "Lover Birds",
//            Genre = "Romance",
//            PublishDate = new DateTime(2000, 09, 02),
//            AuthorId = 3,
//            Description = "When Carla meets Paul at an ornithology conference, tempers fly.",
//            Price = 7.99M
//        });

//        Books.Add(
//        new Book()
//        {
//            BookId = 5,
//            Title = "Splish Splash",
//            Genre = "Romance",
//            PublishDate = new DateTime(2000, 11, 02),
//            AuthorId = 4,
//            Description = "A deep sea diver finds true love 20,000 leagues beneath the sea.",
//            Price = 6.99M
//        });
//    }

//    // GET api/Books
//    [Route("")]
//    public IQueryable<BookDto> GetBooks()
//    {
//        //return Books.Include(b => b.Author).Select(AsBookDto);
//        var BookDtos = new List<BookDto>
//        {
//            new BookDto()
//        };
//        return BookDtos.AsQueryable();
//    }

//    // GET api/Books/5
//    [Route("{id:int}")]
//    [ResponseType(typeof(BookDto))]
//    public async Task<IActionResult> GetBook(int id)
//    {
//        //BookDto book = await Books.Include(b => b.Author)
//        //    .Where(b => b.BookId == id)
//        //    .Select(AsBookDto)
//        //    .FirstOrDefaultAsync();
//        //if (book == null)
//        //{
//        //    return NotFound();
//        //}

//        await Task.CompletedTask;

//        BookDto book = new BookDto();

//        return Ok(book);
//    }

//    [Route("{id:int}/details")]
//    [ResponseType(typeof(BookDetailDto))]
//    public async Task<IActionResult> GetBookDetail(int id)
//    {
//        //var book = await (from b in Books.Include(b => b.Author)
//        //                  where b.AuthorId == id
//        //                  select new BookDetailDto
//        //                  {
//        //                      Title = b.Title,
//        //                      Genre = b.Genre,
//        //                      PublishDate = b.PublishDate,
//        //                      Price = b.Price,
//        //                      Description = b.Description,
//        //                      Author = b.Author.Name
//        //                  }).FirstOrDefaultAsync();

//        //if (book == null)
//        //{
//        //    return NotFound();
//        //}
//        await Task.CompletedTask;

//        BookDetailDto book = new BookDetailDto();

//        return Ok(book);
//    }

//    [Route("{genre}")]
//    public IQueryable<BookDto> GetBooksByGenre(string genre)
//    {
//        //return Books.Include(b => b.Author)
//        //    .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
//        //    .Select(AsBookDto);

//        var BookDtos = new List<BookDto>
//        {
//            new BookDto()
//        };
//        return BookDtos.AsQueryable();
//    }

//    [Route("~/api/authors/{authorId}/books")]
//    public IQueryable<BookDto> GetBooksByAuthor(int authorId)
//    {
//        //return Books.Include(b => b.Author)
//        //    .Where(b => b.AuthorId == authorId)
//        //    .Select(AsBookDto);
//        var BookDtos = new List<BookDto>
//        {
//            new BookDto()
//        };
//        return BookDtos.AsQueryable();
//    }

//    [Route("date/{pubdate:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]
//    [Route("date/{*pubdate:datetime:regex(\\d{4}/\\d{2}/\\d{2})}")]
//    public IQueryable<BookDto> GetBooks(DateTime pubdate)
//    {
//        //return Books.Include(b => b.Author)
//        //    .Where(b => DbFunctions.TruncateTime(b.PublishDate)
//        //        == DbFunctions.TruncateTime(pubdate))
//        //    .Select(AsBookDto);
//        var BookDtos = new List<BookDto>
//        {
//            new BookDto()
//        };
//        return BookDtos.AsQueryable();
//    }

//    //protected override void Dispose(bool disposing)
//    //{
//    //    Dispose();
//    //    base.Dispose(disposing);
//    //}
//}