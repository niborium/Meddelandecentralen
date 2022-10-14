using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meddelandecentralen.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public enum Messagetype
        {
          Workorder,
          Chat
        }
        public Messagetype MessagetypeSetting { get; set; }
        public string Room { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Assigned { get; set; }

        public MessageModel(Guid id, string date, Messagetype messagetypesetting, string room, string author,string message, string status, string assigned)
        {
          Id = id;
          Date = date;
          MessagetypeSetting = messagetypesetting;
          Room = room;
          Author = author;
          Message = message;
          Status = status;
          Assigned = assigned;
        }
    }
}