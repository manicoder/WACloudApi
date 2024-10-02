using Newtonsoft.Json;
using WhatsappBusiness.CloudApi.Configurations;
using WhatsappBusiness.CloudApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Formatting = Formatting.Indented;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});

builder.Services.Configure<WhatsAppBusinessCloudApiConfig>(options =>
{
    builder.Configuration.GetSection("WhatsAppBusinessCloudApiConfiguration").Bind(options);
});

WhatsAppBusinessCloudApiConfig whatsAppConfig = new WhatsAppBusinessCloudApiConfig();
whatsAppConfig.WhatsAppBusinessPhoneNumberId = "473703699156488";//builder.Configuration.GetSection("WhatsAppBusinessCloudApiConfiguration")["WhatsAppBusinessPhoneNumberId"];
whatsAppConfig.WhatsAppBusinessAccountId = "470601429462218";//builder.Configuration.GetSection("WhatsAppBusinessCloudApiConfiguration")["WhatsAppBusinessAccountId"];
whatsAppConfig.WhatsAppBusinessId = "1265828311254745"; //builder.Configuration.GetSection("WhatsAppBusinessCloudApiConfiguration")["WhatsAppBusinessId"];
whatsAppConfig.AccessToken = "EAARZCQ57WxtkBOZBpMfOH4lwPaYQhcHzZAQ6XI8mZBheJZAxjoERdrT6RBqf47nEaHUV9QiTeUHfJUM1v6vdYvJHJhhRIgixJgsJzTWBq3MVCsLUOfNk5dnx2PwU1wEvdFteFaTql5ETZC9BNdczEeVeXNo12suJUyOprZCmVbWCmeHHi6XHynEKmZA9wREQ9GZCuBImw2y0N9ZAV5jaxZC2oGZBtJhIkigwss9NXfHfkjIrLMkZD";//builder.Configuration.GetSection("WhatsAppBusinessCloudApiConfiguration")["AccessToken"];
whatsAppConfig.AppName = "WABussinessAPI";//builder.Configuration.GetSection("WhatsAppBusinessCloudApiConfiguration")["AppName"];
whatsAppConfig.Version = "v20.0";//builder.Configuration.GetSection("WhatsAppBusinessCloudApiConfiguration")["Version"];

builder.Services.AddWhatsAppBusinessCloudApiService(whatsAppConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();