using Consumer.ConsoleApp;
using Vax;

var services = new ServiceCollection();

services.AddSingleton<IConsoleWriter, ConsoleWriter>();
//services.AddSingleton<IIdGenerator, IdGenerator>();
//services.AddTransient<IIdGenerator, IdGenerator>();

//services.AddTransient<ConsoleWriter>();
//services.AddSingleton(new IdGenerator(new ConsoleWriter()));
services.AddSingleton(provider => new IdGenerator(provider.GetService<IConsoleWriter>()!));

var serviceProvider = services.BuildServiceProvider();

//var service = serviceProvider.GetService<IConsoleWriter>();
var service1 = serviceProvider.GetService<IdGenerator>();
var service2 = serviceProvider.GetService<IdGenerator>();

service1.PrintId();
service2.PrintId();