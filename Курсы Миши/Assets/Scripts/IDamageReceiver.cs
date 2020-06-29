using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageReceiver
{
    void ReceiveDamage <T> (IDamageDealer dealer, T damage) where T : Damage;
}