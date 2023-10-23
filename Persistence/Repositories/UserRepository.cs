using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;
using OnlineAuctionApplication.ViewModels;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddOrUpdateAsync(User user)
        {
            var existingUser = context.UserDbs.SingleOrDefault(e => e.Id == user.Id);

            if (existingUser == null)
            {
                context.UserDbs.Add(mapper.Map<UserDb>(user));
            }
            else
            {
                existingUser.Username = user.Username;
                existingUser.UserRole = user.UserRole;
                context.UserDbs.Update(existingUser);
            }

            await context.SaveChangesAsync();
        }

        public IEnumerable<User> GetAll()
        {
            var userDbs = context.UserDbs;
            var users = new List<User>();
            foreach (var u in userDbs)
            {
                users.Add(mapper.Map<User>(u));
            }
            return users;
        }

        public string GetRoleByUsername(string username)
        {
            var userDb = context.UserDbs.FirstOrDefault(u => u.Username == username) 
                ?? throw new InvalidOperationException();
            return userDb.UserRole;
        }

        public User GetUserById(string id)
        {
            var userDb = context.UserDbs.FirstOrDefault(u => u.Id == id);
            return mapper.Map<User>(userDb); 
        }

        public void Delete(string userId)
        {
            var user = context.UserDbs.Find(userId) ?? throw new InvalidOperationException();

            if (user != null)
            {
                context.UserDbs.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
