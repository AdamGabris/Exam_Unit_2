using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "686247fe7df07df6394a88207318d5bd332f5faecde221886826919088b172f1"; // GET YOUR PERSONAL ID FROM THE ASSIGNMENT PAGE https://mm-203-module-2-server.onrender.com/
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
// We start by registering and getting the first task
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
string taskID = "otYK2"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

//#### FIRST TASK 
// Fetch the details of the task from the server.
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\nParameters: {Colors.Yellow}{task1?.parameters}{ANSICodes.Reset}");

//Answer

List<string> allWords = new List<string>();
List<string> uniqueWords = new List<string>();
foreach (string item in task1.parameters.Split(","))
{
    allWords.Add(item);
}
foreach (string word in allWords)
{
    if (!uniqueWords.Contains(word))
    {
        uniqueWords.Add(word);
    }
}
uniqueWords.Sort();
string answer1 = string.Join(",", uniqueWords);
Console.WriteLine($"Answer: {Colors.Green}{answer1}{ANSICodes.Reset}");

// Sending answer to Task 1 back to server

Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer1.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");

//#### SECOND TASK

taskID = "rEu25ZX";

Console.WriteLine("\n-----------------------------------\n");

Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\nParameters: {Colors.Yellow}{task2?.parameters}{ANSICodes.Reset}");

//Answer

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

int ConvertRomanToInt(string roman)
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

string answer2 = ConvertRomanToInt(task2.parameters).ToString();
Console.WriteLine($"Answer: {Colors.Green}{answer2}{ANSICodes.Reset}");

// Sending answer to Task 2 back to server

Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer2.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task2AnswerResponse}{ANSICodes.Reset}");

//#### THIRD TASK

taskID = "psu31_4";

Console.WriteLine("\n-----------------------------------\n");

Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\nParameters: {Colors.Yellow}{task3?.parameters}{ANSICodes.Reset}");

int SumOfAllIntegers(string input)
{
    int sum = 0;
    foreach (string item in input.Split(","))
    {
        sum += int.Parse(item);
    }
    return sum;
}

string answer3 = SumOfAllIntegers(task3.parameters).ToString();
Console.WriteLine($"Answer: {Colors.Green}{answer3}{ANSICodes.Reset}");

// Sending answer to Task 3 back to server

Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer3.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task3AnswerResponse}{ANSICodes.Reset}");


//#### FOURTH TASK

taskID = "aLp96";

Console.WriteLine("\n-----------------------------------\n");

Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task4 = JsonSerializer.Deserialize<Task>(task4Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task4?.title}{ANSICodes.Reset}\n{task4?.description}\nParameters: {Colors.Yellow}{task4?.parameters}{ANSICodes.Reset}");

string OddOrEven(int number)
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


string answer4 = OddOrEven(int.Parse(task4.parameters)).ToString();
Console.WriteLine($"Answer: {Colors.Green}{answer4}{ANSICodes.Reset}");

// Sending answer to Task 4 back to server

Response task4AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer4.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task4AnswerResponse}{ANSICodes.Reset}");


class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}