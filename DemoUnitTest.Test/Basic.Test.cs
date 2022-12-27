using DemoUnitTest.Interface;
using DemoUnitTest.Test.DataTestCase;

namespace DemoUnitTest.Test;

public class Basic_Test
{
    private ICalculatorBusiness _calculatorBusiness;
    private ICalculatorBusinessV2 _calculatorBusinessV2;
    public Basic_Test()
    {
        _calculatorBusiness = new CalculatorBusiness();
        _calculatorBusinessV2 = new CalculatorBusinessV2(_calculatorBusiness);
    }

    [Fact]
    public void TestAdd()
    {
        // Arrange
        var a = 1;
        var b = 1;
        var expected = 2;
        
        //Act
        var actual = _calculatorBusiness.Add(a, b);
        
        //Assert
        Assert.Equal(actual, expected);
    }
    
    
    [Fact]
    public void TestHaiCongHaiBangBon()
    {
        // Arrange
        var a = 2;
        var b = 2;
        var expected = 4;
        
        //Act
        var actual = _calculatorBusiness.Add(a, b);
        
        //Assert
        Assert.Equal(actual, expected);
    }
    
    [Fact]
    public void Test10Div2()
    {
        // Arrange
        var a = 10;
        var expected = true;
        
        //Act
        var actual = _calculatorBusiness.Div2(a);
        
        //Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test6Div2()
    {
        // Arrange
        var a = 6;
        
        //Act
        var actual = _calculatorBusiness.Div2(a);
        
        //Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test5Div2Failed()
    {
        // Arrange
        var a = 5;
        
        //Act
        var actual = _calculatorBusiness.Div2(a);
        
        //Assert
        Assert.False(actual);
    }
    
    
    [Theory]
    [InlineData(4, true)]
    [InlineData(6, true)]
    [InlineData(10, true)]
    [InlineData(5, false)]
    public void TestDiv2(int number, bool expected)
    {
        // Arrange
        
        //Act
        var actual = _calculatorBusiness.Div2(number);
        
        //Assert
        Assert.Equal(actual, expected);
    }
    
    [Theory]
    [InlineData(7)]
    public void TestDiv2_Failed(int number)
    {
        // Arrange
        
        //Act
        var actual = _calculatorBusiness.Div2(number);
        
        //Assert
        Assert.Equal(actual, false);
    }
    
    
    [Theory]
    [MemberData(nameof(TestCaseCalculator.TestCaseFibonacci), MemberType = typeof(TestCaseCalculator))]
    public void TestFibonacci(int total, List<int> expected)
    {
        // Arrange
        
        //Act
        var actual = _calculatorBusinessV2.Fibonacci(total);
        
        //Assert
        Assert.Equal(actual, expected);
        Assert.Equal(total, expected.Count);
    }
    
    [Theory]
    [MemberData(nameof(TestCaseCalculator.TestCaseFibonacci_Failed), MemberType = typeof(TestCaseCalculator))]
    public void TestFibonacci_Failed(int total, List<int> expected)
    {
        // Arrange

        var actual = _calculatorBusinessV2.Fibonacci(total);
        
        //Assert
        Assert.Equal(actual, expected);
    }
}