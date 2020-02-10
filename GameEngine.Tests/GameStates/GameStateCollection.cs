using Xunit;

namespace GameEngine.Tests.GameStates
{
    [CollectionDefinition("GameState collection")]
    public class GameStateCollection : ICollectionFixture<GameStateFixture> { }
}