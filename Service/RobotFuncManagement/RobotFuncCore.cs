using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Models;
using TelebotStandBy.Service.RobotImpleFunc;

namespace TelebotStandBy.Service.RobotFuncManagement
{
    public abstract class RobotFuncCore: IReplyToUser,IRobotApi
    {
        private ICmder _cmder;
        private IRecord _record;
        private IPayUrl _payUrl;
        private IPaySet _paySet;
        private IReply_To_Message _reply_To_Message;
        private IForward _forward;
        protected TelebotReply _telebotReply;


        //預設的實現細節
        //RobotxxxMethod 裡面的東西才是實作細節
        public RobotFuncCore(TelebotReply telebotReply)
        {
            _telebotReply = telebotReply;
            _cmder = new RobotCmderMethod(this);
            _record = new RobotRecordMethod(this);
            _payUrl = new RobotUrlMethod(this);
            _paySet = new RobotPaySetMethod(this);
            _reply_To_Message = new RobotReplyMsgMethod(this);
            _forward = new RobotForwardMethod(this);


        }


        protected void Set_cmder<T>(T apiMethod) where T : ApiMethod, ICmder
        {
            _cmder = apiMethod;
        }

        protected void Set_record<T>(T apiMethod) where T : ApiMethod, IRecord
        {
            _record = apiMethod;
        }

        protected void Set_payUrl<T>(T apiMethod) where T : ApiMethod, IPayUrl
        {
            _payUrl = apiMethod;
        }

        protected void Set_paySet<T>(T apiMethod) where T : ApiMethod, IPaySet
        {
            _paySet = apiMethod;
        }

        protected void Set_reply_To_Message<T>(T apiMethod) where T : ApiMethod, IReply_To_Message
        {
            _reply_To_Message = apiMethod;
        }

        protected void Set_forward<T>(T apiMethod) where T : ApiMethod, IForward
        {
            _forward = apiMethod;
        }


        public void RobotApi(int userid, string text)
        {
            _telebotReply.RobotApi(userid, text);
        }

        //實作的細節

        /// <summary>
        /// 新增用戶
        /// </summary>
        /// <param name="who"></param>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public virtual void AddUser(string who, int userid, string text)
        {
            _cmder.AddUser(who, userid, text);
        }
        /// <summary>
        /// 新增白名單
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public virtual void AddWhite(int userid, string text)
        {
            _cmder.AddWhite(userid, text);
        }


        /// <summary>
        /// 輸入 cmder 指令
        /// </summary>
        /// <param name="cmder"></param>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        /// <param name="who"></param>
        /// <param name="freespace"></param>
        public virtual void CheckCmder(string cmder, int userid, string text, string who, string freespace = "")
        {
            switch (cmder)
            {
                case "/cmder":
                    Cmder(userid);
                    break;
                case "/querywhite":
                    QueryWhite(userid, text);
                    break;
                case "/addwhite":
                    AddWhite(userid, text);
                    break;
                case "/deletewhite":
                    DeleteWhite(userid, text);
                    break;
                case "/adduserid":
                    AddUser(who, userid, text);
                    break;
                case "/deleteuserid":
                    DeleteUser(who, userid, text);
                    break;
                case "/queryuserid":
                    QueryUserID(who, userid);
                    break;
            }
        }

        /// <summary>
        /// 查詢 cmder 指令
        /// </summary>
        /// <param name="userid"></param>
        public virtual void Cmder(int userid)
        {
            _cmder.Cmder(userid);
        }
        /// <summary>
        /// 刪除用戶
        /// </summary>
        /// <param name="who"></param>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public virtual void DeleteUser(string who, int userid, string text)
        {
            _cmder.DeleteUser(who, userid, text);
        }
        /// <summary>
        /// 刪除白名單
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public virtual void DeleteWhite(int userid, string text)
        {
            _cmder.DeleteWhite(userid, text);
        }
        /// <summary>
        /// 查詢用戶
        /// </summary>
        /// <param name="who"></param>
        /// <param name="userid"></param>
        public virtual void QueryUserID(string who, int userid)
        {
            _cmder.QueryUserID(who, userid);
        }
        /// <summary>
        /// 查詢白名單
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public virtual void QueryWhite(int userid, string text)
        {
            _cmder.QueryWhite(userid, text);
        }

        /// <summary>
        /// 查詢訂單號
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="record"></param>
        public virtual void QueryRecord(int userid, string record)
        {
            _record.QueryRecord(userid, record);
        }

        /// <summary>
        /// 查詢網關
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="payUrl"></param>
        public virtual void QueryPayUrl(int userid, string payUrl)
        {
            _payUrl.QueryPayUrl(userid, payUrl);
        }

        /// <summary>
        /// 查詢支付方式
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public virtual void QueryPaySet(int userid, string text)
        {
            _paySet.QueryPaySet(userid, text);
        }

        /// <summary>
        /// 回覆訊息、廣播
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="text"></param>
        /// <param name="sticker"></param>
        public virtual void ReplyMessage(Reply_To_Message reply, string text, Sticker sticker)
        {
            _reply_To_Message.ReplyMessage(reply, text, sticker);
        }

        /// <summary>
        /// 轉發機器人的訊息加白名單
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public virtual void RobotAddWhite(int userid, string text)
        {
            _forward.RobotAddWhite(userid, text);
        }
    }
}