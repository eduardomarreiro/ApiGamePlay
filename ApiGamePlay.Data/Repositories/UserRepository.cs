using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces.IRepository;
using ApiGamePlay.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(GamePlayContext context) : base(context)
        {
            _context = context;
        }

        public User GetUser(string Username, string Password)
        {
            List<User> UsersList = new List<User>();
           
            return UsersList.FirstOrDefault(user => user.Username.ToLower() ==
            Username.ToLower() && user.Password.ToLower() == Password.ToLower());
        }

    }
}
