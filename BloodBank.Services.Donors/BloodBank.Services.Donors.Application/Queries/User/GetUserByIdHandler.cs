using BloodBank.Services.Donors.Application.ViewModels;
using BloodBank.Services.Donors.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donors.Application.Queries.User;

public class GetUserByIdHandler : IRequestHandler<GetUserById, ResultViewModel<UserViewModel>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<UserViewModel>> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            return ResultViewModel<UserViewModel>.Error("Usuário não existe!");
        }

        var model = UserViewModel.FromEntity(user);


        return ResultViewModel<UserViewModel>.Sucess(model);
    }
}
