using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests.GameStates
{
    [Collection("GameState collection")]
    public class SharedGameState2
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public SharedGameState2(GameStateFixture gameStateFixture, ITestOutputHelper testOutputHelper)
        {
            _gameStateFixture = gameStateFixture ?? throw new ArgumentNullException(nameof(gameStateFixture));
            _testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
        }

        [Fact]
        public void Test3()
        {
            _testOutputHelper.WriteLine($"GameState ID = {_gameStateFixture.State.Id}");   
        }
        
        [Fact]
        public void Test4()
        {
            _testOutputHelper.WriteLine($"GameState ID = {_gameStateFixture.State.Id}");   
        }
    }
}