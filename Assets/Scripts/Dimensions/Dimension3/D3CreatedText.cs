

public class D3CreatedText : BaseText
{
    public override void UpdateText()
    {
        Text.text = PointManager.FormatNumber(PointManager.GetDimension3Created());
    }
}
