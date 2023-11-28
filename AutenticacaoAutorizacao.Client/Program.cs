using AutenticacaoAutorizacao.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.SessionStorage;
using AutenticacaoAutorizacao.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5161/") });

builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthProvider>();
builder.Services.AddScoped<IProdutosServices,ProdutosServices>();
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
