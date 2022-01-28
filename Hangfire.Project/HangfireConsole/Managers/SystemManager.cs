using DataAccess.UnityOfWork;
using Hangfire;
using System;

namespace HangfireConsole.Managers
{
    /// <summary>
    /// This class save informations about project to systemInfo table.
    /// </summary>
    public class SystemManager
    {
        private readonly IUnityOfWork _unityOfWork;

        public SystemManager(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        /// <summary>
        /// This method add data about user table 
        /// </summary>
        public  void ReportProject()
        {
            var cronExp = "*/15 * * * *";
            RecurringJob.AddOrUpdate(
                () => _unityOfWork.SystemInfoRepository.ReportProject(),
                cronExp,
                TimeZoneInfo.Local
                );
        }
    }
}
