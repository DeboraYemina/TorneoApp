using TorneoEntidades;
using Xunit;

namespace TorneoUnitTest
{
    public class TorneoTests
    {
        [Fact]
        public void TorneoMasculino()
        {
            // Arrange
            var jugadores = new List<Jugador>()
            {
                new JugadorMasculino("Uno", 2.5m, 3),
                new JugadorMasculino("Dos", 2, 0.2m),
                new JugadorMasculino("Tres", 1.5m, 2.12m),
                new JugadorMasculino("Cuatro", 0.5m, 3.2m),
                new JugadorMasculino("Cinco", 2.2m, 2.3m),
                new JugadorMasculino("Seis", 2.3m, 1.2m),
                new JugadorMasculino("Siete", 1.2m, 1.8m),
                new JugadorMasculino("Ocho", 0.9m, 2)
             };

            var torneo = new Torneo("Masculino", jugadores);

            // Act
            var ganador = torneo.Comenzar();

            // Assert
            Assert.NotNull(ganador);
            Assert.Contains(ganador, jugadores);
            Assert.True(ganador.Id == torneo.GanadorId);
        }

        [Fact]
        public void TorneoFemenino()
        {
            var jugadores = new List<Jugador>()
            {
                new JugadorFemenino("Uno", 1.2m),
                new JugadorFemenino("Dos", 0.2m),
                new JugadorFemenino("Tres", 1.3m),
                new JugadorFemenino("Cuatro", 2),
                new JugadorFemenino("Cinco", 2.3m),
                new JugadorFemenino("Seis", 0.5m),
                new JugadorFemenino("Siete", 1.8m),
                new JugadorFemenino("Ocho", 1)
            };

            var torneo = new Torneo("Femenino", jugadores);

            // Act
            var ganador = torneo.Comenzar();

            // Assert
            Assert.NotNull(ganador);
            Assert.Contains(ganador, jugadores);
            Assert.True(ganador.Id == torneo.GanadorId);
        }
    }
}
