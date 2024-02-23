using System.Collections.Generic;
namespace Tasks;
public class TaskProcessor
{
    // Process the first task
    public string ProcessTask1(string parameters)
    {
        List<string> uniqueWords = new List<string>();
        string[] allWords = parameters.Split(",");
        
        for (int i = 0; i < allWords.Length; i++)
        {
            string word = allWords[i];
            
            if (!uniqueWords.Contains(word))
            {
                uniqueWords.Add(word);
            }
        }
        
        uniqueWords.Sort();
        return string.Join(",", uniqueWords);
    }

    // Process the second task

    Dictionary<char, int> romanToInteger = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    public int ProcessTask2(string roman)
    {
        int result = 0;
        for (int i = 0; i < roman.Length; i++)
        {
            if (i + 1 < roman.Length && romanToInteger[roman[i]] < romanToInteger[roman[i + 1]])
            {
                result -= romanToInteger[roman[i]];
            }
            else
            {
                result += romanToInteger[roman[i]];
            }
        }
        return result;
    }

    // Process the third task
    public int ProcessTask3(string parameters)
    {
        int sum = 0;
        foreach (string item in parameters.Split(","))
        {
            sum += int.Parse(item);
        }
        return sum;
    }

    // Process the fourth task
    public string ProcessTask4(int number)
    {
        if (number % 2 == 0)
        {
            return "even";
        }
        else
        {
            return "odd";
        }
}


}