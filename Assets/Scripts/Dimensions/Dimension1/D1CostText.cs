using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class D1CostText : BaseText
{
    public override void UpdateText()
    {
        Text.text = PointManager.FormatNumber(PointManager.GetDimension1Cost());
    }
}