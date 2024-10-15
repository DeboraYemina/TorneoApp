

namespace TorneoEntidades
{
    public class Torneo
    {
        public int Id { get; set; }
        public string Genero { get; set; }
        public List<Jugador> Jugadores { get; set; }
        public int GanadorId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public Torneo()
        {
                
        }
        public Torneo(string genero, List<Jugador> jugadores)
        {
            Genero = genero; 
            Jugadores = jugadores;
        }
        public Jugador Comenzar()
        {
            List<Jugador> enCarrera = new List<Jugador>(Jugadores);

            while (enCarrera.Count>1)
            {
                List<Jugador> proximaRonda = new List<Jugador> ();
                for(int i=0;i<enCarrera.Count;i+=2)
                {
                    proximaRonda.Add(Partido(enCarrera[i], enCarrera[i + 1]));
                }
                enCarrera = proximaRonda;
            }
            GanadorId = enCarrera.First().Id;

            return enCarrera.First();
        }
        private Jugador Partido (Jugador uno, Jugador dos)
        {
            return uno.Puntaje() >= dos.Puntaje() ? uno : dos;
        }
    }    
}
