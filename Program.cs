var builder = WebApplication.CreateBuilder(args);

// 添加 MVC 服务
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 配置 HTTP 请求管道
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// 关键：启用静态文件，这样你的 CSS 才能生效
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 配置默认路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();