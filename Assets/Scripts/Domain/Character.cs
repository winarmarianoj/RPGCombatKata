using UnityEngine;

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
            target.ReceiveDamage(amount);
        }

        public void ReceiveDamage(int amountDamage)
        {
            hp = Mathf.Max(0, hp - amountDamage);
            if (hp == 0)
            {
                isAlive = false; 
            }
        }

        public void Heal(Character target, int amountHeal)
        {
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