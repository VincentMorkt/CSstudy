using Packt1;
using Xunit;
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace PrimeFactorTest;
public class UnitTest1
{
    [Fact]
    public void TestPrimeFactor1()
    {
        // размещение
        int number = 4;
        string expected = "2 x 2";
        var primeN = new Prime();
        // действие
        string actual = primeN.Factors(number);
        // утверждение
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestPrimeFactor2()
    {
        // размещение
        int number = 7;
        string expected = "7";
        var primeN = new Prime();
        // действие
        string actual = primeN.Factors(number);
        // утверждение
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestPrimeFactor3()
    {
        // размещение
        int number = 30;
        string expected = "5 x 3 x 2";
        var primeN = new Prime();
        // действие
        string actual = primeN.Factors(number);
        // утверждение
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestPrimeFactor4()
    {
        // размещение
        int number = 40;
        string expected = "5 x 2 x 2 x 2";
        var primeN = new Prime();
        // действие
        string actual = primeN.Factors(number);
        // утверждение
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestPrimeFactor5()
    {
        // размещение
        int number = 50;
        string expected = "5 x 5 x 2";
        var primeN = new Prime();
        // действие
        string actual = primeN.Factors(number);
        // утверждение
        Assert.Equal(expected, actual);
    }
}
