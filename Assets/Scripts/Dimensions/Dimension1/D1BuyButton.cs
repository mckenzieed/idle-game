using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class D1BuyButton : DimensionButton
{
    public override bool ButtonIsLocked()
    {
        return !PointManager.CanAfford(PointManager.GetDimension1Cost());
    }

    public override void OnButtonPressed()
    {
        AddDimension1();
    }

    public void AddDimension1()
    {
        if (GetIsCoolingDown()) return;
        PointManager.BuyDimension1(BigInteger.One);
        StartCoroutine(Cooldown());
    }
}