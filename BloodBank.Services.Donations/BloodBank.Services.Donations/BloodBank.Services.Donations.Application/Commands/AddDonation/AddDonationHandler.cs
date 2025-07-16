using BloodBank.Services.Donations.Application.ViewModels;
using BloodBank.Services.Donations.Application.ViewModels.IntegrationViewModel;
using BloodBank.Services.Donations.Core.Entities;
using BloodBank.Services.Donations.Core.Repositories;
using BloodBank.Services.Donations.Infra.MessageBus;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.Commands.AddDonation;

public class AddDonationHandler : IRequestHandler<AddDonation, ResultViewModel<Guid>>
{

    private readonly IDonationRepository _donationRepository;
    private readonly IMessageBusClient _messageBus;

    public AddDonationHandler(IDonationRepository donationRepository, IMessageBusClient messageBus)
    {
        _donationRepository = donationRepository;
        _messageBus = messageBus;
    }

    public async Task<ResultViewModel<Guid>> Handle(AddDonation request, CancellationToken cancellationToken)
    {

        var httpClient = new HttpClient();

        var result = await httpClient.GetAsync($"https://localhost:7032/api/donors/{request.DonorId}");

        if(!result.IsSuccessStatusCode) return ResultViewModel<Guid>.Error("Donor not found");

        var stringResult = await result.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<JObject>(stringResult);

        var donorViewModel = response["data"].ToObject<GetDonorByIdViewModel>();

        var donation = request.ToEntity();

        if(donation.Donor.FullName != donorViewModel.Fullname)
        {
            //futuramente adicionar evento de update
            donation.Donor = new Donor(donorViewModel.Fullname);
        }

        foreach (var @event in donation.Events)
        {
            var routingKey = @event.GetType().Name.ToDashCase();

            await _messageBus.PublishAsync(@event, routingKey, "donation-service");
        }

        await _donationRepository.Add(donation);

        return ResultViewModel<Guid>.Sucess(donation.Id);
    }
}
