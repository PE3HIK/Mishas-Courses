
    using UnityEngine;

    
    public class Solder : Enemy, IDamageDealer, IDamageReceiver // может двигаться только по гор/вертикали 
    {

        public void DealDamage(IDamageReceiver receiver)
        {
            receiver.ReceiveDamage(this , new Damage(10, true));
        }

        public void ReceiveDamage<T>(IDamageDealer dealer, T damage) where T : Damage
        {
            var periodoicDamage = damage as ElementalDamage;
            if (periodoicDamage == null)
            {
                Hp -= damage.amount - Armor;
            }
            else
            {
                Hp -= periodoicDamage.amount;
            }
        }

        protected override void Move()
        {
            throw new System.NotImplementedException();
        }

        public void DealDamage<T>(IDamageReceiver receiver, T damage) where T : Damage
        {
        }
    }