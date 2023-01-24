using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Context;
using MinimalApi.Models.Dto;
using MinimalApi.Models.Entities;
using MinimalApi.Models.Valid;

namespace MinimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly MinimalApiContext _context;

        private readonly IMapper _mapper;

        public UsuariosController(MinimalApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioGetDto>>> GetUsuarioDbSet()
        {
            var usuario = await _context.UsuarioDbSet.ToListAsync();
            var userResponse = _mapper.Map<List<UsuarioGetDto>>(usuario);

            return Ok(userResponse);
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
        public async Task<IActionResult> PutUsuario(string email,string password, [FromBody] UsuarioPutDto usuarioPutDto)
        {
            var user = await _context.UsuarioDbSet.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("Usuario não encontrado!");
            }

            user.Nome = usuarioPutDto.Nome;
            user.SobreNome = usuarioPutDto.SobreNome;
            user.DataNascimento = usuarioPutDto.DataNascimento;
            user.Telefone = usuarioPutDto.Telefone;
            user.Password = usuarioPutDto.Password;

            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            

            return Ok("Dados alterados com sucesso!");
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> PostUsuario(UsuarioDto usuarioDto)
        {
            var cpfValid = IsValid.IsValidCPF(usuarioDto.Cpf);
            if (cpfValid == false)
            {
                return BadRequest("Cpf Invalido! Você digitou letras!");
            }
            if (await _context.UsuarioDbSet.AnyAsync(p => p.Cpf == usuarioDto.Cpf))
            {
                return Conflict("Cpf já cadastrado!.");
            }
            if (await _context.UsuarioDbSet.AnyAsync(p => p.Email == usuarioDto.Email))
            {
                return Conflict("Email já cadastrado!.");
            }

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            _context.UsuarioDbSet.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
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

            return Ok("Usuario Deletado com sucesso!");
        }
    }
}
