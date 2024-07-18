
public class D3ManualBoughtText : BaseText
{
    public override void UpdateText()
    {
        Text.text = PointManager.FormatNumber(PointManager.GetDimension3Bought());
    }
}
