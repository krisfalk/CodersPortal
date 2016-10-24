using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using CodersPortal;
using CodersPortal.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
namespace CodersPortal
{
    public class ChatHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            string userEmail = Context.User.Identity.Name;
            ApplicationUser myUser = db.Users.Where(x => x.Email == userEmail).Select(x => x).SingleOrDefault();
            name = myUser.firstName + " " + myUser.lastName;
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}