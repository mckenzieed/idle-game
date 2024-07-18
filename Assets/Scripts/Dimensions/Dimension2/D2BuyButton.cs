using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class D2BuyButton : DimensionButton
{
    public override bool ButtonIsLocked()
    {
        return !PointManager.CanAfford(PointManager.GetDimension2Cost());
    }

    public override void OnButtonPressed()
    {
        AddDimension2();
    }

    public void AddDimension2()
    {
        if (GetIsCoolingDown()) return;
        PointManager.BuyDimension2(BigInteger.One);
        StartCoroutine(Cooldown());
    }
}
