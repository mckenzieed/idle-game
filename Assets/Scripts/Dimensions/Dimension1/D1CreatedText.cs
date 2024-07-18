using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class D1CreatedText : BaseText
{
    public override void UpdateText()
    {
        Text.text = PointManager.FormatNumber(PointManager.GetDimension1Created());
    }
}