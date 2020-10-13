using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.Chapter05
{
    public static class AsyncUsersExampleProgram
    {
        public static async Task Main()
        {
            Logger.Log("Starting");

            await new AccountGenerator()
                .CreateAccounts();

            Logger.Log("All done");
            Console.ReadLine();
        }
    }
 
    internal class AccountGenerator
    {
        public async Task CreateAccounts()
        {
            var users = await FetchPendingAccounts();

            foreach (var user in users)
            {
                var id = await GenerateId();
                user.ID = id;
            }

            var accountCreationTasks = users.Select(
                user => user.Region == RegionName.North
                    ? Task.Run(() => CreateNorthernAccount(user))
                    : Task.Run(() => CreateOtherAccount(user)))
                .ToList();

            Logger.Log($"Creating {accountCreationTasks.Count} accounts");
            await Task.WhenAll(accountCreationTasks);

            var updatedAccountTask = UpdatePendingAccounts(users);
            await updatedAccountTask;

            Logger.Log($"Updated {updatedAccountTask.Result} pending accounts");
        }

        private async Task<List<User>> FetchPendingAccounts()
        {
            Logger.Log("Fetching pending accounts...");
            await Task.Delay(TimeSpan.FromSeconds(3D));

            var users = new List<User>
            {
                new User("AnnH", RegionName.North),
                new User("EmmaJ", RegionName.North),
                new User("SophieA", RegionName.South),
                new User("LucyG", RegionName.West),
            };
            Logger.Log($"Found {users.Count} pending accounts");

            return users;
        }

        private Task<string> GenerateId()
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }

        private async Task<bool> CreateNorthernAccount(User user)
        {
            await Task.Delay(TimeSpan.FromSeconds(2D));
            Logger.Log($"Created northern account for {user.UserName}");
            return true;
        }

        private async Task<bool> CreateOtherAccount(User user)
        {
            await Task.Delay(TimeSpan.FromSeconds(1D));
            Logger.Log($"Created other account for {user.UserName}");
            return true;
        }

        private async Task<int> UpdatePendingAccounts(IEnumerable<User> users)
        {
            var updateAccountTasks = users.Select(usr => Task.Run(
                async () => 
                {
                    await Task.Delay(TimeSpan.FromSeconds(2D));
                    return true;
                }))
                .ToList();

            await Task.WhenAll(updateAccountTasks);

            return updateAccountTasks.Count(t => t.Result);
        }
    }
    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now:T} [{Thread.CurrentThread.ManagedThreadId:00}] {message}");
        }
    }

    public enum RegionName { North, East, South, West };

    public class User
    {
        public User(string userName, RegionName region)
        {
            UserName = userName;
            Region = region;
        }

        public string UserName { get; }
        public RegionName Region { get; }

        public string ID { get; set; }
    }
}



