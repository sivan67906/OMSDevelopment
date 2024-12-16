using ConfigurationServices.MVC.Areas.Configuration.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationServices.MVC.Areas.Configuration.Controllers;
[Area("Configuration")]
public class RoleController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RoleController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> Role()
    {
        // Page Title
        ViewData["pTitle"] = "Roles Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Configuration";
        ViewData["bParent"] = "Role";
        ViewData["bChild"] = "Role";

        var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
        var roleList = await client.GetFromJsonAsync<List<RoleVM>>("Role/GetAll");
        return View(roleList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        RoleVM role = new();
        return PartialView("_Create", role);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoleVM role)
    {
        var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
        await client.PostAsJsonAsync<RoleVM>("Role/Create", role);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
        var role = await client.GetFromJsonAsync<RoleVM>("Role/GetById/?Id=" + Id);
        return PartialView("_Edit", role);
    }

    [HttpPost]
    public async Task<IActionResult> Update(RoleVM role)
    {
        if (role.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
        await client.PutAsJsonAsync<RoleVM>("Role/Update/", role);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
        var role = await client.GetFromJsonAsync<RoleVM>("Role/GetById/?Id=" + Id);
        return PartialView("_Delete", role);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(RoleVM role)
    {
        if (role.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
        await client.DeleteAsync("Role/Delete?Id=" + role.Id);
        return RedirectToAction("Role");
    }

    //[HttpPost]
    //public async Task<IActionResult> Delete(RoleVM role)
    //{
    //    JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
    //    {
    //        WriteIndented = true
    //    };
    //    string forecastJson = JsonSerializer.Serialize<RoleVM>(role, options);

    //    if (role.Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ConfigServicesApiCall");
    //    var roleList = Deletewithresponse(client.BaseAddress.AbsoluteUri + "Role/Delete", role);
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