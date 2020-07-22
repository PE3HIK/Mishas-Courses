using System;

public class AirElemental : ElementalEnemy
{
    public override ElementalDamageType elementalType
    {
        get => ElementalDamageType.Air;
    }
    

    protected override void Move()
    {
        throw new System.NotImplementedException();
    }
}