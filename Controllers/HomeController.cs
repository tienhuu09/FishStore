using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishStore.Models;
using FishStore.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace FishStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly FishDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(FishDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var employee = await dbContext.Fish.ToListAsync();
            return View(employee);
        }

        public async Task<IActionResult> Data()
        {
            var employee = await dbContext.Fish.ToListAsync();
            return View(employee);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(FishViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Fish employee = new Fish
                {
                    Name = model.Name,
                    Genre = model.Genre,
                    Gender = model.Gender,
                    Price = model.Price,
                    ProfilePicture = uniqueFileName,
                };
                dbContext.Add(employee);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(FishViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}