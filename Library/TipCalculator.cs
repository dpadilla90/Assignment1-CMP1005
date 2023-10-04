namespace TipLibrary;

public static class TipCalculator
{
    public static decimal SplitAmount(decimal amount, int numberOfPeople)
    {
        //Check of we have a 0 in the numberOfPeple 
         if (numberOfPeople == 0)
         {
            //Throw an expception if we are dividing by 0
            throw new DivideByZeroException("Number of people should not be zero.");
         } 
         //Rount the result and return the split amount
        return Math.Round(amount / numberOfPeople, 2);
    }

    public static Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
     
         //Check if percentage is not between 0 an 1
        if (tipPercentage < 0 || tipPercentage > 1)
        {
            //Throw and exception if the percentage is not between 0 an 1
            throw new ArgumentOutOfRangeException("Percentage must be a decimal between 0 and 1");
        }

        // Calculate the total cost of the meals by looping the mealCosts dictionary
        decimal totalCost = 0;
        foreach (var cost in mealCosts.Values)
        {
            totalCost += cost;
        }

        // Calculate the total tip amount
        decimal totalTip = totalCost * (decimal)tipPercentage;

        // Initialize a new empty tips dictionary 
        Dictionary<string, decimal> tips = new Dictionary<string, decimal>();
        //Loop through the mealCosts dictionary 
        foreach (var entry in mealCosts)
        {
            //Calculate the individual Tip for each person
            decimal individualTip = (entry.Value / totalCost) * totalTip;
            //Round the tips two decimal spaces, and assign each value to the tips dictionary
            tips[entry.Key] = Math.Round(individualTip, 2);
        }
        //return the tips dictionary
        return tips;
    }

    public static decimal CalculateTipPerPerson(decimal totalAmount, int numberOfPatrons, decimal tipPercentage)
    {
        //check to see if we have a cero in numberOfPatrons
        if (numberOfPatrons == 0)
        {
            //Throw and expection if the number of patrons is 0
            throw new DivideByZeroException("Number of patrons should not be 0.");
        }
        //calculate the total tip
        decimal totalTip = totalAmount * tipPercentage;
        //Round and return the Tip  per person
        return Math.Round(totalTip / numberOfPatrons, 2);
    }

}
