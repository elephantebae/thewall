using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thewall.Models
{

    public class Comment
    {
        [Key]
        public int CommentId {get;set;}

        public int MessageId {get;set;}

        public int UserId {get;set;}
        public User Creator{get;set;}

        public string Cmt {get;set;}

        public DateTime created_at {get;set;}

        public DateTime updated_at {get;set;}
    }
}