using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Context;
using MinimalApi.Models.Entities;
using MinimalApi.Models.Valid;

namespace MinimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly MinimalApiContext _context;

        public UsuariosController(MinimalApiContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioDbSet()
        {
            return await _context.UsuarioDbSet.ToListAsync();
        }

        // GET: api/Usuarios/email&password
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string email, string password)
        {
            var usuario = await _context.UsuarioDbSet.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound("Usuario não encontrado!");
            }

            return usuario;
        }

        // PUT: api/Usuarios/email&password
        [HttpPut("{email}/{password}")]
        public async Task<IActionResult> PutUsuario(string email,string password, [FromBody] Usuario usuario)
        {
            var user = await _context.UsuarioDbSet.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("Usuario não encontrado!");
            }

            user.Email = usuario.Email;
            user.Password = usuario.Password;

            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            

            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var user = usuario;

            var cpfValid = IsValid.IsValidCPF(usuario.Cpf);
            if (cpfValid == false)
            {
                return BadRequest("Cpf Invalido! Você digitou letras!");
            }        

            _context.UsuarioDbSet.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = user.Id }, user);
        }

        // DELETE: api/Usuarios/email&password
        [HttpDelete("{email}/{password}")]
        public async Task<IActionResult> DeleteUsuario(string email,string password)
        {
            var user = await _context.UsuarioDbSet.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("Usuario não encontrado!");
            }

            _context.UsuarioDbSet.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
