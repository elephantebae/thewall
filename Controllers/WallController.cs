using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using thewall.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace thewall.Controllers
{
    public class WallController : Controller
    {
        private WallContext dbContext;
        public WallController(WallContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("WallView")]
        public IActionResult WallView()
        {
            int? id = HttpContext.Session.GetInt32("CurrentUser");
            User User = dbContext.users.FirstOrDefault(u => u.UserId == id);
            ViewBag.CurrentUser = User.FirstName;
            List<Message> AllMessages= dbContext.messages
            .Include(msg => msg.Creator)
            .ToList();
            ViewBag.AMessages = AllMessages;
            List<Comment> AllComments= dbContext.comments
            .Include(cmt=> cmt.Creator)
            .ToList();
            ViewBag.AComments = AllComments;
            return View();
        }
        [HttpPost]
        [Route("messagepost")]
        public IActionResult messagepost(Message newMsg)
        {
            int? id =HttpContext.Session.GetInt32("CurrentUser");
            Message NewMessage = new Message();
            {
                NewMessage.Msg = newMsg.Msg;
                NewMessage.UserId = (int)id;
                dbContext.Add(NewMessage);
                dbContext.SaveChanges();
            }
            return RedirectToAction("WallView");
        }
        [HttpPost]
        [Route("commentpost")]
        public IActionResult commentpost(Comment newCmt)
        {
            int? id = HttpContext.Session.GetInt32("CurrentUser");
            Comment NewComment = new Comment();
            {
                NewComment.Cmt = newCmt.Cmt;
                NewComment.UserId = (int) id;
                NewComment.MessageId = newCmt.MessageId;
                dbContext.Add(NewComment);
                dbContext.SaveChanges();
            }
            return RedirectToAction("WallView");
        }
    }
}