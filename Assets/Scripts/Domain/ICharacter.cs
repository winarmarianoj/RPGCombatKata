using System.Collections.Generic;
using Domain;

namespace Domain
{
    public interface ICharacter
    {
        void SetClass(IClass characterClass);
        void DealDamage(Character target, int amount);
        void ReceiveDamage(Character fromCharacter, int amountDamage);
        void Heal(Character target, int amountHeal);
        void ReceiveHeal(int amountHeal);
        int GetRange();
        void SetPosition(int posX);
        List<IFaction> GetFactionsList();
        void JoinFaction(IFaction faction);
        bool BelongToFaction(IFaction faction);
        bool IsAlly(Character target);
        
    }
}