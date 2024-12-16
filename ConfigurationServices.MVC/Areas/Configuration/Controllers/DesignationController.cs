using System.Text;
using System.Text.Json;
using ConfigurationServices.MVC.Areas.Configuration.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationServices.MVC.Areas.Configuration.Controllers;
[Area("Configuration")]
public class DesignationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DesignationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> Designation()
    {
        // Page Title
        ViewData["pTitle"] = "Designations Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Configuration";
        ViewData["bParent"] = "Designation";
        ViewData["bChild"] = "Designation";

        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var designationList = await client.GetFromJsonAsync<List<DesignationVM>>("Designation/GetAll");
        var companies = await client.GetFromJsonAsync<List<CompanyVM>>("Company/GetAll");
        var departments = await client.GetFromJsonAsync<List<DepartmentVM>>("Department/GetAll");
        ViewBag.CompanyList = companies;
        ViewBag.DepartmentList = departments;
        return View(designationList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        DesignationVM designation = new();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var companies = await client.GetFromJsonAsync<List<CompanyVM>>("Company/GetAll");
        var departments = await client.GetFromJsonAsync<List<DepartmentVM>>("Department/GetAll");
        ViewBag.CompanyList = companies;
        ViewBag.DepartmentList = departments;
        return PartialView("_Create", designation);
    }

    [HttpPost]
    public async Task<IActionResult> Create(DesignationVM designation)
    {
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        await client.PostAsJsonAsync<DesignationVM>("Designation/Create", designation);
        return RedirectToAction("Designation");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var designation = await client.GetFromJsonAsync<DesignationVM>("Designation/GetById/?Id=" + Id);
        var companies = await client.GetFromJsonAsync<List<CompanyVM>>("Company/GetAll");
        var departments = await client.GetFromJsonAsync<List<DepartmentVM>>("Department/GetAll");
        ViewBag.CompanyList = companies;
        ViewBag.DepartmentList = departments;
        return PartialView("_Edit", designation);
    }

    [HttpPost]
    public async Task<IActionResult> Update(DesignationVM designation)
    {
        if (designation.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        await client.PutAsJsonAsync<DesignationVM>("Designation/Update/", designation);
        return RedirectToAction("Designation");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var designation = await client.GetFromJsonAsync<DesignationVM>("Designation/GetById/?Id=" + Id);
        var companies = await client.GetFromJsonAsync<List<CompanyVM>>("Company/GetAll");
        var departments = await client.GetFromJsonAsync<List<DepartmentVM>>("Department/GetAll");
        ViewBag.CompanyList = companies;
        ViewBag.DepartmentList = departments;
        return PartialView("_Delete", designation);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(DesignationVM designation)
    {
        JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
        {
            WriteIndented = true
        };
        string forecastJson = JsonSerializer.Serialize<DesignationVM>(designation, options);

        if (designation.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var designationList = Deletewithresponse(client.BaseAddress.AbsoluteUri + "Designation/Delete", designation);
        return RedirectToAction("Designation");
    }

    public async Task<HttpResponseMessage> Deletewithresponse(string url, object entity)
    {
        using (var client = new HttpClient())
        {
            var json = JsonSerializer.Serialize(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
                Content = content
            };
            return await client.SendAsync(request);
        }
    }



}