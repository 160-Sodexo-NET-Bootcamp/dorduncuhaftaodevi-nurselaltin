using DataAccess.UnityOfWork;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SytemController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;
        public SytemController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        /// <summary>
        /// Get system informations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetReport()
        {
            //Get informations
            var infos = _unityOfWork.SystemInfoRepository.GetAll();

            //var cronExp = "*/4 * * * *";
            //RecurringJob.AddOrUpdate(
            //    () => _unityOfWork.SystemInfoRepository.ReportProject(),
            //    cronExp,
            //    TimeZoneInfo.Local
            //    );

            ////var cronExp = "0 18 * * *";
            //var cronExp2 = "*/3 * * * *";
            //RecurringJob.AddOrUpdate(
            //    () => _unityOfWork.UserRepository.UpdateMultiple(),
            //    cronExp2,
            //    TimeZoneInfo.Local
            //    );

            return Ok(infos);

          
        }
    }
}
