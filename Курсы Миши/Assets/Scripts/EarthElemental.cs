
    public class EarthElemental : ElementalEnemy
    {
        public override ElementalDamageType elementalType
        {
            get => ElementalDamageType.Earth;
        }

        protected override void Move()
        {
            throw new System.NotImplementedException();
        }
    }
    