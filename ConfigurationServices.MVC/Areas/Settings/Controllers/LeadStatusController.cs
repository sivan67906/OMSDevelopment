using ConfigurationServices.CQRS.MVC.Areas.Settings.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationServices.CQRS.MVC.Areas.Settings.Controllers
{
    [Area("Settings")]
    public class LeadStatusController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LeadStatusController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string searchQuery = null)
        {
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            //var productList = await client.GetFromJsonAsync<List<ProductVM>>("Product/GetAll");

            List<LeadStatusVM> productList;

            if (string.IsNullOrEmpty(searchQuery))
            {
                // Fetch all products if no search query is provided
                productList = await client.GetFromJsonAsync<List<LeadStatusVM>>("LeadStatus/GetAll");
            }
            else
            {
                // Fetch products matching the search query
                productList = await client.GetFromJsonAsync<List<LeadStatusVM>>($"LeadStatus/SearchByName?name={searchQuery}");
            }
            ViewData["searchQuery"] = searchQuery; // Retain search query
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            LeadStatusVM product = new();
            return PartialView("_Create", product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeadStatusVM product)
        {
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            await client.PostAsJsonAsync<LeadStatusVM>("LeadStatus/Create", product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            var product = await client.GetFromJsonAsync<LeadStatusVM>("LeadStatus/GetById/?Id=" + Id);
            return PartialView("_Edit", product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LeadStatusVM product)
        {
            if (product.Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            await client.PutAsJsonAsync<LeadStatusVM>("LeadStatus/Update/", product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            var product = await client.GetFromJsonAsync<LeadStatusVM>("LeadStatus/GetById/?Id=" + Id);
            return PartialView("_Delete", product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(LeadStatusVM product)
        {
            if (product.Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            var productList = await client.DeleteAsync("LeadStatus/Delete?Id=" + product.Id);
            return RedirectToAction("Index");
        }
    }
}
