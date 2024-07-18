using UnityEngine;

public class BigNumber
{
    public float SignificantDigits { get; set; }
    public int TensMultiplier { get; set; }

    public string GetStringValue()
    {
        return SignificantDigits.ToString("F2") + "e" + TensMultiplier;
    }

    public void AddToTotalValue(BigNumber amountToAdd)
    {
        
    }
}
