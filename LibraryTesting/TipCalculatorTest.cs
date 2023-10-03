using System.Diagnostics;

namespace TipLibrary.Tests;

[TestClass]
public class TipCalculatorTest
{
      [TestMethod]
    public void Test_SplitAmount_ReturnInteger()
    {
        decimal result = TipCalculator.SplitAmount(100m, 4);
        Assert.AreEqual(25m, result);
    }

    [TestMethod]
    public void Test_SplitAmount_ReturnDecimal()
    {
        decimal result = TipCalculator.SplitAmount(100m, 3);
        Assert.AreEqual(33.33m, result);
    }

    [TestMethod]
    public void Test_SplitAmount_By_ZeroPeople()
    {
         Assert.ThrowsException<DivideByZeroException>(() => {TipCalculator.SplitAmount(100,0); });
    }
}
