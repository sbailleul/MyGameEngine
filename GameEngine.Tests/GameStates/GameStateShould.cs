using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests.GameStates
{
    public class GameStateShould: IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public GameStateShould(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture ?? throw new ArgumentNullException(nameof(gameStateFixture));
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _output.WriteLine($"GameState ID = {_gameStateFixture.State.Id}");
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();
            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameEngine.GameState.EarthquakeDamage;
            
            _gameStateFixture.State.Earthquake();
            
            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        public void Reset()
        {
            _output.WriteLine($"GameState ID = {_gameStateFixture.State.Id}");
            var p1 = new PlayerCharacter();
            var p2 = new PlayerCharacter();
            
            _gameStateFixture.State.Players.Add(p1);
            _gameStateFixture.State.Players.Add(p2);
            
            _gameStateFixture.State.Reset();
            
            Assert.Empty(_gameStateFixture.State.Players);
        }
    }
}