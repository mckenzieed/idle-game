using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class D3BuyButton : DimensionButton
{
    public override bool ButtonIsLocked()
    {
        return !PointManager.CanAfford(PointManager.GetDimension3Cost());
    }

    public override void OnButtonPressed()
    {
        AddDimension3();
    }

    public void AddDimension3()
    {
        if (GetIsCoolingDown()) return;
        PointManager.BuyDimension3(BigInteger.One);
        StartCoroutine(Cooldown());
    }
}
