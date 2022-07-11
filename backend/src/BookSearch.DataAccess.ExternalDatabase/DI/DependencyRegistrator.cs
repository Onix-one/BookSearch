using BookSearch.DataAccess.ExternalDatabase.HttpMessageHandlers;
using BookSearch.DataAccess.ExternalDatabase.Interfaces;
using BookSearch.DataAccess.ExternalDatabase.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace BookSearch.DataAccess.ExternalDatabase.DI
{
    public static class DependencyRegistrator
    {
        public static void AddDataAccessExternalDbComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MessageHandler>();

            services.AddHttpClient<IBookHttpService, BookHttpService>(client =>
                {
                    client.BaseAddress = new Uri(configuration["GoogleBookApiBaseUrl"]);
                }).AddHttpMessageHandler<MessageHandler>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(3));
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
        }
    }
}
