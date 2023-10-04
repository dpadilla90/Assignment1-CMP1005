namespace TipLibrary;

public static class TipCalculator
{
    public static decimal SplitAmount(decimal amount, int numberOfPeople)
    {
         if (numberOfPeople == 0)
         {
            throw new DivideByZeroException("Number of people should not be zero.");
         } 
        return Math.Round(amount / numberOfPeople, 2);
    }

    public static Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
     
         //Check if percentage is between 0 an 1
        if (tipPercentage < 0 || tipPercentage > 1)
        {
            throw new ArgumentOutOfRangeException("Percentage must be a number between 0 and 1");
        }

        // Calculate the total cost of the meals
        decimal totalCost = 0;
        foreach (var cost in mealCosts.Values)
        {
            totalCost += cost;
        }

        // Calculate the total tip amount
        decimal totalTip = totalCost * (decimal)tipPercentage;

        // Calculate the tip for each person based on the weighted average 
        Dictionary<string, decimal> tips = new Dictionary<string, decimal>();
        foreach (var entry in mealCosts)
        {
            decimal individualTip = (entry.Value / totalCost) * totalTip;
            tips[entry.Key] = Math.Round(individualTip, 2);
        }

        return tips;
    }
}
