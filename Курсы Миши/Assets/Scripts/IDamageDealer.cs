using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageDealer 
{
    void DealDamage<T>(IDamageReceiver receiver, T damage) where T : Damage;
}
