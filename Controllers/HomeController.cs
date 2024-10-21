using System.Diagnostics;
using ASPNET6.Data;
using Microsoft.AspNetCore.Mvc;
using ASPNET6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET6.Controllers;

public class HomeController(Lb6DbContext context) : Controller
{

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        if (ModelState.IsValid)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return RedirectToAction("OrdersSpecifications", "Home");
        }

        Console.WriteLine(user.DateOfBirth + "  " + user.OrderVolume + "  " + user.Name + "  " + user.Orders);
        Console.WriteLine("Model invalid");
        return View(user);
    }

    
    
    [HttpGet]
    public IActionResult OrdersSpecifications()
    {
        var currentUser = context.Users.OrderByDescending(u => u.Id).FirstOrDefault();
        var products = new List<Product>();

        for (var i = 0; i < currentUser.OrderVolume; i++)
        {
            products.Add(new Product());
        }

        return View(products);
    }
    [HttpGet]
    public IActionResult DisplayOrders()
    {
        var currentUser = context.Users.OrderByDescending(u => u.Id).FirstOrDefault();
        var orders = context.Orders.Where(o => o.CustomerId == currentUser.Id)
            .Include(o=>o.Products)
            .ToList();
        ViewBag.ConfirmationMessage = "Your order has been placed successfully.";
        
        return View(orders);
    }
    
    [HttpPost]
    public async Task<IActionResult> DisplayOrders(List<Product> products)
    {
        var currentUser = context.Users.OrderByDescending(u => u.Id).FirstOrDefault();
        var order = new Order { CustomerId = currentUser.Id, Products = products };
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        
        return RedirectToAction("DisplayOrders", "Home");
    }
}