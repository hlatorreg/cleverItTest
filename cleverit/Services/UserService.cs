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
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;

namespace cleverit.Services
{
    public class UserService : IUserService
    {
        private readonly IRestClientFactory _restClientFactory;

        public UserService(IRestClientFactory restClientFactory)
        {
            _restClientFactory = restClientFactory;
        }

        [Route("User"), HttpGet]
        public async Task<List<User>> Users()
        {
            dynamic restClient = _restClientFactory.CreateClient();

            var users = await restClient.User.Get();

            List<User> usersList = new List<User>();

            foreach (var user in users)
            {
                var type = user.GetType();
                if (!type.IsGenericType)
                {
                    User u = JsonConvert.DeserializeObject<User>(user.ToString());
                    usersList.Add(u);

                }
                else
                {
                    foreach (var malformedUsers in user)
                    {
                        User u = JsonConvert.DeserializeObject<User>(malformedUsers.ToString());
                        usersList.Add(u);
                    }
                }
            }

            return usersList;
        }

        [Route("User"), HttpGet]
        public async Task<User> Users(string id)
        {
            dynamic restClient = _restClientFactory.CreateClient();
                    
            User user = await restClient.User.Get(id);

            return user;
        }

        [Route("User"), HttpPut]
        public async Task<bool> UpdateUser(string id, User user)
        {
            dynamic restClient = _restClientFactory.CreateClient();

            var response = await restClient.User(id).Put(user);

            return (int)response.HttpResponseMessage.StatusCode == 200;
        }

        [Route("User"), HttpDelete]
        public async Task<bool> DeleteUser(string id)
        {
            dynamic restClient = _restClientFactory.CreateClient();

            var response = await restClient.User(id).Delete();

            return (int)response.HttpResponseMessage.StatusCode == 200;
        }

        [Route("User"), HttpPost]
        public async Task<bool> AddUser(User user)
        {
            dynamic restClient = _restClientFactory.CreateClient();

            var response = await restClient.User.Post(user);

            return (int)response.HttpResponseMessage.StatusCode == 201;
        }
    }
}