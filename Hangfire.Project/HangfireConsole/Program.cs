using DataAccess.UnityOfWork;
using Hangfire;
using Hangfire.SqlServer;
using HangfireConsole.Managers;
using System;

namespace HangfireConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GlobalConfiguration.Configuration.UseSqlServerStorage("Server=.\\SQLEXPRESS;Database=HangfireDB;Trusted_Connection=True;");

            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseColouredConsoleLogProvider()
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Server=.\\SQLEXPRESS;Database=HangfireDB;Trusted_Connection=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                });

            using (var server = new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");

                //Get instances uow
                var _unitOfWork = new EfUnityOfWork();

                //Get system report
                SystemManager systemManager = new SystemManager(new EfUnityOfWork());
                systemManager.ReportProject();

                //Change user status
                UserManager userManager = new UserManager(new EfUnityOfWork());
                userManager.ChangeUserStatus();

                Console.ReadKey();
            }

        }

    }
}
