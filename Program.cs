using ASP_MVC_Core_1.Models;
using  ASP_MVC_Core_1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddScoped<MemberReturn,Active>();

var app = builder.Build();
app.UseCustomMiddleWare();
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
    pattern: "/Nashtech/{controller=Rookies}/{action=Index}");

app.Run();
 public static class CustomMiddleWare
    {
        public static IApplicationBuilder UseCustomMiddleWare(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LoginMiddleWare>();
        }
    }
    
 public class LoginMiddleWare
 {   
        private readonly RequestDelegate _next;
        public LoginMiddleWare(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task Invoke(HttpContext context)
        {           
            var request = context.Request;           
            await _next(context);
            using (FileStream fileStream = new FileStream("Log.txt", FileMode.Append))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine("HTTPRequest Report: \n Schem: {0},\n Host: {1},\n Path: {2},\n QueryString: {3},\n Body: {4}", request.Scheme, request.Host, request.Path, request.QueryString, request.Body);
                streamWriter.Flush();
            }
            
        }
 }