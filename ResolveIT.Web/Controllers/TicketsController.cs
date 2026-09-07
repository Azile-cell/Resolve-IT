using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using ResolveIT.Web.Models;

namespace ResolveIT.Web.Controllers;

public class TicketsController : Controller
{
    public IActionResult Index()
    {
        return View();
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
        
        return Content($"Ticket received: {ticket.Title}");
    }

}