using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coding_assignment_onesignal.Models
{
    public interface IOneSignalAppRepository: IDisposable
    {
        IEnumerable<OneSignalAppsViewModel> GetAllApps();
        OneSignalAppsViewModel GetAppById(string appId);
        Task CreateApp(string newAppName);
        void DeleteApp(string appId);
        Task UpdateApp(OneSignalAppsViewModel app);
    }
}
