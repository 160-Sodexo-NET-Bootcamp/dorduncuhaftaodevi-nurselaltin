using AutoMapper;
using DataAccess.UnityOfWork;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnityOfWork unityOfWork, IMapper mapper = null)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByID")]
        public IActionResult GetByID([FromQuery] int id)
        {
            //Control the id 
            if (id == 0)
                return BadRequest("Please,send valid user id.");

            //Get user
            var user = _unityOfWork.UserRepository.GetByID(id);

            //Do mapping then return view model
            UserModel userVm = new UserModel();
            if (user is not null)
            {
                userVm = _mapper.Map<UserModel>(user);
            }

            return Ok(userVm);
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {

            //Get Dates
            var now = DateTime.Now;
            DateTime startDate= new DateTime(now.Year, now.Month, now.Day, 8,0,0);
            DateTime endDate = new DateTime(now.Year, now.Month, now.Day, 18, 0, 0);


           //Get users
            var users = _unityOfWork.UserRepository.GetAll(x => x.CreatedDate >= startDate && x.CreatedDate <= DateTime.Now).ToList();

            //Do mapping then return view model
            List<UserModel> userVm = new List<UserModel>();

            if (users.Count() > 0)
            {
                userVm = _mapper.Map<List<UserModel>>(users);
            }

            return Ok(userVm);
        }

        /// <summary>
        /// Add new user.
        /// </summary>
        /// <param name="model">The model type is  User view  model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel model)
        {
            //Control the new model
            if (model is null)
                return BadRequest("Please , input the user information.You can not send empty user model.");

            //Is User name exist?
            var user = _unityOfWork.UserRepository.Get(x => x.UserName.ToLower() == model.UserName.ToLower());
            if (user is not null)
                return BadRequest("User name already added.Please , add another user name.");

            //Do mapping operation then add new user
            user = _mapper.Map<User>(model);
            user.isActive = true;
            user.CreatedDate = DateTime.Now;
            _unityOfWork.UserRepository.Add(user, true);

            //Get users
            var users = _unityOfWork.UserRepository.GetAll();

            //Do mapping then return view model
            List<UserModel> userVm = _mapper.Map<List<UserModel>>(users);

            return Ok(userVm);
        }

    }
}
