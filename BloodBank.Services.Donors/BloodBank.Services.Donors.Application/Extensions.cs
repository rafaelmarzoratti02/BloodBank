using System.Text;
using BloodBank.Services.Donors.Application.Commands;

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Services.Donors.Application;

public static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<AddDonor>());
        
        return services;
    }
    public static string ToDashCase(this string text)
    {
        if(text == null) {
            throw new ArgumentNullException(nameof(text));
        }
        if(text.Length < 2) {
            return text;
        }
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));
        for(int i = 1; i < text.Length; ++i) {
            char c = text[i];
            if(char.IsUpper(c)) {
                sb.Append('-');
                sb.Append(char.ToLowerInvariant(c));
            } else {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
    
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<AddDonor>();
        return services;
    }
    //public static IServiceCollection AddSubscribers(this IServiceCollection services)
    //{
    //    services.AddHostedService<DonationCreatedSubscriber>();

    //    return services;
    //}
}