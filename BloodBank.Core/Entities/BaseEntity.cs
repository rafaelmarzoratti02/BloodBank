﻿namespace BloodBank.Core.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }

    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public void SetAsDeleted()
    {
        IsDeleted = true;
    }
}