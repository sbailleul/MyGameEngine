using Xunit;

namespace GameEngine.Tests.Characters
{
    public class NonPlayerCharacterShould
    {
        #region NumericTests
        [Theory]
        [HealthDamageData]
        [Trait("Category","NumericTests")]
        public void TakeDamage(int damage, int expectedHealth)
        {
            var sut = new NonPlayerCharacter();
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

        #endregion
       
    }
}