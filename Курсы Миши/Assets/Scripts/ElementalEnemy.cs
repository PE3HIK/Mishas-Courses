using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementalEnemy : Enemy, IDamageReceiver // двигается в любом направлении, не может атаковать 
{
    public abstract ElementalDamageType elementalType { get; }

    public void ReceiveDamage<T>(IDamageDealer dealer, T damage) where T : Damage
    {
        var periodoicDamage = damage as ElementalDamage;
        if (periodoicDamage != null)
        {
            ReceiveElementalDamage(periodoicDamage);
        }
        
        else
        {
            ReceivePhysicalDamage(damage); 
        }
    }

    protected void ReceivePhysicalDamage(Damage damage)
    {
        if (damage.isPure)
        {
            Hp -= damage.amount;
        }
        else
        {
            if (damage.amount - Armor > 0)
            {
                Hp -= damage.amount - Armor;
            }
        }
    }

    protected virtual void ReceiveElementalDamage(ElementalDamage damage)
    {
        if (damage.type != elementalType)
        {
            Hp -= damage.amount;
        }
        else
        {
            Hp += damage.amount;
        }
    }
}