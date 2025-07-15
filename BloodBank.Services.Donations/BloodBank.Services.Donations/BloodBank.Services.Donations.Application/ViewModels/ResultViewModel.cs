using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.ViewModels;

public class ResultViewModel
{
    public ResultViewModel(bool isSucess = true, string message = "")
    {
        IsSucess = isSucess;
        Message = message;
    }

    public bool IsSucess { get; set; }
    public string Message { get; set; }

    public static ResultViewModel Sucess()
        => new();
    public static ResultViewModel Error(string message)
        => new(false, message);
}

public class ResultViewModel<T> : ResultViewModel
{
    public ResultViewModel(T? data, bool isSucess = true, string message = "")
        : base(isSucess, message)
    {
        Data = data;
    }

    public T? Data { get; private set; }

    public static ResultViewModel<T> Sucess(T data)
        => new(data);
    public static ResultViewModel<T> Error(string message)
        => new(default, false, message);
}
