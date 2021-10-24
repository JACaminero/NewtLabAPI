using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewtlabAPI.Models;
using System.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using NewtlabAPI.Data;
using NewtlabAPI.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Newtonsoft.Json;

namespace NewtlabAPI.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(string username, string password);
        IEnumerable<User> GetAllWithRole();
        void Insert(User u);
        User GetByEmail(string email);
        User GetById(int id);
        void Modify(User u);
        User ValidateRole(User u);
        void Delete(int id);
        void On(int id);
    }
    
    public class UserService: IUserService
    {
        private readonly NewtLabContext db = new NewtLabContext();
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(string username, string password)
        {
            var user = GetAllWithRole().SingleOrDefault(x => x.Username == username && x.Password == password);

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAllWithRole()
        {
            var users = db.Users.ToList();
            var roles = db.Roles.ToList();
            return users.Join(roles,
                user => user.Role.RoleId,
                role => role.RoleId,
                (user, role) => new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password,
                    Role = role,
                    Name = user.Name,
                    LastName1 = user.LastName1,
                    LastName2 = user.LastName2,
                    Cedula = user.Cedula,
                    Phone = user.Phone,
                    Nacimiento = user.Nacimiento,
                    IsOn = user.IsOn,
                    Grado = user.Grado
                })
                .OrderByDescending(u => u.IsOn);
            }

        public User GetByEmail(string email)
        {
            return db.Users.FirstOrDefault(user => user.Username == email);
        }

        public User GetById(int id)
        {
            return GetAllWithRole().FirstOrDefault(u => u.UserId == id);
        }

        public void Insert(User us)
        {
            us.IsOn = true;
            db.Users.Add(us);
            db.SaveChanges();
        }

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("zhvyOBxiyOTZg+eBOMGRG4VAp86kGM1ZlL87Psby2JP6697VKKN9uyE/oRdHS4Nyy2FmqD9nrVipTpZ1nrOpH67rXSJkRZ8" +
                "mQ7GCNPaLHm+v/dH/4g5WAwAwyPLTfUuD55C7AFLxk8baedPQdTQd3V0R/kmbMDceMlGrwYF0+8XROAKR7CDHSDFdOffi8JwDVKWxw+XW7deEalQiH2RYB10MVhFJ" +
                "+AVKeTs39J4VPRziwmy0gKSNAUdqp3srMX1M1L7uopxP5usaER+uu1eZyxAX0PTT+1j8Nfiht5/iz9Tl4aWL0NFNz5N15nzoR4MTUz2DgA8e7e5scOzC3kAQYA==");
            var symkey = new SymmetricSecurityKey(key);
            var tokenDescriptor = new SecurityTokenDescriptor() 
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim("id", user.UserId.ToString()),
                    
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(symkey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User ValidateRole(User u)
        {
            switch (u.Role.Description)
            {
                case "Profesor":
                    u.Role = db.Roles.Find(2);
                    break;
                case "Estudiante":
                    u.Role = db.Roles.Find(1);
                    break;
                case "Admin":
                    u.Role = db.Roles.Find(4);
                    break;
            }
            return u;
        }

        public void Delete(int id)
        {
            var u = db.Users.Find(id);
            u.IsOn = false;
            db.SaveChanges();
        }
        public void On(int id)
        {
            var u = db.Users.Find(id);
            u.IsOn = true;
            db.SaveChanges();
        }

        public void Modify(User u)
        {
            var current = db.Users.Find(u.UserId);
            current.Username = u.Username;
            current.Name = u.Name;
            current.LastName1 = u.LastName1;
            current.LastName2 = u.LastName2;
            current.Cedula = u.Cedula;
            current.Phone = u.Phone;
            current.Nacimiento = u.Nacimiento;
            db.SaveChanges();
        }
    }
}
