using System;
using Tarefas.DTO;
using Tarefas.DAO;
using AutoMapper;
using Tarefas.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Tarefas.Web.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {          
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
