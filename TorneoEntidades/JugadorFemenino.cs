
namespace TorneoEntidades
{
    public class JugadorFemenino : Jugador
    {
        public decimal TiempoReaccion { get; set; }
        public JugadorFemenino()
        {
                
        }
        public JugadorFemenino(string nombre, decimal tiempoReaccion):base()
        {
            base.Nombre = nombre;
            this.TiempoReaccion = tiempoReaccion;
        }
        public override decimal Puntaje()
        {
            return Habilidad * Suerte * TiempoReaccion;
        }
    }
}
