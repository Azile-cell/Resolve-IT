using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using ResolveIT.Web.Models;

namespace ResolveIT.Web.Controllers;

public class TicketsController : Controller
{
    private static readonly List<Ticket> _tickets = new List<Ticket>();
    public IActionResult Index()
    {
        return View(_tickets);

    
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
        _tickets.Add(ticket);
         return RedirectToAction("Index");
        
    }
    

}