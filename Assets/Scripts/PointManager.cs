using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private static BigInteger _pointCount = 0;

    private static BigInteger _dimension1Count = 0;
    private static BigInteger _dimension1Created = 0;
    private static BigInteger _dimension1Bought = 0;
    private static BigInteger _dimension1Cost = 0;

    private static BigInteger _dimension2Count = 0;
    private static BigInteger _dimension2Created = 0;
    private static BigInteger _dimension2Bought = 0;
    private static BigInteger _dimension2Cost = 0;

    private static BigInteger _dimension3Count = 0;
    private static BigInteger _dimension3Created = 0;
    private static BigInteger _dimension3Bought = 0;
    private static BigInteger _dimension3Cost = 0;

    public static float _tickSpeedInSeconds = 1f;

    void Start()
    {
        //StartCoroutine(UpdatePoints());
    }

    public static BigInteger GetPointCount()
    {
        return _pointCount;
    }

    public static BigInteger GetDimension1Count()
    {
        return _dimension1Count;
    }

    public static BigInteger GetDimension1Created()
    {
        return _dimension1Created;
    }

    public static BigInteger GetDimension1Bought()
    {
        return _dimension1Bought;
    }

    public static BigInteger GetDimension1Cost()
    {
        return _dimension1Cost;
    }

    public static BigInteger GetDimension2Count()
    {
        return _dimension2Count;
    }

    public static BigInteger GetDimension2Created()
    {
        return _dimension2Created;
    }

    public static BigInteger GetDimension2Bought()
    {
        return _dimension2Bought;
    }

    public static BigInteger GetDimension2Cost()
    {
        return _dimension2Cost;
    }

    public static BigInteger GetDimension3Count()
    {
        return _dimension3Count;
    }

    public static BigInteger GetDimension3Created()
    {
        return _dimension3Created;
    }

    public static BigInteger GetDimension3Bought()
    {
        return _dimension3Bought;
    }

    public static BigInteger GetDimension3Cost()
    {
        return _dimension3Cost;
    }

    public static float GetTickSpeedInSeconds()
    {
        return _tickSpeedInSeconds;
    }

    public static void BuyDimension1(BigInteger amountToAdd)
    {
        if (!CanAfford(_dimension1Cost)) return;
        _dimension1Count = BigInteger.Add(_dimension1Count, amountToAdd);
        _dimension1Bought = BigInteger.Add(_dimension1Bought, amountToAdd);
        _pointCount = BigInteger.Subtract(_pointCount, _dimension1Cost);
        _dimension1Cost = GetUpdatedCost(_dimension1Bought, _dimension1Cost);
    }

    public static void BuyDimension2(BigInteger amountToAdd)
    {
        if (!CanAfford(_dimension2Cost)) return;
        _dimension2Count = BigInteger.Add(_dimension2Count, amountToAdd);
        _dimension2Bought = BigInteger.Add(_dimension2Bought, amountToAdd);
        _pointCount = BigInteger.Subtract(_pointCount, _dimension2Cost);
        _dimension2Cost = GetUpdatedCost(_dimension2Bought, _dimension2Cost);
    }

    public static void BuyDimension3(BigInteger amountToAdd)
    {
        if (!CanAfford(_dimension3Cost)) return;
        _dimension3Count = BigInteger.Add(_dimension3Count, amountToAdd);
        _dimension3Bought = BigInteger.Add(_dimension3Bought, amountToAdd);
        _pointCount = BigInteger.Subtract(_pointCount, _dimension3Cost);
        _dimension3Cost = GetUpdatedCost(_dimension3Bought, _dimension3Cost);
    }

    public static bool CanAfford(BigInteger dimensionCost) => BigInteger.Compare(_pointCount, dimensionCost) >= 0;

    private static BigInteger GetUpdatedCost(BigInteger totalBought, BigInteger currentCost)
    {
        var baseCostMultiplier = 1.05;
        if (((int)currentCost) < 1)
        {
            currentCost = BigInteger.Parse("1");
        }
        var newCost = Math.Ceiling(baseCostMultiplier * (double)totalBought);

        return BigInteger.Add(currentCost, BigInteger.Parse(newCost.ToString("N0")));
    }

    public static void UpdatePoints()
    {
        AddDimension3ToDimension2();
        AddDimension2ToDimension1();
        AddDimension1ToPointCount();
    }

    private static void AddDimension3ToDimension2()
    {
        _dimension2Created = BigInteger.Add(_dimension2Created, _dimension3Count);
        _dimension2Count = BigInteger.Add(_dimension2Count, _dimension3Count);
    }

    private static void AddDimension2ToDimension1()
    {
        _dimension1Created = BigInteger.Add(_dimension1Created, _dimension2Count);
        _dimension1Count = BigInteger.Add(_dimension1Count, _dimension2Count);
    }

    private static void AddDimension1ToPointCount()
    {
        _pointCount = BigInteger.Add(_pointCount, _dimension1Count);
    }

    public static string FormatNumber(BigInteger number)
    {
        var result = "";
        var numberString = number.ToString();

        if (numberString.Length <= 6)
        {
            result = int.Parse(numberString).ToString("N0");
        }
        else if (numberString.Length <= 9)
        {
            var significantDigitIndex = numberString.Length - 6;
            result = numberString[0..significantDigitIndex] + "." + numberString[significantDigitIndex..(significantDigitIndex + 2)] + "M";
        }
        else if (numberString.Length <= 12)
        {
            var significantDigitIndex = numberString.Length - 9;
            result = numberString[0..significantDigitIndex] + "." + numberString[significantDigitIndex..(significantDigitIndex + 2)] + "B";
        }
        else if (numberString.Length <= 15)
        {
            var significantDigitIndex = numberString.Length - 12;
            result = numberString[0..significantDigitIndex] + "." + numberString[significantDigitIndex..(significantDigitIndex + 2)] + "T";
        }
        else
        {
            var significantDigits = numberString[..3];
            var numberOfTens = numberString.Length - 1;
            result = significantDigits[0] + "." + significantDigits[1..] + "e" + numberOfTens;
        }

        return result;
    }
}