using System;

namespace GameEngine.Tests.GameStates
{
    public class GameStateFixture: IDisposable
    {
        public GameEngine.GameState State { get; private set; } 

        public GameStateFixture()
        {
            State = new GameEngine.GameState();
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }
    }
}