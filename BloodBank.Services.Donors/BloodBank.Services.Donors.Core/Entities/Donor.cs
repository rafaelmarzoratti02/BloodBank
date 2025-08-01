﻿using BloodBank.Services.Donors.Core.Entities;
using BloodBank.Services.Donors.Core.Enums;
using BloodBank.Services.Donors.Core.Events;
using BloodBank.Services.Donors.Core.ValueObjects;

namespace BloodBank.Services.Donors.Core;

public class Donor : AggregateRoot
{
    public Donor(string fullname, string email, DateTime birthdate, Gender gender, double peso, BloodType bloodtype,
        RhFactor rhFactor, Address address, string userId) : base()
    {
        Fullname = fullname;
        Email = email;
        Birthdate = birthdate;
        Gender = gender;
        Weight = peso;
        BloodType = bloodtype;
        RhFactor = rhFactor;
        Address = address;
        UserId = userId;

        AddEvent(new DonorCreated(Id, Fullname, Email));
    }

    public string Fullname { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }
    public Gender Gender { get; set; }
    public double Weight { get; set; }
    public BloodType BloodType { get; set; }
    public RhFactor RhFactor { get; set; }
    public Address Address { get; set; }
    public string UserId { get; set; }
}