using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests.Characters
{
    public class PlayerCharacterShould: IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly PlayerCharacter _sut;

        public PlayerCharacterShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
            _testOutputHelper.WriteLine("Creating new PlayerCharacter");
            _sut = new PlayerCharacter();
        }
        
        public void Dispose()
        {
            _testOutputHelper.WriteLine($"Dispose {_sut.FullName}");
        }

        #region BoolTests

        [Fact]
        [Trait("Category","BoolTests")]
        public void BeInexperienceWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }

        #endregion

        #region StringTests

        [Fact]
        [Trait("Category","BoolTests")]
        public void CalculateFullName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", _sut.FullName);
        }
        
        [Fact]
        [Trait("Category","BoolTests")]
        public void HaveFullNameStartingWithFirstName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.StartsWith("Sarah", _sut.FullName);
        }
        
        [Fact]
        [Trait("Category","BoolTests")]
        public void HaveFullNameEndingWithLastName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.EndsWith("Smith", _sut.FullName);
        }
        
        [Fact]
        [Trait("Category","BoolTests")]
        public void CalculateFullName_IgnoreCase()
        {
            _sut.FirstName = "SARAH";
            _sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", _sut.FullName, ignoreCase: true);
        }
        
        [Fact]
        [Trait("Category","BoolTests")]
        public void CalculateFullName_Substring()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Contains("ah Sm", _sut.FullName);
        }
        
        [Fact]
        [Trait("Category","BoolTests")]
        public void CalculateFullNameWithTitleCase()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }

        #endregion

        #region NumericTests

        [Fact]
        [Trait("Category","NumericTests")]
        public void StartWithDefaultHealth()
        {
            
            Assert.Equal(100, _sut.Health);
        }
        
        [Fact]
        [Trait("Category","NumericTests")]
        public void StartWithDefaultHealth_NotEqual()
        {
            
            Assert.NotEqual(0, _sut.Health);
        }
        
        [Fact]
        [Trait("Category","NumericTests")]
        public void IncreaseHealthAfterSleeping()
        {
            _sut.Sleep();
            Assert.InRange(_sut.Health, 101,200);
        }
 
        [Theory]
        [HealthDamageData]
        [Trait("Category","NumericTests")]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, _sut.Health);
        }
        #endregion

        #region NullTests


        [Fact]
        [Trait("Category","NullTests")]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(_sut.Nickname);
        }

        #endregion
        
        #region CollectionTests

        [Fact]
        [Trait("Category","CollectionTests")]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }
        
        [Fact]
        [Trait("Category","CollectionTests")]
        public void NotHaveAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff of wonder", _sut.Weapons);
        }

        [Fact]
        [Trait("Category","CollectionTests")]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        [Trait("Category","CollectionTests")]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new List<string>
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };
            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        [Trait("Category","CollectionTests")]
        public void HaveNotEmptyDefaultWeapons()
        {
            Assert.All(_sut.Weapons, weapon 
                => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }
        
        #endregion

        #region EventTests

        [Fact]
        [Trait("Category","EventTests")]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                ()=>_sut.Sleep()
                );
        }
        
        [Fact]
        [Trait("Category","EventTests")]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(_sut, "Health", ()=>_sut.TakeDamage(10));
        }

        #endregion


    }
}