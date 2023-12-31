using System.Diagnostics;

namespace TipLibrary.Tests;

[TestClass]
public class TipCalculatorTest
{
      [TestMethod]
    public void Test_SplitAmount_NormalInputs_ReturnInteger()
    {
        decimal result = TipCalculator.SplitAmount(100m, 4);
        Assert.AreEqual(25m, result);
    }

    [TestMethod]
    public void Test_SplitAmount_NormalInputs_ReturnDecimal()
    {
        decimal result = TipCalculator.SplitAmount(100m, 3);
        Assert.AreEqual(33.33m, result);
    }

    [TestMethod]
    public void Test_SplitAmount_InputZeroPeople_ThrowsException()
    {
         Assert.ThrowsException<DivideByZeroException>(() => {TipCalculator.SplitAmount(100,0); });
    }

   

     [TestMethod]
    public void Test_CalculateTip_ThreePerson_NormalInputs_ReturnCorrectTip()
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
    public void Test_CalculateTip_ThreePerson_ZeroPercentageOfTip_ReturnZeroTips()
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
    public void Test_CalculateTip_ThreePerson_PercentageOutOfRange_ThrowsExeception()
    {
         var mealCosts = new Dictionary<string, decimal>
        {
            { "Juan", 50.0m },
            { "Janeth", 30.0m },
            { "Miriam", 20.0m }
        };
         Assert.ThrowsException<ArgumentOutOfRangeException>(() => {TipCalculator.CalculateTip(mealCosts,1.5f); });
    }

     [TestMethod]
    public void Test_CalculateTipPerPerson_NormalInputs_ReturnsCorrectTip()
    {
    
        decimal totalAmount = 100m;
        int numberOfPatrons = 4;
        decimal tipPercentage = 0.10m;  
        decimal result = TipCalculator.CalculateTipPerPerson(totalAmount, numberOfPatrons, tipPercentage);
        Assert.AreEqual(2.5m, result);  
    }


    [TestMethod]
    public void Test_CalculateTipPerPerson_ZeroAmount_ReturnsZeroTip()
    {
        decimal totalAmount = 0m;
        int numberOfPatrons = 4;
        decimal tipPercentage = 0.10m;
        decimal result = TipCalculator.CalculateTipPerPerson(totalAmount, numberOfPatrons, tipPercentage);
        Assert.AreEqual(0m, result);
    }

    [TestMethod]
    public void Test_CalculateTipPerPerson_ZeroPatrons_ThrowsException()
    {

        decimal totalAmount = 100m;
        int numberOfPatrons = 0;
        decimal tipPercentage = 0.10m;
        Assert.ThrowsException<DivideByZeroException>(() => {TipCalculator.CalculateTipPerPerson(totalAmount, numberOfPatrons, tipPercentage); });
    }
    
}
