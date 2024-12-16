using ConfigurationServices.MVC.Areas.Configuration.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationServices.MVC.Areas.Configuration.Controllers;
[Area("Configuration")]
public class BusinessLocationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BusinessLocationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> BusinessLocation()
    {
        // Page Title
        ViewData["pTitle"] = "Business Locations Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Configuration";
        ViewData["bParent"] = "Business Location";
        ViewData["bChild"] = "Business Location";

        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var businessLocationList = await client.GetFromJsonAsync<List<BusinessLocationVM>>("BusinessLocation/GetAll");
        return View(businessLocationList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        BusinessLocationVM businessLocation = new();
        return PartialView("_Create", businessLocation);
    }

    [HttpPost]
    public async Task<IActionResult> Create(BusinessLocationVM businessLocation)
    {
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        await client.PostAsJsonAsync<BusinessLocationVM>("BusinessLocation/Create", businessLocation);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var businessLocation = await client.GetFromJsonAsync<BusinessLocationVM>("BusinessLocation/GetById/?Id=" + Id);
        return PartialView("_Edit", businessLocation);
    }

    [HttpPost]
    public async Task<IActionResult> Update(BusinessLocationVM businessLocation)
    {
        if (businessLocation.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        await client.PutAsJsonAsync<BusinessLocationVM>("BusinessLocation/Update/", businessLocation);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var businessLocation = await client.GetFromJsonAsync<BusinessLocationVM>("BusinessLocation/GetById/?Id=" + Id);
        return PartialView("_Delete", businessLocation);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(BusinessLocationVM businessLocation)
    {
        if (businessLocation.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        await client.DeleteAsync("BusinessLocation/Delete?Id=" + businessLocation.Id);
        return RedirectToAction("BusinessLocation");
    }

    //[HttpPost]
    //public async Task<IActionResult> Delete(BusinessLocationVM businessLocation)
    //{
    //    JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
    //    {
    //        WriteIndented = true
    //    };
    //    string forecastJson = JsonSerializer.Serialize<BusinessLocationVM>(businessLocation, options);

    //    if (businessLocation.Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
    //    var businessLocationList = Deletewithresponse(client.BaseAddress.AbsoluteUri + "BusinessLocation/Delete", businessLocation);
    //    return RedirectToAction("Index");
    //}

    //public async Task<HttpResponseMessage> Deletewithresponse(string url, object entity)
    //{
    //    using (var client = new HttpClient())
    //    {
    //        var json = JsonSerializer.Serialize(entity);
    //        var content = new StringContent(json, Encoding.UTF8, "application/json");

    //        var request = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Delete,
    //            RequestUri = new Uri(url),
    //            Content = content
    //        };
    //        return await client.SendAsync(request);
    //    }
    //}
}