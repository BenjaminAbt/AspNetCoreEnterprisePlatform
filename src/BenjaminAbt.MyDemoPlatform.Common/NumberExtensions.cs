namespace BenjaminAbt.MyDemoPlatform.Common;

public static class NumberExtensions
{
    public static (double Min, double Max) Order(double val1, double val2)
    {
        if (val1 >= val2)
        {
            return (val2, val1);
        }
        return (val1, val2);
    }
}
