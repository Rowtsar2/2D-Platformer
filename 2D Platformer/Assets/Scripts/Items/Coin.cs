using System;
using UnityEngine;

public class Coin : Item
{
    public int Price { get; private set; } = 10;
    
    public event Action<Coin> Taken;

    public override void Accept(ICollectorVisitor iCollector)
    {
        Taken?.Invoke(this);
        iCollector.Collect(this);
    }
}
