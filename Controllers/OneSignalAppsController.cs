using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using coding_assignment_onesignal.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;

namespace coding_assignment_onesignal.Controllers
{
    [Authorize(Roles = "Admin,DataEntryOperator")]
    public class OneSignalAppsController : Controller
    {
        OneSignalAppRepository appRepo = new OneSignalAppRepository();

        public IActionResult Index()
        {
            ViewBag.AppsList = appRepo.GetAllApps();
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateApp(string newAppName)
        {
            await appRepo.CreateApp(newAppName);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UpdateApp(string appId)
        {
            OneSignalAppsViewModel app = appRepo.GetAppById(appId);
            ViewBag.AppData = app;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditApp(OneSignalAppsViewModel updatedAppData)
        {
            await appRepo.UpdateApp(updatedAppData);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteApp(string appId)
        {
            appRepo.DeleteApp(appId);
            return RedirectToAction("Index");
        }

    }
}