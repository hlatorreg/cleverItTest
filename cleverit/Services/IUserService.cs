using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cleverit.Models;
using DalSoft.RestClient.DependencyInjection;
using DalSoft.RestClient.Handlers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace cleverit.Services
{
    public interface IUserService
    {
        Task<List<User>> Users();
        Task<User> Users(string id);
        Task<bool> UpdateUser(string id, User user);
        Task<bool> DeleteUser(string id);
        Task<bool> AddUser(User user);
    }
}