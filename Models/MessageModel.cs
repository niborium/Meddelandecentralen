using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meddelandecentralen.Models
{
    public class MessageModel
    {
        //Read-only static (Generates Guid and return DateTime)
        public static Guid Id { get { return Guid.NewGuid(); } }
        public static DateTime Date { get { return DateTime.Now; } }
        //Fields
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

        public MessageModel(Messagetype messagetypesetting, string author,string message, string status, string assigned)
        {
            MessagetypeSetting = messagetypesetting;
            Author = author;
            Message = message;
            Status = status;
            Assigned = assigned;
        }
    }
}