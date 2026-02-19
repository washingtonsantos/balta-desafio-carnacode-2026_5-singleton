using Singleton;
using Singleton.Services;

Console.WriteLine("=== Sistema de Configurações ===\n");

Console.WriteLine("Inicializando serviços...\n");

var dbService = new DatabaseService();
var apiService = new ApiService();
var cacheService = new CacheService();
var logService = new LoggingService();

Console.WriteLine("\nUsando os serviços...\n");

dbService.Connect();
apiService.MakeRequest();
cacheService.Connect();
logService.Log("Sistema iniciado");

Console.WriteLine("\n--- Tentativa de atualização ---\n");
var config1 = ConfigurationManager.Instance;
config1.LoadConfigurations();
config1.UpdateSetting("LogLevel", "Debug");

var config2 = ConfigurationManager.Instance;
config2.LoadConfigurations();
Console.WriteLine($"Config1 LogLevel: {config1.GetSetting("LogLevel")}");
Console.WriteLine($"Config2 LogLevel: {config2.GetSetting("LogLevel")}");
Console.WriteLine("Instâncias diferentes com valores idênticos!");