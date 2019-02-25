using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWasted.Data;
using TimeWasted.Models;

namespace TimeWasted.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new Users()
                {
                    UserId = model.UserId,
                    UserName = model.UserName,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Viewers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Viewers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserId = e.UserId,
                                    UserName = e.UserName,
                                    CreatedUtc = e.CreatedUtc
                                }
                                );

                return query.ToArray();
            }
        }

        public UserDetail GetUserById(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Viewers
                        .Single(e => e.UserId == UserId && e.OwnerId == _userId);
                return
                    new UserDetail
                    {
                        UserId = entity.UserId,
                        UserName = entity.UserName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Viewers
                        .Single(e => e.UserId == model.UserId && e.OwnerId == _userId);

                entity.UserId = model.UserId;
                entity.UserName = model.UserName;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Viewers
                        .Single(e => e.UserId == UserId && e.OwnerId == _userId);

                ctx.Viewers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}