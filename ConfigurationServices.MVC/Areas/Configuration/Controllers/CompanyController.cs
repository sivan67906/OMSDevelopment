﻿using System.Text;
using System.Text.Json;
using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.MVC.Areas.Configuration.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationServices.MVC.Areas.Configuration.Controllers;
[Area("Configuration")]
public class CompanyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public CompanyController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> Company()
    {
        // Page Title
        ViewData["pTitle"] = "Companies Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Configuration";
        ViewData["bParent"] = "Company";
        ViewData["bChild"] = "Company";

        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var companyList = await client.GetFromJsonAsync<List<CompanyVM>>("Company/GetAll");

        return View(companyList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        CompanyVM company = new();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        ViewBag.BusinessTypes = await client.GetFromJsonAsync<List<BusinessTypeVM>>("BusinessType/GetAll");
        ViewBag.CategoryTypes = await client.GetFromJsonAsync<List<CategoryVM>>("Category/GetAll");
        return PartialView("_Create", company);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CompanyVM company)
    {
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        await client.PostAsJsonAsync<CompanyVM>("Company/Create", company);
        return RedirectToAction("Company");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        ViewBag.BusinessTypes = await client.GetFromJsonAsync<List<BusinessTypeVM>>("BusinessType/GetAll");
        ViewBag.CategoryTypes = await client.GetFromJsonAsync<List<CategoryVM>>("Category/GetAll");
        var company = await client.GetFromJsonAsync<CompanyVM>("Company/GetById/?Id=" + Id);
        return PartialView("_Edit", company);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CompanyVM company)
    {
        if (company.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        await client.PutAsJsonAsync<CompanyVM>("Company/Update/", company);
        return RedirectToAction("Company");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        ViewBag.BusinessTypes = await client.GetFromJsonAsync<List<BusinessTypeVM>>("BusinessType/GetAll");
        ViewBag.CategoryTypes = await client.GetFromJsonAsync<List<CategoryVM>>("Category/GetAll");
        var company = await client.GetFromJsonAsync<CompanyVM>("Company/GetById/?Id=" + Id);
        return PartialView("_Delete", company);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(CompanyVM company)
    {
        JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
        {
            WriteIndented = true
        };
        string forecastJson = JsonSerializer.Serialize<CompanyVM>(company, options);

        if (company.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ConfigurationServicesApiCall");
        var companyList = Deletewithresponse(client.BaseAddress.AbsoluteUri + "Company/Delete", company);
        return RedirectToAction("Company");
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