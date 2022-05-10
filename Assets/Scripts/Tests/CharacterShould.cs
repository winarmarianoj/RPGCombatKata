using System.Collections;
using System.Collections.Generic;
using Domain;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CharacterShould
    {
        private Character _character;

        [SetUp]
        public void Setup()
        {
            _character = new Character();
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
        public void NotBeAbleToHealOtherAliveCharacterAboveMaxHP()
        {
            Character _target = new Character();
            _character.DealDamage(_target, 100);
            
            _character.Heal(_target, 300);

            Assert.AreEqual(1000, _target.hp);
        }
    }
}
