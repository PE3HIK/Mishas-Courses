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

        Debug.Log(dealer);
        Death();
        
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

        var sign = damage.type == elementalType ? 1 : -1;

        Hp = Mathf.Clamp(Hp + damage.amount*sign, 0, 100);
        /*
        if (damage.type != elementalType)
        {
            Hp -= damage.amount;
            
        }else if (Hp < 100 )
        {
            Hp += damage.amount;
        }
        else if (Hp >= 100 )
        {
            Hp += damage.amount;
        }*/

    }

    private void Death()
    {
            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
    }
    

}