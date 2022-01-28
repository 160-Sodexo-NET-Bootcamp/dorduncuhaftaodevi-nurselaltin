using DataAccess.UnityOfWork;
using Hangfire;
using System;

namespace HangfireConsole.Managers
{
    public class UserManager
    {
        private readonly IUnityOfWork _unityOfWork;

        public UserManager(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        /// <summary>
        /// This method changes to isActive column of user table.
        /// </summary>
        public void ChangeUserStatus()
        {
            var cronExp = "0 18 * * *";
            RecurringJob.AddOrUpdate(
                () => _unityOfWork.UserRepository.UpdateMultiple(),
                cronExp,
                TimeZoneInfo.Local
                );
        }
    }
}
