using System;
using System.Collections.Generic;
using System.Linq;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotClient;

namespace TelebotStandBy.Service
{
    public abstract class TelebotReply
    {
        protected TelebotCore _telebotCore;
        protected abstract IReplyToUser _robotFuncCore { get; }

        public TelebotReply(TelebotCore telebotCore)
        {
            _telebotCore = telebotCore;

        }

        //public delegate bool ReplyCondition();

        private Dictionary<Func<bool>, Action> _conditonDic;
        protected Dictionary<Func<bool>, Action> ConditonDic
        {
            get
            {
                if (_conditonDic == null)
                {
                    _conditonDic = CreateCondionDic();
                }
                return _conditonDic;
            }
            set
            {

            }
        }

        /// <summary>
        /// 新增情境
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        protected void Add(Func<bool> condition, Action action)
        {
            ConditonDic.Add(condition, action);
        }

        ///// <summary>
        ///// 移除情境
        ///// </summary>
        ///// <param name="condition"></param>
        //protected void Remove(Func<bool> condition)
        //{
        //    ConditonDic.Remove(condition);
        //}




        /// <summary>
        /// 建立狀態 字典
        /// </summary>
        /// <returns></returns>
        private Dictionary<Func<bool>, Action> CreateCondionDic()
        {
            var condictionDic = new Dictionary<Func<bool>, Action>()
            {
                // 查訂單
                { replyRecord,replyRecordM },
                // 查支付方式
                { replyPaySet,replyPaySetM },
                // 查網關
                { replyPayUrl,replyPayUrlM },
                // 查cmder
                { replyCmder,replyCmderM },
                //回應垃圾訊息
                
            };

            return condictionDic;
        }



        /// <summary>
        /// 判斷回應什麼
        /// </summary>
        /// <returns></returns>
        private Action ReplyFunc()
        {

            //only one function will be excute
            var condiction = ConditonDic.Where(x => x.Key() == true).FirstOrDefault().Value;

            if (checkInvaildCondition(ConditonDic))
            {
                condiction = replyTrashM;
                _telebotCore.RobotApi(10000, $"you mess up the code , input is : {_telebotCore.Text}");
            }
            //default function will reply trashtalk
            condiction = condiction == null ? replyTrashM : condiction;

            return condiction;
        }

        /// <summary>
        /// 檢查狀態字典是否被改成有兩個true
        /// </summary>
        /// <param name="keyPair"></param>
        /// <returns></returns>
        private static bool checkInvaildCondition(Dictionary<Func<bool>, Action> keyPair)
        {
            int trueCount = 0;
            foreach (var item in keyPair)
            {
                if (item.Key())
                {
                    trueCount += 1;
                }
            }

            return (trueCount > 1);
        }


        /// <summary>
        /// 回應的方法
        /// </summary>
        public void ReplyToUser()
        {
            //返回的是一個函數
            var ReplyAction=ReplyFunc();
            ReplyAction();
        }



        public virtual void RobotApi(int chat_id, string text)
        {
            _telebotCore.RobotApi(chat_id, text);
        }

        // conditions
        // 不想要判斷直接覆寫 return false
        protected virtual bool replyRecord()
        {
            return (_telebotCore.Text.StartsWith("RK") || _telebotCore.Text.StartsWith("TX") || _telebotCore.Text.StartsWith("801"));
        }

        protected virtual bool replyPaySet()
        {
            return (_telebotCore.PayName.Contains(_telebotCore.Text));
        }

        protected virtual bool replyPayUrl()
        {
            var result = _telebotCore.Text.Contains(".") && !_telebotCore.Text.StartsWith("/");
            return result;
        }



        protected virtual bool replyCmder()
        {
            return (_telebotCore.Text.StartsWith("/"));
        }



        // reply  Method
        protected void replyRecordM()
        {
            _robotFuncCore.QueryRecord(_telebotCore.UserId, _telebotCore.Text);
        }

        protected void replyPaySetM()
        {
            _robotFuncCore.QueryPaySet(_telebotCore.UserId, _telebotCore.Text);
        }

        protected void replyPayUrlM()
        {
            _robotFuncCore.QueryPayUrl(_telebotCore.UserId, _telebotCore.Text);
        }

        protected void replyCmderM()
        {
            string[] cmd = _telebotCore.Text.Split(' ');
            _robotFuncCore.CheckCmder(cmd[0], _telebotCore.UserId, _telebotCore.Text, _telebotCore.FirstName);
        }

        protected void replyTrashM()
        {
            _telebotCore.RobotApi(_telebotCore.UserId, "hi");
        }


    }
}