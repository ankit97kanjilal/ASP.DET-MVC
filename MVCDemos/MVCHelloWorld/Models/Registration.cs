using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHelloWorld.Models
{
    public class Registration
    {
        public int Ecode { set; get; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public List<string> SelectedHobbies { get; set; }
        public List<Hobby> Hobbies { get; set; }
        public string SelectedCity { get; set; }
        public List<SelectListItem> Cities { get;set; }
        public string Address { get; set; }
    }
    public class Hobby
    {
        public bool IsSelected { get; set; }
        public string HobbyType { get; set; }
    }
}