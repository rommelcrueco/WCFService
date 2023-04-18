using System.Collections.Generic;
using System.Linq;
using WcfService.DAL.Entities;
using WcfService.Dto;
using WcfService.Interfaces;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private readonly WcfDatabaseContext _context = new WcfDatabaseContext();

        public void DeleteUser(int Id)
        {
            User entity = new User()
            {
                Id = Id
            };

            _context.User.Attach(entity);
            _context.User.Remove(entity);
            _context.SaveChangesAsync();
        }

        public List<UserDto> Get()
        {
            return _context.User.Select(
                u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Password = u.Password,
                    EnrollmentDate = u.EnrollmentDate
                }).ToList();
        }

        public UserDto GetUserById(int Id)
        {
            return _context.User.Select(
                u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Password = u.Password,
                    EnrollmentDate = u.EnrollmentDate
                })
                .FirstOrDefault(u => u.Id == Id);
        }

        public bool InsertUser(UserDto User)
        {
            User entity = new User()
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                Username = User.Username,
                Password = User.Password,
                EnrollmentDate = User.EnrollmentDate
            };

            _context.User.Add(entity);
            _context.SaveChangesAsync();

            return true;
        }

        public void UpdateUser(UserDto User)
        {
            User entity = _context.User.FirstOrDefault(s => s.Id == User.Id);

            entity.FirstName = User.FirstName;
            entity.LastName = User.LastName;
            entity.Username = User.Username;
            entity.Password = User.Password;
            entity.EnrollmentDate = User.EnrollmentDate;

            _context.SaveChangesAsync();
        }
    }
}
