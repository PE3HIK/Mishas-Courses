
    public class ElementalDamage : Damage
    {
        public readonly ElementalDamageType type;
        
        public ElementalDamage( ElementalDamageType type, int amount, bool isPure = false) : base(amount, isPure)
        {
            this.type = type;
        }
    }
