using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageDealer 
{
    void DealDamage(IDamageReceiver receiver); 
}
