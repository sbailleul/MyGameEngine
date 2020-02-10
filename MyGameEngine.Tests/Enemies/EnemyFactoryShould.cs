using System;
using Xunit;

namespace GameEngine.Tests.Enemies
{
    public class EnemyFactoryShould
    {
        #region TypeTests

        [Fact]
        [Trait("Category","TypeTests")]
        public void CreateNormalEnemyByDefault()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie");
            Assert.IsType<NormalEnemy>(enemy) ;
        }
        
        [Fact(Skip = "Don't need to run this")]
        [Trait("Category","TypeTests")]
        public void CreateNormalEnemyByDefault_NotType()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie");
            Assert.IsNotType<DateTime>(enemy) ;
        }
        
        [Fact]
        [Trait("Category","TypeTests")]
        public void CreateBossEnemy()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie King", true);
            Assert.IsType<BossEnemy>(enemy) ;
        }
        
        [Fact]
        [Trait("Category","TypeTests")]
        public void CreateBossEnemy_CastReturnedType()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie King", true);
            var boss = Assert.IsType<BossEnemy>(enemy); 
            Assert.Equal("Zombie King", boss.Name) ;
        }

        [Fact]
        [Trait("Category","TypeTests")]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie King", true);
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        #endregion

        #region RefTests

        [Fact]
        [Trait("Category","RefTests")]
        public void CreateSeparateInstances()
        {
            var sut = new EnemyFactory();
            var enemy1 = sut.Create("Zombie");
            var enemy2 = sut.Create("Zombie");
            Assert.NotSame(enemy1,enemy2);
        }
        #endregion
        
        #region ExceptionTests

        [Fact]
        [Trait("Category","ExceptionTests")]
        public void NotAllowNullName()
        {
            var sut = new EnemyFactory();
            Assert.Throws<ArgumentNullException>("name",()
                => sut.Create(null));
        }
        
        [Fact]
        [Trait("Category","ExceptionTests")]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            var sut = new EnemyFactory();
            var ex = Assert.Throws<EnemyCreationException>(()
                => sut.Create("Zombie Prince", true));
            Assert.Equal("Zombie Prince", ex.RequestedEnemyName);
        }
        
        #endregion
        
    }
}