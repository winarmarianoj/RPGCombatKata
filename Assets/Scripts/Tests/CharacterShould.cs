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
    }
}
