using SessionsArrays;
using System.Globalization;
using System.Text;
// استعملتها عشان يطلع الشهور بالانجليزي 





#region Part 1 

//Part 1

string[] sessionNames = { "C# Basics", "Arrays", "Functions", "Date and Time", "Exception Handling" };

DateTime[] sessionDates = {new DateTime(2026, 9, 10, 18, 0, 0),new DateTime(2026, 9, 13, 18, 0, 0),
new DateTime(2026, 9, 17, 18, 0, 0),new DateTime(2026, 9, 20, 18, 0, 0)
,new DateTime(2026, 9, 24, 18, 0, 0)};


int[] sessionDurations = { 180, 240, 180, 240, 180 };

#endregion


#region Part 2
//Part 2

//Methods
void DisplayASession(string sessionName, DateTime sessionDate, int sessionDuration, int sessionNumber)
{

    Console.WriteLine($"\n{sessionNumber}. {sessionName}");

    // استعملتها عشان تطلع الشهور بالانجليزي  ==> CultureInfo.InvariantCulture

    Console.WriteLine($"\n       Date: {sessionDate.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
    Console.WriteLine($"\n       Start time: {sessionDate.ToString("hh:mm tt", CultureInfo.InvariantCulture)}");

    Console.WriteLine($"\n       Duration: {sessionDuration} minutes");


}



void DisplaySessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    Console.WriteLine("\n__________Sessions Information__________\n");
    for (int i = 0; i < sessionNames.Length; i++)
    {
        DisplayASession(sessionNames[i], sessionDates[i], sessionDurations[i], i + 1);

    }

}



//Method call


DisplaySessions(sessionNames, sessionDates, sessionDurations);


#endregion

#region Part 3

//Part 3



//Method


void SearchAndDisplayASession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{

    Console.WriteLine("\nEnter the name of the session to search for : ");
    string sessionNameToSearch = Console.ReadLine()!;


    int sessionIndex = Array.IndexOf(sessionNames, sessionNameToSearch);

    if (sessionIndex == -1)
    {
        Console.WriteLine("\nSession not found.");

    }
    else
    {
        DisplayASession(sessionNames[sessionIndex], sessionDates[sessionIndex], sessionDurations[sessionIndex], sessionIndex + 1);

    }

}

//Method call


SearchAndDisplayASession(sessionNames, sessionDates, sessionDurations);


#endregion

#region Part 4

//Part 4


//4.1 

int sessionLength = sessionNames.Length;

string[] sessionNamesCopy1=new string[sessionLength];
        
Array.Copy(sessionNames, sessionNamesCopy1, sessionLength);
Array.Sort(sessionNamesCopy1);


void DisplayStringArray(string [] arr)
{
    for(int i=0;i<arr.Length;i++)
    {
        Console.WriteLine($"\n{arr[i]}");
    }
}
Console.WriteLine("\nAfter Sorting Session Names Assending:\n");
DisplayStringArray(sessionNamesCopy1);



//4.2


string[] sessionNamesCopy2 = new string[sessionLength];

Array.Copy(sessionNames, sessionNamesCopy2, sessionLength);

Array.Reverse(sessionNamesCopy2);
Console.WriteLine("\nAfter Reversing Session Names :\n");

DisplayStringArray(sessionNamesCopy2);

//4.3
int FindSessionIndex(string[]sessionNames)
{
    Console.WriteLine("\nEnter the name of the session to search for : ");
    string sessionNameToSearch = Console.ReadLine()!;


    return Array.IndexOf(sessionNames, sessionNameToSearch);


}


//4.4

//Using old methods created:
//bool CheckIfSessionExists(string[] sessionNames) => FindSessionIndex(sessionNames) == -1 ? false : true;


bool CheckIfSessionExists(string[] sessionNames)
{
    Console.WriteLine("\nEnter the name of the session to check : ");
    string sessionNameToCheck = Console.ReadLine()!;

    bool sessionExists = Array.Exists(sessionNames, name => name == sessionNameToCheck);

    if (sessionExists)
    {
        Console.WriteLine("\nSession exists ");
    }
    else
    {
        Console.WriteLine("\nSession does Not exist   ");
    }

    return sessionExists;
}

//4.5

void FindASession(string[] sessionNames)
{
    Console.WriteLine("\nEnter the name of the session to Find : ");
    string sessionNameToFind = Console.ReadLine()!;

    string foundResult = Array.Find(sessionNames, sessionName => sessionName == sessionNameToFind);
    //Lambda expression First time to use :)
    if(foundResult==null)
    {
        Console.WriteLine("\nSession Not found.");
    }
    else
    {
        Console.WriteLine($"\nSession \"{foundResult}\" Was Found .");

    }
}


//4.6

void FindASessionIndexWithCondition(string[] sessionNames)
{
    Console.WriteLine("\nEnter the name of the session to Find : ");
    string sessionNameToFind = Console.ReadLine()!;

    int foundResult =  Array.FindIndex(sessionNames, name => name ==sessionNameToFind);

    if (foundResult == -1)
    {
        Console.WriteLine("\nSession Not found.");
    }
    else
    {

        Console.WriteLine($"\nSession was found at index :{foundResult}");
    }
}

//4.7


string[] sessionNameCopy3 = new string[sessionLength];

Array.Copy(sessionNames, sessionNameCopy3,sessionLength);


sessionNameCopy3[0] = "Updated C# Basics";

Console.WriteLine("____________________________________________\n");
Console.WriteLine("Updated Copy of Session Names Array : ");
Console.WriteLine("____________________________________________\n");

DisplayStringArray(sessionNameCopy3);
Console.WriteLine("____________________________________________\n");
Console.WriteLine("Original Session Names Array: ");
Console.WriteLine("____________________________________________\n");

DisplayStringArray(sessionNames);
#endregion

#region Part 5

//Part 5
int GetTotalDuration(int[] sessionDurations)
{
    int totalDuration = 0;

    for (int i = 0; i < sessionDurations.Length; i++)
    {

        totalDuration += sessionDurations[i];
    }

    return totalDuration;

}
double GetAverageDuration (int[] sessionDurations)=> (double)GetTotalDuration(sessionDurations) / sessionDurations.Length;

int GetShortestDuration(int[] sessionDurations)
{
    int shortestDuration = sessionDurations[0];

    for (int i = 1; i < sessionDurations.Length; i++)
    {
        if (sessionDurations[i] < shortestDuration)
        {

            shortestDuration = sessionDurations[i];
        }
    }

    return shortestDuration;
}


int GetLongestDuration(int[] sessionDurations)
{
    int longestDuration = sessionDurations[0];

    for (int i = 1; i < sessionDurations.Length; i++)
    {
        if (sessionDurations[i] > longestDuration)
        {

            longestDuration = sessionDurations[i];
        }
    }

    return longestDuration;
}

Console.WriteLine("\n__________ Duration Information __________\n");

Console.WriteLine($"Total Duration: {GetTotalDuration(sessionDurations)} minutes");
Console.WriteLine($"Average Duration: {GetAverageDuration(sessionDurations)} minutes");

Console.WriteLine($"Shortest Duration: {GetShortestDuration(sessionDurations)} minutes");
Console.WriteLine($"Longest Duration: {GetLongestDuration(sessionDurations)} minutes");

Console.WriteLine("\n____________________________________\n");



int[] sessionDurationsCopySorted = new int[sessionDurations.Length];

Array.Copy(sessionDurations, sessionDurationsCopySorted, sessionDurations.Length);

Array.Sort(sessionDurationsCopySorted);
void DisplayIntArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine($"\n{arr[i]}");
    }
}

Console.WriteLine("\nDurations Sorted Ascending:");

DisplayIntArray(sessionDurationsCopySorted);


#endregion

#region Part 6

// Part 6

// DisplaySessions()         => done before
// DisplaySessionDetails()                   => done before  by name DisplayASession()
// GetTotalDuration()           => done before
// GetAverageDuration()         => done before
// GetShortestDuration()         => done before
// GetLongestDuration()          => done before


int SearchSession(string[] sessionNames)
{
    Console.WriteLine("\nEnter the name of the session to search for : ");

    string sessionNameToSearch = Console.ReadLine()!;

    return Array.IndexOf(sessionNames, sessionNameToSearch);
}


DateTime GetSessionEndTime(DateTime sessionDate, int sessionDuration)=>sessionDate.AddMinutes(sessionDuration);

#endregion


#region Part 7

void UpdateDuration(ref int duration)
{
    duration += 30;
}



void GetSessionInfo(string[] sessionNames,int[] sessionDurations,string sessionName,out int sessionIndex,out int duration)
{
    sessionIndex = Array.IndexOf(sessionNames, sessionName);

    if (sessionIndex == -1)
    {
        duration = 0;
    }
    else
    {
        duration = sessionDurations[sessionIndex];
    }
}




Console.Write("\nEnter the name of the session: ");

string sessionName = Console.ReadLine()!;

GetSessionInfo(sessionNames,sessionDurations,sessionName,out int index,out int sessionDuration);



Console.WriteLine($"\nSession Index: {index}");
Console.WriteLine($"Session Duration: {sessionDuration} minutes");

UpdateDuration(ref sessionDurations[0]);
Console.WriteLine($"\nFirst Session Duration: {sessionDurations[0]} minutes");

#endregion

#region Part 8

int GetTotalDurationWithParams(params int[] durations)
{
    int totalDuration = 0;

    for (int i = 0; i < durations.Length; i++)
    {
        totalDuration += durations[i];
    }

    return totalDuration;
}

Console.WriteLine($"\nTotal Duration: {GetTotalDurationWithParams(180, 240, 180)} minutes");

#endregion

#region Part 9

Console.Write("\nEnter the session index: ");

int sessionIndex = int.Parse(Console.ReadLine()!);

Console.WriteLine($"\nFull Date: {sessionDates[sessionIndex].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");

Console.WriteLine($"Day of Week: {sessionDates[sessionIndex].DayOfWeek}");
Console.WriteLine($"Year: {sessionDates[sessionIndex].Year}");
Console.WriteLine($"Month: {sessionDates[sessionIndex].Month}");
Console.WriteLine($"Day: {sessionDates[sessionIndex].Day}");

Console.WriteLine($"Start Time: {sessionDates[sessionIndex].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
Console.WriteLine($"Duration: {sessionDurations[sessionIndex]} minutes");
Console.WriteLine($"End Time: {GetSessionEndTime(sessionDates[sessionIndex], sessionDurations[sessionIndex])
    .ToString("hh:mm tt", CultureInfo.InvariantCulture)}");



#endregion

#region Part 10

Console.Write("\nEnter the first session index: ");
int firstSessionIndex = int.Parse(Console.ReadLine()!);

Console.Write("Enter the second session index: ");
int secondSessionIndex = int.Parse(Console.ReadLine()!);

TimeSpan timeBetween2Sessions = sessionDates[secondSessionIndex] - sessionDates[firstSessionIndex];

Console.WriteLine($"\nDifference in Days: {timeBetween2Sessions.TotalDays}");
Console.WriteLine($"Difference in Hours: {timeBetween2Sessions.TotalHours}");

#endregion

#region Part 11

Console.WriteLine("\nPast and Upcoming Sessions:");

for (int i = 0; i < sessionDates.Length; i++)
{

    if (sessionDates[i] < DateTime.Now)
    {
        Console.WriteLine($"{sessionNames[i]}: Past");
    }
    else
    {
        Console.WriteLine($"{sessionNames[i]}: Upcoming");
    }
}

#endregion


#region Part 12

int GetNextSessionIndex(DateTime[] sessionDates)
{
    for (int i = 0; i < sessionDates.Length; i++)
    {
        if (sessionDates[i] > DateTime.Now)
        {
            return i;
        }
    }

    return -1;
}

int nextSessionIndex = GetNextSessionIndex(sessionDates);

if (nextSessionIndex == -1)
{

    Console.WriteLine("\nNo upcoming sessions.");
}
else
{
    Console.WriteLine($"\nNext Session: {sessionNames[nextSessionIndex]}");

}




#endregion


#region Part 13

Console.WriteLine("\n           Diffrent typs of formating:\n");
Console.WriteLine($"\nDate: {sessionDates[1].ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
Console.WriteLine($"Date: {sessionDates[1].ToString("MMMM dd, yyyy", CultureInfo.InvariantCulture)}");

Console.WriteLine($"Time: {sessionDates[1].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
Console.WriteLine($"Time: {sessionDates[1].ToString("HH:mm", CultureInfo.InvariantCulture)}");

#endregion

#region Part 14

Console.Write("\nEnter date (yyyy-MM-dd HH:mm): ");
string dateToRead = Console.ReadLine()!;




if (DateTime.TryParseExact(dateToRead, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime date))
{
    Console.WriteLine($"\nValid Date: {date}");
}
else
{
    Console.WriteLine("\nInvalid Date.");
}

#endregion


#region Part 15

int choice;

while (true)
{
    Console.Write("\nEnter an integer: ");

    try
    {
        choice = int.Parse(Console.ReadLine()!);
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("\nPlease enter a valid integer.");
    }
}

#endregion


#region Part 16

try
{
    Console.Write("\nEnter session index: ");

    int IndexChoice = int.Parse(Console.ReadLine()!);

    Console.WriteLine(sessionNames[IndexChoice]);
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("\nInvalid session index.");
}

#endregion

#region Part 17

Console.Write("\nEnter session duration: ");

int sessionDurationChoice = int.Parse(Console.ReadLine()!);

try
{
    if (sessionDurationChoice <= 0)
    {
        throw new ArgumentException();
    }

    Console.WriteLine("\nValid Session Duration.");
}
catch (ArgumentException)
{
    Console.WriteLine("\nInvalid Session Duration.");
}

#endregion



#region Part 18

try
{
    Console.Write("\nEnter an integer: ");

    int number = int.Parse(Console.ReadLine()!);

    Console.WriteLine($"\nNumber Entered is: {number}");
}
catch (FormatException)
{
    Console.WriteLine("\nWrong input.");
}
finally
{
    Console.WriteLine("\nInput operation finished.");
}

#endregion


#region Part 19

string BuildReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    string report = "";

    for (int i = 0; i < sessionNames.Length; i++)
    {
        report += "\nSession Name: " + sessionNames[i]+ "\nDate: " + sessionDates[i].ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
               + "\nDuration: " + sessionDurations[i] + " minutes\n";
    }

    return report;
}

Console.WriteLine(BuildReportUsingString(sessionNames, sessionDates, sessionDurations));

#endregion



#region Part 20

string BuildReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    StringBuilder report = new StringBuilder();

    for (int i = 0; i < sessionNames.Length; i++)
    {
        report.Append("\nSession Name: " + sessionNames[i]+ "\nDate: " + sessionDates[i].ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
            + "\nDuration: " + sessionDurations[i] + " minutes\n");
    }

    return report.ToString();
}

Console.WriteLine(BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));

#endregion


//__________________________



BenchmarkDotNet.Running.BenchmarkRunner.Run<StringBenchmark>();