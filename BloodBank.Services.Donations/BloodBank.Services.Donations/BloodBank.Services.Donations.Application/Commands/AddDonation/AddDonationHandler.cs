using BloodBank.Services.Donations.Application.ViewModels;
using BloodBank.Services.Donations.Application.ViewModels.IntegrationViewModel;
using BloodBank.Services.Donations.Core.Entities;
using BloodBank.Services.Donations.Core.Repositories;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.Commands.AddDonation;

public class AddDonationHandler : IRequestHandler<AddDonation, ResultViewModel<Guid>>
{

    private readonly IDonationRepository _donationRepository;

    public AddDonationHandler(IDonationRepository donationRepository)
    {
        _donationRepository = donationRepository;
    }

    public async Task<ResultViewModel<Guid>> Handle(AddDonation request, CancellationToken cancellationToken)
    {

        var httpClient = new HttpClient();

        var result = await httpClient.GetAsync($"https://localhost:7032/api/donors/{request.DonorId}");

        if(!result.IsSuccessStatusCode) return ResultViewModel<Guid>.Error("Donor not found");

        var stringResult = await result.Content.ReadAsStringAsync();

        var donorViewModel = JsonConvert.DeserializeObject<GetDonorByIdViewModel>(stringResult);

        var donation = request.ToEntity();

        if(donation.Donor.FullName != donorViewModel.Fullname)
        {
            //futuramente adicionar evento avisando
            donation.Donor = new Donor(donorViewModel.Id, donorViewModel.Fullname);
        }

        await _donationRepository.Add(donation);

        return ResultViewModel<Guid>.Sucess(donation.Id);
    }
}
