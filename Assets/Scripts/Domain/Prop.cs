namespace Domain
{
    public class Prop : IProp
    {
        private int hp = 1000;
        
        public void ReceiveDamage(int amountDamage)
        {
            hp -= amountDamage;
        }

        public int GetHp()
        {
            return hp;
        }
    }
}