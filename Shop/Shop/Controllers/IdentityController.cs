using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models.Identity;
using Shop.Core.ServiceInterface;
using Shop.Core.Dto;
using Shop.Core.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


//public class IdentityController : Controller
//{
//    private readonly IIdentityService _identityService;
//    private readonly ShopContext _context;

//    public IdentityController(IIdentityService identityService, ShopContext context)
//    {
//        _identityService = identityService;
//        _context = context;
//    }


//    public IActionResult Index()
//    {
//        if (TempData.ContainsKey("RegistrationSuccessMessage"))
//        {
//            ViewBag.RegistrationSuccessMessage = TempData["RegistrationSuccessMessage"];
//            TempData.Clear(); 
//        }
//        return View();
//    }


//    public async Task<IActionResult> Register(IdentityModelView vm)
//    {
//        var dto = new IdentityDto
//        {
//            UserName = vm.UserName,
//            Email = vm.Email,
//            Password = vm.Password
//        };

//        var result = await _identityService.RegisterUserAsync(dto);

//        if (result != null)
//        {
//            // Registration was successful

//            // Manually set session variables for authentication
//            HttpContext.Session.SetString("UserName", result.UserName);
//            HttpContext.Session.SetString("Email", result.Email);

//            TempData["RegistrationSuccessMessage"] = "Registration successful!";
//            return RedirectToAction(nameof(Index));
//        }

//        return RedirectToAction(nameof(Index), vm);
//    }

//    public IActionResult Login(IdentityModelView vm)
//    {
//        // Validate user credentials (using your authentication logic)
//        if (IsValidCredentials(vm.UserName, vm.Password))
//        {
//            // Manually set session variables for authentication
//            HttpContext.Session.SetString("UserName", vm.UserName);
//            HttpContext.Session.SetString("Email", vm.Email);

//            TempData["LoginSuccessMessage"] = "Login successful!";
//            return RedirectToAction("Dashboard", "Home");
//        }
//        else
//        {
//            // If authentication fails, you might want to show an error message
//            TempData["LoginErrorMessage"] = "Invalid username or password";
//            return View(vm);
//        }
//    }

//    private bool IsValidCredentials(string userName, string password)
//    {
//        // Replace this with your actual authentication logic
//        // For example, check the credentials against your user database
//        // Return true if valid, false otherwise
//        // Ensure you handle password hashing and other security considerations
//        // This is a placeholder, replace it with your actual authentication logic
//        return true; // Replace with your logic
//    }







//}



