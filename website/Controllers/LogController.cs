﻿namespace Kcsara.Database.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.IO;

    using Kcsar.Database.Model;

    public class LogController : BaseController
    {
        [Authorize(Roles="cdb.admins")]
        public ViewResult Index()
        {
            return View(context.GetLog(DateTime.Now.AddDays(-14)));
        }

        public ContentResult SendDailyMail(string to)
        {
            if (!Permissions.IsUserOrLocal(Request))
            {
                Response.StatusCode = 403;
                return new ContentResult { Content = "Access Denied" };
            }

            if (string.IsNullOrEmpty(to))
            {
                return new ContentResult { Content = "No recipients specified" };
            }

            DateTime start = DateTime.Now.AddHours(-25);

            
            IList<AuditLog> rows = context.GetLog(start);
            ViewResult table = View("LogTable", rows);


            if (rows.Count > 0)
            {
                this.MailView(table, to, "KCSARA database changes");
            }

            return new ContentResult { Content = "OK" };

        }
    }
}