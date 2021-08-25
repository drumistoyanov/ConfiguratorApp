using ConfiguratorApp.DataAccessLayer.DataAccess;
using ConfiguratorApp.DataAccessLayer.Models;
using ConfiguratorApp.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConfiguratorApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConfiguratorAppDbContext _context;


        public HomeController(ILogger<HomeController> logger, ConfiguratorAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ComponentViewModel> components = _context.Components.Select(c => new ComponentViewModel() { Id = c.ID, Model = c.Model, Name = c.Name, Picture = c.Picture, Price = c.Price, Type = c.Type, Count = c.Count }).ToList();

            ViewData["ItemsWithPrices"] = _context.Components.ToDictionary(c => c.ID, c => c.Price);
            ViewData["Components"] = components;
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewConfiguration(PCModel model)
        {
            if (!ModelState.IsValid)
            {
                List<ComponentViewModel> components = _context.Components.Select(c => new ComponentViewModel() { Id = c.ID, Model = c.Model, Name = c.Name, Picture = c.Picture, Price = c.Price, Type = c.Type }).ToList();

                ViewData["ItemsWithPrices"] = _context.Components.ToDictionary(c => c.ID, c => c.Price);
                ViewData["Components"] = components;
                return View("Index", model);
            }
            List<ComputerComponents> listComponents = new List<ComputerComponents>();
            Computer pc = new Computer()
            {
                CreatedOn = DateTime.Now
            };

            _context.Add(pc);
            _context.SaveChanges();
            pc = _context.Computers.ToList().LastOrDefault();

            listComponents.Add(new ComputerComponents() { ComponentId = int.Parse(model.CaseId), ComputerId = pc.ID });
            listComponents.Add(new ComputerComponents() { ComponentId = int.Parse(model.CoolingId), ComputerId = pc.ID });
            listComponents.Add(new ComputerComponents() { ComponentId = int.Parse(model.CPUId), ComputerId = pc.ID });
            listComponents.Add(new ComputerComponents() { ComponentId = int.Parse(model.RAMId), ComputerId = pc.ID });
            listComponents.Add(new ComputerComponents() { ComponentId = int.Parse(model.GPUId), ComputerId = pc.ID });
            listComponents.Add(new ComputerComponents() { ComponentId = int.Parse(model.MotherboardId), ComputerId = pc.ID });
            listComponents.Add(new ComputerComponents() { ComponentId = int.Parse(model.PSUId), ComputerId = pc.ID });
            listComponents.Add(new ComputerComponents() { ComponentId = int.Parse(model.StorageDeviceId), ComputerId = pc.ID });

            _context.AddRange(listComponents);
            _context.SaveChanges();


            List<int> listCompId = new List<int>()
            {
                int.Parse(model.CaseId),
                int.Parse(model.CoolingId),
                int.Parse(model.CPUId),
                int.Parse(model.RAMId),
                int.Parse(model.GPUId),
                int.Parse(model.MotherboardId),
                int.Parse(model.PSUId),
                int.Parse(model.StorageDeviceId),
            };
            IQueryable<Component> componentsToUpdate = _context.Components.Where(c => listCompId.Contains(c.ID));
            decimal price = componentsToUpdate.Sum(x => x.Price);
            pc.Price = price;

            foreach (Component item in componentsToUpdate)
            {
                item.Count--;
            }
            _context.UpdateRange(componentsToUpdate);
            _context.Update(pc);

            _context.SaveChanges();


            return RedirectToAction("BuiltComputers");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BuiltComputers()
        {
            List<Computer> pcs = _context.Computers.ToList();
            List<Component> components = _context.Components.ToList();
            List<ComputerComponents> computerComponents = _context.ComputerComponents.ToList();
            List<ReadyPcModel> listPcs = new List<ReadyPcModel>();

            foreach (Computer item in pcs)
            {
                List<int> ids = computerComponents.Where(p => p.ComputerId == item.ID).Select(x => x.ComponentId).ToList();
                ReadyPcModel pc = new ReadyPcModel()
                {
                    Components = components.Where(c => ids.Contains(c.ID)).ToList(),
                    DateCreated = item.CreatedOn,
                    Id = item.ID,
                    Price = item.Price
                };
                listPcs.Add(pc);

            }
            return View(listPcs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
