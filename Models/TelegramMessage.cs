using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotStandBy.Models
{
    public class TelegramMessage
    {
        public int update_id { get; set; }
        public Message message { get; set; }
    }

    public class Message
    {
        public int message_id { get; set; }

        public Chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
        public From from { get; set; }
        public Sticker sticker { get; set; }
        public Reply_To_Message reply_to_message { get; set; }
        public Forward_From forward_from { get; set; }
    }

    public class Sticker
    {
        public string file_id { get; set; }
    }

    public class From
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
        public bool is_bot { get; set; }
        public string language_code { get; set; }
    }

    public class Chat
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string username { get; set; }

        public string type { get; set; }
    }

    public class Reply_To_Message
    {
        public int message_id { get; set; }

        public int date { get; set; }

        public string text { get; set; }
    }

    public class Forward_From
    {
        public int id { get; set; }

        public bool is_bot { get; set; }

        public string first_name { get; set; }

        public string username { get; set; }
    }
}