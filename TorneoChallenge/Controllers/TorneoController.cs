using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorneoAplicacion.DTOs;
using TorneoAplicacion.DTOs.TorneoEntidades;
using TorneoEntidades;

namespace TorneoChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneoController : ControllerBase
    {
        private readonly TorneoContext _context;

        public TorneoController(TorneoContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("iniciarTorneoFemenino")]
        public IActionResult IniciarTorneoFemenino([FromBody] List<JugadorFemeninoDTO> jugadorFemeninosDTO)
        {
            if (jugadorFemeninosDTO == null || !jugadorFemeninosDTO.Any())
                return BadRequest("Debe haber jugadores para iniciar el torneo.");

            var jugadoresFemeninos = jugadorFemeninosDTO.Select(dto =>
                new JugadorFemenino(dto.Nombre, dto.TiempoReaccion)).ToList();
            var jugadores = jugadoresFemeninos.Cast<Jugador>().ToList();

            var torneo = new Torneo("Femenino", jugadores);
            var ganador = torneo.Comenzar();

            _context.Torneos.Add(torneo);
            _context.SaveChanges();

            torneo.GanadorId = ganador.Id; 

            _context.Torneos.Update(torneo);
            _context.SaveChanges();

            return Ok(new { Ganador = ganador.Nombre, TorneoId = torneo.Id });
        }

        [HttpPost]
        [Route("iniciarTorneoMasculino")]
        public IActionResult IniciarTorneoMasculino([FromBody] List<JugadorMasculinoDTO> jugadorMasculinosDTO)
        {
            if (jugadorMasculinosDTO == null || !jugadorMasculinosDTO.Any())
                return BadRequest("Debe haber jugadores para iniciar el torneo.");

            var jugadoresMasculinos = jugadorMasculinosDTO.Select(dto =>
                new JugadorMasculino(dto.Nombre, dto.Fuerza, dto.Velocidad)).ToList();
            var jugadores = jugadoresMasculinos.Cast<Jugador>().ToList();

            var torneo = new Torneo("Masculino", jugadores);
            var ganador = torneo.Comenzar();

            _context.Torneos.Add(torneo);
            _context.SaveChanges();

            torneo.GanadorId = ganador.Id;

            _context.Torneos.Update(torneo);
            _context.SaveChanges();

            return Ok(new { Ganador = ganador.Nombre, TorneoId = torneo.Id });
        }

        [HttpGet]
        [Route("resultados")]
        public IActionResult ObtenerResultados([FromQuery] DateTime? fecha, [FromQuery] string genero)
        {
            var query = _context.Torneos.AsQueryable();

            if (fecha.HasValue)
            {
                var fechaSinTiempo = fecha.Value.Date;
                query = query.Where(t => t.Fecha.Date == fechaSinTiempo);
            }

            if (!string.IsNullOrEmpty(genero))
            {
                query = query.Where(t => t.Genero == genero);
            }

            var torneos = query
                .Include(t => t.Jugadores)
                .ToList();

            return Ok(torneos);
        }
    }

}
