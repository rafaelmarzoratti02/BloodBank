using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donors.Core.Interfaces;

public interface IMongoDbFactory
{
    IMongoDatabase GetDonorsDatabase();
    IMongoDatabase GetUsersDatabase();
}
