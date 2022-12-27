using DemoUnitTest.Interface;

namespace DemoUnitTest;

public class CalculatorBusiness : ICalculatorBusiness
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public bool Div2(int number)
    {
        return number % 2 == 0;
    }
}