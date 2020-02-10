using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests.Enemies
{
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public BossEnemyShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
        }

        #region NumericTests
        
        [Fact]
        [Trait("Category","NumericTests")]
        public void HaveCorrectPower()
        {
            _testOutputHelper.WriteLine("Creating Boss Enemy");
            var sut = new BossEnemy();
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, precision: 3);
        }
        

        #endregion
        
    }
}