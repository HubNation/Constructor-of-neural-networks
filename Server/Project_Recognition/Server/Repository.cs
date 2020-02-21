using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Server
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Networks { get; set; }
    }

    public class UserContext : DbContext
    {
        public UserContext() { }
        public DbSet<User> Users { get; set; }
    }

    public interface IRepository : IDisposable
    {
        IEnumerable<User> GetUsersList();
        void Add(User user);
        void Delete(int id);
        User GetUser(int id);
        void Save();
    }

    public class UsersRepository : IRepository
    {
        private UserContext userContext = new UserContext();
        private bool disposed = false;

        public void Add(User user)
        {
            userContext.Users.Add(user);
        }

        public void Delete(int id)
        {
            User user = userContext.Users.Find(id);
            if (user != null)
                userContext.Users.Remove(user);
        }

        public void Save()
        {
            userContext.SaveChanges();
        }

        public IEnumerable<User> GetUsersList()
        {
            return userContext.Users;
        }

        public User GetUser(int id)
        {
            return userContext.Users.Find(id);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
