namespace Domain
{
    public interface IProp 
    {
        void ReceiveDamage(int amountDamage);

        int GetHp();
    }
}