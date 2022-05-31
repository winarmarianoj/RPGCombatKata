﻿using UnityEngine;

namespace Domain
{
    public class Character
    {
        public int hp;
        public int level;
        public bool isAlive;
        private const int STARTING_LEVEL = 1;
        private const int STARTING_HP = 1000;
        public Character()
        {
            hp = STARTING_HP;
            level = STARTING_LEVEL;
            isAlive = true;
        }

        public void DealDamage(Character target, int amount)
        {
            if (target == this) return;
            target.ReceiveDamage(this, amount);
        }

        public void ReceiveDamage(Character fromCharacter, int amountDamage)
        {
            if (IsTargetStronger(fromCharacter))
            {
                amountDamage = Mathf.CeilToInt(amountDamage * 0.5f);
            }
            
            if(IsTargetWeaker(fromCharacter))
            {
                amountDamage = Mathf.CeilToInt(amountDamage * 1.5f);
            } 
            
            hp = Mathf.Max(0, hp - amountDamage);
            if (hp == 0)
            {
                isAlive = false; 
            }
        }

        private bool IsTargetWeaker(Character fromCharacter)
        {
            return fromCharacter.level - level >= 5;
        }

        private bool IsTargetStronger(Character fromCharacter)
        {
            return level - fromCharacter.level >= 5;
        }

        public void Heal(Character target, int amountHeal)
        {
            if(target!=this) return;
            
            if (target.isAlive)
            {
                target.ReceiveHeal(amountHeal);
            }
        }

        public void ReceiveHeal(int amountHeal)
        {
            hp = Mathf.Min(1000, hp + amountHeal);
        }
    }
}