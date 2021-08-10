using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotCmderMethod : ApiMethod, ICmder
    {
        private IWhite _white;
        private IUser _user;

        public RobotCmderMethod(IRobotApi robotApi) : base(robotApi)
        {
            _white = new RobotWhiteMethod(robotApi);
            _user = new RobotUserMethod(robotApi);
        }

        /// <summary>
        /// 查詢用戶
        /// </summary>
        /// <param name="who"></param>
        /// <param name="userid"></param>
        public void QueryUserID(string who, int userid)
        {
            _user.QueryUserID(who, userid);
        }

        /// <summary>
        /// 新增用戶
        /// </summary>
        /// <param name="who"></param>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public void AddUser(string who, int userid, string text)
        {
            _user.AddUser(who, userid, text);
        }

        /// <summary>
        /// 刪除用戶
        /// </summary>
        /// <param name="who"></param>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public void DeleteUser(string who, int userid, string text)
        {
            _user.DeleteUser(who, userid, text);
        }

        /// <summary>
        /// 查詢cmder指令
        /// </summary>
        /// <param name="userid"></param>
        public void Cmder(int userid)
        {
            _robotApi.RobotApi(userid, "cmder 指令");
        }

        /// <summary>
        /// 查詢白名單
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public void QueryWhite(int userid, string text)
        {
            _white.QueryWhite(userid, text);
        }

        /// <summary>
        /// 新增白名單
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public void AddWhite(int userid, string text)
        {
            _white.AddWhite(userid, text);
        }
        /// <summary>
        /// 刪除白名單
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        public void DeleteWhite(int userid, string text)
        {
            _white.DeleteWhite(userid, text);
        }


        /// <summary>
        /// 輸入 cmder 指令
        /// </summary>
        /// <param name="cmder"></param>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        /// <param name="who"></param>
        /// <param name="freespace"></param>
        public void CheckCmder(string cmder, int userid, string text, string who, string freespace = "")
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

    }
}