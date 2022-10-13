using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meddelandecentralen.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public enum Messagetype
        {
          Workorder,
          Chat
        }
        public Messagetype MessagetypeSetting { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Assigned { get; set; }

        public MessageModel(Guid id, DateTime date, Messagetype messagetypesetting, string author,string message, string status, string assigned)
        {
          Id = id;
          Date = date;
          MessagetypeSetting = messagetypesetting;
          Author = author;
          Message = message;
          Status = status;
          Assigned = assigned;
        }
    }
}