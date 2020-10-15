using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UsersModel
    {
        public int id { get; set; }
        public string HoTen { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string level { get; set; }
        public string token { get; set; }
    }
}
