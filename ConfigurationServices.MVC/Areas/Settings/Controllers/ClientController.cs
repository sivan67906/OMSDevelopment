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
        public async Task<IActionResult> Index(string searchQuery = null)
        {
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
            return PartialView("_Create", product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientVM product)
        {
            var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
            await client.PostAsJsonAsync<ClientVM>("Client/Create", product);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}
