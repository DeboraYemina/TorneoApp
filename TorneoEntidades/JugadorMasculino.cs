

namespace TorneoEntidades
{
    public class JugadorMasculino : Jugador
    {
        public decimal Velocidad { get; set; }
        public decimal Fuerza { get; set; }
        public override decimal Puntaje()
        {
            return Habilidad * Suerte * Velocidad * Fuerza;
        }
        public JugadorMasculino()
        {
                
        }
        public JugadorMasculino(string nombre, decimal velocidad, decimal fuerza):base()
        {
            base.Nombre = nombre;    
            this.Velocidad = velocidad;
            this.Fuerza = fuerza;
        }
    }
}
