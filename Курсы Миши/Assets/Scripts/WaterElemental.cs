
    using System;

    public class WaterElemental : ElementalEnemy
    {
        public override ElementalDamageType elementalType
        {
            get => ElementalDamageType.Water;
        }

        protected override void ReceiveElementalDamage(ElementalDamage damage)
        {
            if (damage.type != ElementalDamageType.Fire)
            {
                base.ReceiveElementalDamage(damage);
            }
        }

        protected override void Move()
        {
            throw new NotImplementedException();
        }
    }
    
