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
            await Task.WhenAll(Task.Run(() => ServiceProvider.Install<IdentityService>(info)),
                Task.Run(() => ServiceProvider.Install<DocumentService>(info)),
                Task.Run(() => ServiceProvider.Install<WebApiService>(info)),
                Task.Run(() => ServiceProvider.Install<SchedulerService>(info)),
                Task.Run(() => ServiceProvider.Install<SignService>(info)),
                Task.Run(() => ServiceProvider.Install<StorageService>(info)),
                Task.Run(() => ServiceProvider.Install<EssService>(info)),
                Task.Run(() => ServiceProvider.Install<EssSite>(info)),
                Task.Run(() => ServiceProvider.Install<EssCLIService>(info)),
                Task.Run(() => ServiceProvider.Install<IdCLIService>(info)));
            Console.Write("Success");
        }
    }
}
