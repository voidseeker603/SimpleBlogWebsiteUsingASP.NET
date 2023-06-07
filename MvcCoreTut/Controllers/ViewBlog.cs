using Microsoft.AspNetCore.Mvc;
using MvcCoreTut.Models.Domain;

public class BlogController : Controller
{
	private readonly DatabaseContext _context;

	public BlogController(DatabaseContext context)
	{
		_context = context;
	}

	// Other actions and code...

	[HttpGet("/Blog/ViewBlog/{id}")]
	public IActionResult ViewBlog(int id)
	{
		// Retrieve the blog with the specified ID from the database
		var blog = _context.Person.Find(id);

		if (blog == null)
		{
			// Blog not found, return appropriate response (e.g., 404)
			return NotFound();
		}

		return View(blog);
	}
}


