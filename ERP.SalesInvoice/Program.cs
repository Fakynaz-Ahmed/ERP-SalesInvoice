using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ERP.SalesInvoice.Data;
using ERP.SalesInvoice.Forms;

namespace ERP.SalesInvoice
{
    internal static class Program
    {    
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();           
            ApplicationConfiguration.Initialize();
            var mainForm = host.Services.GetRequiredService<FrmAllInvoices>();
            Application.Run(mainForm);
        }
        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(
                            "Server=.;Database=ERPDb;Trusted_Connection=True;TrustServerCertificate=True"));

                    services.AddScoped<FrmInvoice>();
                    services.AddScoped<FrmAllInvoices>();
                });
    }
}