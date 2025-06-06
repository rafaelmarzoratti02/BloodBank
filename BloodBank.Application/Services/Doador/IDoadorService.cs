﻿using BloodBank.Application.Models;
using BloodBank.Application.Models.DoadorModels;
using BloodBank.Core.Entities;

namespace BloodBank.Application.Services;

public interface IDoadorService
{
    // Task<DoadorDto> GetDoadorByIdAsync(int id);
    Task<ResultViewModel<List<DoadorItemViewModel>>> GetAllDoadores();
    Task<int> AddDoador(Doador doadorDto);
}