using BloodBank.Services.Donations.Application.Commands.AddDonation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application;

public static  class Extensions
{

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<AddDonation>();

        return services;
    }

    public static string ToDashCase(this string text)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }
        if (text.Length < 2)
        {
            return text;
        }
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));
        for (int i = 1; i < text.Length; ++i)
        {
            char c = text[i];
            if (char.IsUpper(c))
            {
                sb.Append('-');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

}
