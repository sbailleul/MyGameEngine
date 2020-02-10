using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests.GameStates
{
    [Collection("GameState collection")]
    public class SharedGameState1
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public SharedGameState1(GameStateFixture gameStateFixture, ITestOutputHelper testOutputHelper)
        {
            _gameStateFixture = gameStateFixture ?? throw new ArgumentNullException(nameof(gameStateFixture));
            _testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
        }

        [Fact]
        public void Test1()
        {
            _testOutputHelper.WriteLine($"GameState ID = {_gameStateFixture.State.Id}");   
        }
        
        [Fact]
        public void Test2()
        {
            _testOutputHelper.WriteLine($"GameState ID = {_gameStateFixture.State.Id}");   
        }
    }
}