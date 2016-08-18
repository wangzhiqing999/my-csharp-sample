using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;



namespace W1302_RoomManager.Test
{
    public class UserInfo
    {
        [Key]
        public string ContextID { get; set; }
        public string Name { get; set; }
    }
}