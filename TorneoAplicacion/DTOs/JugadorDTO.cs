

using TorneoEntidades;

namespace TorneoAplicacion.DTOs
{
    namespace TorneoEntidades
    {
        public class JugadorDTO : Jugador
        {
            public JugadorDTO() : base() { }

            public override decimal Puntaje() => 0; 
        }
    }

}
