using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtlabAPI.Services;
using NewtlabAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace NewtlabAPI.Controllers
{
    [Route("newtlabapi/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("auth")]
        public IActionResult Authenticate(AuthenticationModel am)
        {
            var response = _userService.Authenticate(am.Username, am.Password);

            if (response == null)
                return BadRequest(new { message = "Usuario o contraseña incorrectos" });
            else if (!response.IsOn)
                return BadRequest(new { message = "Usuario ha sido desactivado" });

            return Ok(response);
        }

        [HttpGet("users")]
        public IActionResult GetAllWithRole()
        {
            List<object> returnable = new List<object>();
            var users = _userService.GetAllWithRole().ToList();
            foreach (var i in users)
            {
                returnable.Add(new
                {
                    UserId = i.UserId,
                    Username = i.Username,
                    Password = i.Password,
                    Role = i.Role.Description,
                    Name = i.Name,
                    LastName1 = i.LastName1,
                    LastName2 = i.LastName2,
                    Cedula = i.Cedula,
                    Phone = i.Phone,
                    Birth = i.Nacimiento.ToShortDateString(),
                    IsOn = i.IsOn,
                    matricula = i.Matricula,
                    grado = i.Grado,
                    seccion = i.Seccion
                });
            }
            return Ok(returnable);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var i = _userService.GetById(id);
            return Ok(new
            {
                UserId = i.UserId,
                Username = i.Username,
                Password = i.Password,
                Role = i.Role.Description,
                Name = i.Name,
                LastName1 = i.LastName1,
                LastName2 = i.LastName2,
                Cedula = i.Cedula,
                Phone = i.Phone,
                Birth = i.Nacimiento.ToShortDateString(),
                IsOn = i.IsOn,
                matricula = i.Matricula,
                grado = i.Grado,
                seccion = i.Seccion

            });
        }

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] User user)
        {
            if (user == null)
                return BadRequest(new { message = "Datos invalidos" });

            user = _userService.ValidateRole(user);
            _userService.Insert(user);

            return Ok(new { message = $"Exito. {user}" });
        }

        [HttpPut("modify")]
        public IActionResult Edit([FromBody] User user)
        {
            if (user == null)
                return BadRequest(new { message = "Datos invalidos" });
            user.IsOn = true;
            _userService.Modify(user);

            return Ok(new { message = $"Exito." });
        }

        [HttpPut("enable/{id}")]
        public IActionResult On(int id)
        {
            _userService.On(id);
            return Ok(new { message = $"Exito." });
        }

        [HttpPut("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = $"Exito." });
        }


        [HttpPost("insert/sesion")]
        public IActionResult InsertSesion([FromBody] Sesion s)
        {
            if (s == null)
                return BadRequest(new { message = "Datos invalidos" });

            _userService.InsertSesion(s);

            return Ok(new { message = $"Exito. {s}" });
        }

        [HttpGet("sesion")]
        public IActionResult GetSesion()
        {
           return Ok(_userService.GetSesion());
        }

        [HttpPut("sesion/on/{id}")]
        public IActionResult OnS(int id)
        {
            _userService.OnSesion(id);
            return Ok(new { message = $"Exito." });
        }

        [HttpPut("sesion/delete/{id}")]
        public IActionResult DeleteS(int id)
        {
            _userService.DeleteSesion(id);
            return Ok(new { message = $"Exito." });
        }
    }
}
