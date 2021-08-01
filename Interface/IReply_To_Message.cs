using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Models;

namespace TelebotStandBy.Interface
{
    public interface IReply_To_Message
    {
        void ReplyMessage(Reply_To_Message reply, string text, Sticker sticker);
    }
}