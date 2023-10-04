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

   

     [TestMethod]
    public void Test_CalculateTip_ThreePerson_ReturnCorrectTip()
    {
        var mealCosts = new Dictionary<string, decimal>
        {
            { "Juan", 50.0m },
            { "Janeth", 30.0m },
            { "Miriam", 20.0m }
        };

        var tips = new Dictionary<string, decimal>
        {
            { "Juan", 7.5m },
            { "Janeth", 4.5m },
            { "Miriam", 3.0m }
        };

        var result = TipCalculator.CalculateTip(mealCosts, 0.15f);

        CollectionAssert.AreEqual(tips, result);
    }

    [TestMethod]
    public void Test_CalculateTip_ThreePerson_NoTips()
    {
        var mealCosts = new Dictionary<string, decimal>
        {
            { "Juan", 50.0m },
            { "Janeth", 30.0m },
            { "Miriam", 20.0m }
        };

        var tips = new Dictionary<string, decimal>
        {
            { "Juan", 0.0m },
            { "Janeth", 0.0m },
            { "Miriam", 0.0m }
        };

        var result = TipCalculator.CalculateTip(mealCosts, 0.0f);

        CollectionAssert.AreEqual(tips, result);
    }

     [TestMethod]
    public void Test_CalculateTip_ThreePerson_IncorrectPercentage()
    {
         var mealCosts = new Dictionary<string, decimal>
        {
            { "Juan", 50.0m },
            { "Janeth", 30.0m },
            { "Miriam", 20.0m }
        };
         Assert.ThrowsException<ArgumentOutOfRangeException>(() => {TipCalculator.CalculateTip(mealCosts,1.5f); });
    }

    
}
