
namespace TorneoEntidades
{
    public abstract class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Habilidad { get; }      //entre 0 y 100
        public int Suerte { get; }
        public Jugador() 
        {
            Random random = new Random();
            this.Habilidad= random.Next(0, 101);
            this.Suerte = random.Next(1, 6);
        }
        public abstract decimal Puntaje();
    }
}
