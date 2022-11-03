using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication22_11_1.Data;
using WebApplication22_11_1.Models;
using WebApplication22_11_1.Services.Interfaces;




namespace WebApplication22_11_1.Controllers
{
    public class LunchesController : Controller
    {
        private ILunchService? _service;

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7246/api/Lunch/";

        public LunchesController(ILunchService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");
        }

        // Example: https://localhost:7246/api/Lunch/
        public async Task<IActionResult> Index()
        {
            var response = await _service.FindAll();

            return View(response);
        }

        // GET: VideoGame/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var lunch = await _service.FindOne(id);
            if (lunch == null)
            {
                return NotFound();
            }

            return View(lunch);
        }

        // GET: VideoGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGame/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CuisineId,RestaurantId, isHot, cost, isDelicious, isHealthy")] Lunch lunch)
        {
            lunch.Id = null;
            var resultPost = await client.PostAsync<Lunch>(requestUri, lunch, new JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET: VideoGame/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var lunch = await _service.FindOne(id);
            if (lunch == null)
            {
                return NotFound();
            }

            return View(lunch);
        }

        // POST: VideoGame/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CuisineId,RestaurantId, isHot, cost, isDelicious, isHealthy")] Lunch lunch)
        {
            if (id != lunch.Id)
            {
                return NotFound();
            }

            var resultPut = await client.PutAsync<Lunch>(requestUri + lunch.Id.ToString(), lunch, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }

        // GET: VideoGame/Delete/5
        public async Task<IActionResult> Delete(int id)

        {
            var lunch = await _service.FindOne(id);
            if (lunch == null)
            {
                return NotFound();
            }

            return View(lunch);
        }

        // POST: VideoGame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
