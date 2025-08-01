using BloodBank.Services.Donors.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donors.Application.Queries.User;

public class GetUserById : IRequest<ResultViewModel<UserViewModel>>
{
    public Guid Id { get; set; }

    public GetUserById(Guid id)
    {
        Id = id;
    }
}
