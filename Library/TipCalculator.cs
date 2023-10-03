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

}
