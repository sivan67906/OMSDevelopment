var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("ConfigServicesApiCall", client =>
{
    client.BaseAddress = new Uri("http://localhost:5126/api/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "Configuration",
    pattern: "{area:exists}/{controller=Consumer}/{action=Index}/{id?}")
    .WithStaticAssets();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Login}/{action=Login}/{id:int?}")
//    .WithStaticAssets();

app.MapDefaultControllerRoute();

app.Run();