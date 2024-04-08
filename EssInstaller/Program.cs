using EasyESS;
using EasyESS.Services;
using EasyESS.Services.Document;
using EasyESS.Services.EssCLI;
using EasyESS.Services.EssService;
using EasyESS.Services.EssSite;
using EasyESS.Services.IdCLI;
using EasyESS.Services.IdentityService;
using EasyESS.Services.MessageBroker.Scheduler;
using EasyESS.Services.MessageBroker.WebApiService;
using EasyESS.Services.SignService;
using EasyESS.Services.Storage;
using Newtonsoft.Json;

namespace EssInstaller
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var text = File.ReadAllText(args[0]);
            var info = JsonConvert.DeserializeObject<InstallationInfo>(text);
            ServiceProvider.Install<IdentityService>(info);
            ServiceProvider.Install<DocumentService>(info);
            ServiceProvider.Install<WebApiService>(info);
            ServiceProvider.Install<SchedulerService>(info);
            ServiceProvider.Install<SignService>(info);
            ServiceProvider.Install<StorageService>(info);
            ServiceProvider.Install<EssService>(info);
            ServiceProvider.Install<EssSite>(info);
            ServiceProvider.Install<EssCLIService>(info);
            ServiceProvider.Install<IdCLIService>(info);
            Console.Write("Success");
        }
    }
}
