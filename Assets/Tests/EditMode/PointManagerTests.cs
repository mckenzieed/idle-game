using System.Numerics;
using NUnit.Framework;

public class PointManagerTests
{
    [Test]
    public void CorrectlyFormatsIntegers()
    {
        var formattedNumber = PointManager.FormatNumber(BigInteger.Parse("1234"));
        Assert.That(formattedNumber, Is.EqualTo("1,234"));

        formattedNumber = PointManager.FormatNumber(BigInteger.Parse("452789"));
        Assert.That(formattedNumber, Is.EqualTo("452,789"));

        formattedNumber = PointManager.FormatNumber(BigInteger.Parse("12345678"));
        Assert.That(formattedNumber, Is.EqualTo("12.34M"));

        formattedNumber = PointManager.FormatNumber(BigInteger.Parse("123456784"));
        Assert.That(formattedNumber, Is.EqualTo("123.45M"));

        formattedNumber = PointManager.FormatNumber(BigInteger.Parse("456712398742"));
        Assert.That(formattedNumber, Is.EqualTo("456.71B"));

        formattedNumber = PointManager.FormatNumber(BigInteger.Parse("456712398742753"));
        Assert.That(formattedNumber, Is.EqualTo("456.71T"));

        formattedNumber = PointManager.FormatNumber(BigInteger.Parse("456712398742753456"));
        Assert.That(formattedNumber, Is.EqualTo("4.56e17"));
    }
}
