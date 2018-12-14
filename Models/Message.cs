using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thewall.Models
{
    public class Message
    {
        [Key]
        public int MessageId {get;set;}

        public int UserId {get;set;}

        public User Creator{get;set;}
        public string Msg {get;set;}

        public DateTime created_at {get;set;}

        public DateTime updatedat {get;set;}

    }
}