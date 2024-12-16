using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.MVC.Areas.Configuration.ViewModels;
using ConfigurationServices.MVC.Areas.Settings.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationServices.MVC.Areas.Settings.Controllers
{
    [Area("Settings")]
    public class ClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Client(string searchQuery = null)
        {
            // Page Title
            ViewData["pTitle"] = "Client Profile";

            // Breadcrumb
            ViewData["bGParent"] = "Settings";
            ViewData["bParent"] = "Client";
            ViewData["bChild"] = "Client View";

            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            //var productList = await client.GetFromJsonAsync<List<ProductVM>>("Product/GetAll");

            List<ClientVM> productList;

            if (string.IsNullOrEmpty(searchQuery))
            {
                // Fetch all products if no search query is provided
                productList = await client.GetFromJsonAsync<List<ClientVM>>("Client/GetAll");
            }
            else
            {
                // Fetch products matching the search query
                productList = await client.GetFromJsonAsync<List<ClientVM>>($"Client/SearchByName?name={searchQuery}");
            }
            ViewData["searchQuery"] = searchQuery; // Retain search query
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ClientVM product = new();
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            ViewBag.Companies = await client.GetFromJsonAsync<List<Areas.Settings.ViewModels.CompanyVM>>("Company/GetAll");
            ViewBag.Countries = await client.GetFromJsonAsync<List<CountryVM>>("Country/GetAll");
            ViewBag.States = await client.GetFromJsonAsync<List<StateVM>>("State/GetAll");
            ViewBag.Cities = await client.GetFromJsonAsync<List<CityVM>>("City/GetAll");
            return PartialView("_Create", product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientVM product)
        {
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            await client.PostAsJsonAsync<ClientVM>("Client/Create", product);
            return RedirectToAction("Client");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            var product = await client.GetFromJsonAsync<ClientVM>("Client/GetById/?Id=" + Id);
            return PartialView("_Edit", product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClientVM product)
        {
            if (product.Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            await client.PutAsJsonAsync<ClientVM>("Client/Update/", product);
            return RedirectToAction("Client");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            var product = await client.GetFromJsonAsync<ClientVM>("Client/GetById/?Id=" + Id);
            return PartialView("_Delete", product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientVM product)
        {
            if (product.Id == 0) return View();
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            var productList = await client.DeleteAsync("Client/Delete?Id=" + product.Id);
            return RedirectToAction("Client");
        }
    }
}
