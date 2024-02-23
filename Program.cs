using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using TaskProcessor = Tasks.TaskProcessor;


Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "686247fe7df07df6394a88207318d5bd332f5faecde221886826919088b172f1"; 
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; 
const string taskEndpoint = "task/";  

HttpUtils httpUtils = HttpUtils.instance;
TaskProcessor taskProcessor = new TaskProcessor();


//#### REGISTRATION
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); 
string taskID = "otYK2";

//#### FIRST TASK 
// Fetch the details of the task from the server.
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\nParameters: {Colors.Yellow}{task1?.parameters}{ANSICodes.Reset}");

//Answer
string answer1 = taskProcessor.ProcessTask1(task1.parameters);
Console.WriteLine($"Answer: {Colors.Green}{answer1}{ANSICodes.Reset}");

// Sending answer to Task 1 back to server

Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer1.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");

//#### SECOND TASK

taskID = "rEu25ZX";

Console.WriteLine("\n-----------------------------------\n");

Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\nParameters: {Colors.Yellow}{task2?.parameters}{ANSICodes.Reset}");

//Answer

int answer2 = taskProcessor.ProcessTask2(task2.parameters);
Console.WriteLine($"Answer: {Colors.Green}{answer2}{ANSICodes.Reset}");

// Sending answer to Task 2 back to server

Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer2.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task2AnswerResponse}{ANSICodes.Reset}");

//#### THIRD TASK

taskID = "psu31_4";

Console.WriteLine("\n-----------------------------------\n");

Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\nParameters: {Colors.Yellow}{task3?.parameters}{ANSICodes.Reset}");

string answer3 = taskProcessor.ProcessTask3(task3.parameters).ToString();
Console.WriteLine($"Answer: {Colors.Green}{answer3}{ANSICodes.Reset}");

// Sending answer to Task 3 back to server

Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer3.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task3AnswerResponse}{ANSICodes.Reset}");


//#### FOURTH TASK

taskID = "aLp96";

Console.WriteLine("\n-----------------------------------\n");

Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task4 = JsonSerializer.Deserialize<Task>(task4Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task4?.title}{ANSICodes.Reset}\n{task4?.description}\nParameters: {Colors.Yellow}{task4?.parameters}{ANSICodes.Reset}");

string answer4 = taskProcessor.ProcessTask4(int.Parse(task4.parameters));
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
