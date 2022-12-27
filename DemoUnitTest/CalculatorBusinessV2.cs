using DemoUnitTest.Interface;

namespace DemoUnitTest;

public class CalculatorBusinessV2 : ICalculatorBusinessV2
{
    private ICalculatorBusiness _calculatorBusiness;
    
    public CalculatorBusinessV2(ICalculatorBusiness calculatorBusiness)
    {
        this._calculatorBusiness = calculatorBusiness;
    }
    
    /// <summary>
    /// 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
    /// </summary>
    /// <param name="totalNumber"></param>
    /// <returns></returns>
    public List<int> Fibonacci(int totalNumber)
    {
        if (totalNumber < 0)
        {
            return null;
        }
        int number = 0;
        
        List<int> results = new List<int>();
        for (int i = 0; i < totalNumber; i++)
        {
            results.Add(GetFibonacci(number));
            number++;
        }

        return results;
    }


    private int GetFibonacci(int num)
    {
        if (num == 0)
            return 0;
        else if (num == 1)
            return 1;
        else
            return (GetFibonacci(num - 1) + GetFibonacci(num - 2));
    }
    
    
    public List<int> FibonacciAndDiv2(int totalNumber)
    {
        if (totalNumber < 0)
        {
            return null;
        }
        int number = 0;
        
        List<int> results = new List<int>();
        for (int i = 0; i < totalNumber; i++)
        {
            var x = GetFibonacci(number);
            if (_calculatorBusiness.Div2(x))
            {
                results.Add(x);
            }
            number++;
        }

        return results;
    }
}