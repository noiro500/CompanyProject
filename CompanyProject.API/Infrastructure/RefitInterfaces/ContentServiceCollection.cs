using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using Microsoft.Extensions.Configuration;

namespace CompanyProject.API.Infrastructure.RefitInterfaces
{
    public static class ContentServiceCollection
    {

        public static IServiceCollection AddRefitCollection(this IServiceCollection services, string uri)
        {
            services.AddRefitClient<IContentServiceContent>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(uri);
                });
            services.AddRefitClient<IContentServiceCard>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(uri);
                });
            services.AddRefitClient<IContentServicePriceList>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(uri);
                });
            services.AddRefitClient<IContentServiceMessage>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri("http://localhost:5013/");
                });
            return services;
        }
    }
}
