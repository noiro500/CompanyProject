namespace CompanyProject.API;

public class Program
{
    public static void Main(string[] args)
    {
#if DEBUG
        Thread.Sleep(5000);
#endif
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}