using System.Collections;
using System.Collections.Generic;
using Domain;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CharacterShould
    {
        private Character _character;
        private IClass _warrior;
        private IClass _archer;
        [SetUp]
        public void Setup()
        {
            _character = new Character();
            _warrior = Substitute.For<IClass>();
            _archer = Substitute.For<IClass>();
            _warrior.GetRange().Returns(2);
            _archer.GetRange().Returns(20);
        }

        [Test]
        public void StartWith1000hp()
        {
            int result = _character.hp;
            
            Assert.AreEqual(1000, result);
        }

        [Test]
        public void StartLevelOne()
        {
            int result = _character.level;
            
            Assert.AreEqual(1, result);
        }

        [Test]
        public void StartAlive()
        {
            bool result = _character.isAlive;

            Assert.IsTrue(result); 
        }
        
        [Test]
        public void BeAbleToDealDamage()
        {
            Character _target = new Character();
            _character.DealDamage(_target, 50);

            Assert.AreEqual(950, _target.hp); 
        }
        
        [Test]
        public void DieWhenNoHpLeft()
        {
            Character _target = new Character();
            _character.DealDamage(_target, 1000);

            Assert.IsFalse(_target.isAlive); 
        }
        
        [Test]
        public void NotBeAbleToHealOtherDeadCharacter()
        {
            Character _target = new Character();
            _character.DealDamage(_target, 1000);
            
            _character.Heal(_target, 50);

            Assert.AreEqual(0, _target.hp);
        }
        
        [Test]
        public void NotBeAbleToHealCharacterAboveMaxHP()
        {
            Character target = new Character();
            target.DealDamage(_character, 100);
            
            _character.Heal(_character, 300);

            Assert.AreEqual(1000, target.hp);
        }

        [Test]
        public void NotBeAbleToDamageItself()
        {
            _character.DealDamage(_character, 1000);
            
            Assert.AreEqual(1000, _character.hp);
        }

        [Test]
        public void NotBeAbleToHealOthers()
        {
            Character target = new Character();
            _character.DealDamage(target, 500);
            _character.Heal(target, 500);
            
            Assert.AreEqual(500, target.hp);
        }

        [Test]
        public void DealLessDamageToStrongerTarget()
        {
            Character target = new Character();
            target.level = 6;
            _character.DealDamage(target, 500);
            
            Assert.AreEqual(750, target.hp);
        }

        [Test]
        public void DealMoreDamageToWeakerTarget()
        {
            Character target = new Character();
            _character.level = 6;
            _character.DealDamage(target, 500);
            
            Assert.AreEqual(250, target.hp);
        }

        
        [Test]
        public void HaveRangeBasedOnItsClass()
        {
            _character.SetClass(_warrior);
            Character secondCharacter = new Character();
            secondCharacter.SetClass(_archer);
            
            Assert.AreEqual(_warrior.GetRange(), _character.GetRange());
            Assert.AreEqual(_archer.GetRange(), secondCharacter.GetRange());
        }

        [Test]
        public void NotBeAbleToDealDamageIfNotInRange()
        {
            _character.SetClass(_warrior);
            Character target = new Character();
            target.SetPosition(4);

            
            _character.DealDamage(target, 500);
            
            Assert.AreEqual(1000, target.hp);
        }

        [Test]
        public void BeAbleToDealDamageIfInRange()
        {
            _character.SetClass(_archer);
            Character target = new Character();
            target.SetPosition(16);

            _character.DealDamage(target, 500);
            
            Assert.AreEqual(500, target.hp);
        }

    }
}
