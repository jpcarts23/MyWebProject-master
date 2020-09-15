using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebProject.Models
{
    public class DropDownList
    {
        private static List<string> Priviledge()
        {
            List<string> userPriviledge = new List<string> { };
            using (var context = new TMGEntities())
            {
                userPriviledge = context.TMGUserAccesses.Select(a => a.AccessName).ToList();
            }
            return userPriviledge;
        }
        private static List<string> UserDepartment()
        {
            List<string> userDepartment = new List<string> { };
            using (var context = new HRISEntities())
            {
                userDepartment = context.Departments.Select(d => d.DeptName).ToList();
            }
            return userDepartment;
        }
        private static List<string> Channel()
        {
            List<string> channel = new List<string> { };
            using (var context = new TMGEntities())
            {
                channel = context.Channels.Select(c => c.ChannelName).ToList();
            }
            return channel;
        }
        private static List<string> Title()
        {
            List<string> title = new List<string> { };
            using (var context = new TMGEntities())
            {
                title = context.Titles.Select(t => t.TitleName).ToList();
            }
            return title;
        }
        private static List<string> Description()
        {
            List<string> description = new List<string> { };
            using (var context = new TMGEntities())
            {
                description = context.Descriptions.Select(d => d.DescName).ToList();
            }
            return description;
        }

        public static SelectList ChannelList = new SelectList(Channel());
        public static SelectList TitleList = new SelectList(Title());
        public static SelectList DescriptionList = new SelectList(Description());
        public static SelectList PriviledgeList = new SelectList(Priviledge());
        public static SelectList DepartmentList = new SelectList(UserDepartment());

    }
}