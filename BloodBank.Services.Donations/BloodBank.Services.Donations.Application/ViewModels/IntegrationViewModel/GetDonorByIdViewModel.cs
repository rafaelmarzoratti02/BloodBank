﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.ViewModels.IntegrationViewModel;

public class GetDonorByIdViewModel
{
    public GetDonorByIdViewModel(Guid id, string fullname)
    {
        Id = id;
        Fullname = fullname;
    }

    public Guid Id { get; set; }
    public string Fullname { get; set; }
}
