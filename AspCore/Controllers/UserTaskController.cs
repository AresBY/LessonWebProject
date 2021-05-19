﻿
using BusinessLayer.Services;
using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class UserTaskController : Controller
    {
        ServicesManager _servicesManager;
        public UserTaskController(ServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
        }
        public IActionResult CreateNewTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetNewTaskData(CategoryType category, int maxPrice, string keyWords)
        {
            _servicesManager._userTaskService.CreateTask( category,  maxPrice,  keyWords);
         
            return View();
        }
    }
}
