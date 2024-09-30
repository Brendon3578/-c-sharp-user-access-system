using System.Globalization;
using System.Text.Json;
using UserAccessWatcherSystem.Entities;

namespace UserAccessWatcherSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter file full path: ");
            //string usersAccessFilePath = Console.ReadLine() ?? "";
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativeFilePath = Path.Combine(currentDirectory, @"..\..\..\user-access.json");
            string usersAccessFilePath = Path.GetFullPath(relativeFilePath);

            var userAccessList = new List<UserAccess>();

            FileInfo userAccessJsonFile = new FileInfo(usersAccessFilePath);

            if (userAccessJsonFile.Exists)
            {
                Console.WriteLine("[success] User access json file found.");
                using (StreamReader reader = new(userAccessJsonFile.OpenRead()))
                {
                    string json = reader.ReadToEnd();

                    var data = JsonSerializer.Deserialize<UserAccessData>(json)?.data;

                    if (data == null) return;

                    foreach (var user in data)
                    {
                        userAccessList.Add(new UserAccess(user.username, user.access_date));
                    }
                }
            }
            else
            {
                Console.WriteLine("[error] User access json file not found!!");
                throw new FileNotFoundException("User access json file not found!");
            }

            var uniqueUserAccesses = userAccessList.ToHashSet();

            Console.WriteLine("────── Users accessed on day (distinct):");
            foreach (var access in uniqueUserAccesses)
                Console.WriteLine(access);

            Console.WriteLine($"\nTotal users access in days (distinct): {uniqueUserAccesses.Count}");

            Console.WriteLine("────── Access Dates");
            var accessByDate = new Dictionary<string, HashSet<UserAccess>>();

            foreach (var user in userAccessList)
            {
                var accessDateString = user.access_date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (accessByDate.TryGetValue(accessDateString, out var currentAccess))
                {
                    if (currentAccess == null)
                    {
                        Console.WriteLine("HashSet don't exists! error");
                        continue;
                    }
                    currentAccess.Add(user);
                }
                else
                {
                    var newuserAccessList = new HashSet<UserAccess>() { user };
                    accessByDate.Add(accessDateString, newuserAccessList);
                }
            }

            foreach (var (date, accessInDay) in accessByDate)
            {
                Console.WriteLine($"\n┌──── Access in {date} ───");
                foreach (var access in accessInDay)
                {
                    Console.WriteLine($"├─ {access}");
                }
                Console.WriteLine("└─────────────────────────────");
            }
        }
    }
}
