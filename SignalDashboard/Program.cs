using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
// Razor Pages 서비스 등록 필수
builder.Services.AddRazorPages();

// 고정 포트 5000으로 Listen (외부 접속 가능)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});

var app = builder.Build();

// 서버 실행(exe) 시 자동 브라우저 열기 (서버 PC에서만)
System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
{
    FileName = "http://localhost:5000",
    UseShellExecute = true
});

// 미들웨어 구성
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();