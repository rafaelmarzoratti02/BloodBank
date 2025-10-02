using BloodBank.Services.Donations.Application.ViewModels;
using BloodBank.Services.Donations.Application.ViewModels.IntegrationViewModel;
using BloodBank.Services.Donations.Core.Entities;
using BloodBank.Services.Donations.Core.Repositories;
using BloodBank.Services.Donations.Infra.MessageBus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.Commands.AddDonation;

public class AddDonationHandler : IRequestHandler<AddDonation, ResultViewModel<Guid>>
{

    private readonly IDonationRepository _donationRepository;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddDonationHandler(IDonationRepository donationRepository, IConfiguration configuration, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _donationRepository = donationRepository;
        _configuration = configuration;
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ResultViewModel<Guid>> Handle(AddDonation request, CancellationToken cancellationToken)
    {
        var exists = await DonorExists(request.DonorId);

        if(!exists) return ResultViewModel<Guid>.Error("Donor not found");
        
        var donation = request.ToEntity();

        foreach (var @event in donation.Events)
        {
            var routingKey = @event.GetType().Name.ToDashCase();

            Console.WriteLine("Donation completed");
        }

        await _donationRepository.Add(donation);
        
        return ResultViewModel<Guid>.Sucess(donation.Id);
    }

    public async Task<bool> DonorExists(Guid id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"{_configuration["GatewayBaseUrl"]}/donors/{id}");

        //request.Headers.Add("X-Gateway-Token", _configuration["InternalService:Token"]);

        var jwtToken = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

        request.Headers.Add("Authorization", jwtToken);

        var result = await _httpClient.SendAsync(request);

        if (!result.IsSuccessStatusCode)
        {
            throw new Exception("Donor not found");
        }

        var stringResult = await result.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<JObject>(stringResult);

        var donorViewModel = response["data"].ToObject<GetDonorByIdViewModel>();

        return donorViewModel != null;
    }
}
