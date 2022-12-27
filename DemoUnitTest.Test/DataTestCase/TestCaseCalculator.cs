namespace DemoUnitTest.Test.DataTestCase;

public class TestCaseCalculator
{
    public static IEnumerable<object[]> TestCaseFibonacci => new List<object[]>
    {
        new Object[] { 4, new List<int>() {0, 1, 1, 2} },
        new Object[] { 10, new List<int>() {0, 1, 1, 2, 3, 5, 8, 13, 21, 34,} },
    };
    
    
    public static IEnumerable<object[]> TestCaseFibonacci_Failed => new List<object[]>
    {
        new Object[] { -1, null },
    };

}