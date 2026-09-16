using Microsoft.AspNetCore.Mvc;
using ResolveIT.Web.Data;
using ResolveIT.Web.Models;

namespace ResolveIT.Web.Controllers;

public class TicketsController : Controller
{
    private readonly ResolveITDbContext _context;

    public TicketsController(ResolveITDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Ticket> tickets = _context.Tickets
            .OrderByDescending(ticket => ticket.CreatedAt)
            .ToList();

        return View(tickets);
    }

    public IActionResult Edit(int id)
    {
        Ticket? ticket = _context.Tickets.Find(id);

        if(ticket == null)
        {
            return NotFound();
        }

        return View(ticket);

    }

    [HttpPost]
    
public IActionResult Edit(Ticket updatedTicket)
{
    if (!ModelState.IsValid)
    {
        return View(updatedTicket);
    }

    Ticket? existingTicket =
        _context.Tickets.Find(updatedTicket.Id);

    if (existingTicket == null)
    {
        return NotFound();
    }

    existingTicket.Title = updatedTicket.Title;
    existingTicket.Description = updatedTicket.Description;
    existingTicket.Priority = updatedTicket.Priority;
    existingTicket.Status = updatedTicket.Status;

    _context.SaveChanges();

    return RedirectToAction("Index");
}

public IActionResult Details(int id)
{
    Ticket? ticket = _context.Tickets.Find(id);

    if (ticket == null)
    {
        return NotFound();
    }

    return View(ticket);
}

public IActionResult Delete(int id)
{
    Ticket? ticket = _context.Tickets.Find(id);

    if (ticket == null)
    {
        return NotFound();
    }

    return View(ticket);
}

[HttpPost]
public IActionResult DeleteConfirmed(int id)
{
    Ticket? ticket = _context.Tickets.Find(id);

    if (ticket == null)
    {
        return NotFound();
    }

    _context.Tickets.Remove(ticket);
    _context.SaveChanges();

    return RedirectToAction("Index");
}


public IActionResult Create()
    {
         return View();
    }
    [HttpPost]

public IActionResult Create(Ticket ticket)
    {
        if (!ModelState.IsValid)
        {
            return View(ticket);
        }

        _context.Tickets.Add(ticket);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}