// See https://aka.ms/new-console-template for more information

using DemoUnitTest;
using DemoUnitTest.Interface;

ICalculatorBusiness calculatorBusiness = new CalculatorBusiness();
ICalculatorBusinessV2 calculatorBusinessV2 = new CalculatorBusinessV2(calculatorBusiness);
var results = calculatorBusinessV2.Fibonacci(10);


foreach (var result in results)
{
    Console.Write(result + ", ");
}


