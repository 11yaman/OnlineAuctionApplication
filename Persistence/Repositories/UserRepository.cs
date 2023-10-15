using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAuctionApplication.Core.Models;
using OnlineAuctionApplication.Persistence.Entities;

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

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public async Task AddOrUpdateAsync(User user)
        {
            UserDb existingUser = context.UserDbs.Find(user.Id);

            if (existingUser == null)
            {
                context.UserDbs.Add(mapper.Map<UserDb>(user));
            }
            else
            {
                existingUser.Username = user.Username;
                context.UserDbs.Update(existingUser);
            }

            await context.SaveChangesAsync();
        }

        public User GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
