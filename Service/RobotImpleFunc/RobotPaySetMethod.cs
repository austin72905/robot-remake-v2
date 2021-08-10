using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TelebotStandBy.Common;
using TelebotStandBy.Interface;
using TelebotStandBy.Models;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotPaySetMethod : ApiMethod, IPaySet
    {
        public RobotPaySetMethod(IRobotApi robotApi) : base(robotApi) { }
        public void QueryPaySet(int userid, string text)
        {
            DataTable dt = Verify.GetPaySetting(text);
            var paymentList = new List<ThirdInfoModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                paymentList.Add(new ThirdInfoModel 
                {
                    payName = dt.Rows[i]["PayName"].ToString(),
                    RedirectURL = dt.Rows[i]["RedirectURL"].ToString(),
                    WithdrawURL = dt.Rows[i]["WithdrawURL"].ToString(),
                    WithdrawQueryUrl = dt.Rows[i]["WithdrawQueryUrl"].ToString(),
                    PayWay = dt.Rows[i]["PayChannel"].ToString() + dt.Rows[i]["PayWay"].ToString(),
                    remark = dt.Rows[i]["remark"].ToString(),
                    WithdrawRemark = dt.Rows[i]["WithdrawRemark"].ToString(),
                    isEnabled = dt.Rows[i]["isEnabled"].ToString(),
                    WithdrawIsEnabled = dt.Rows[i]["WithdrawIsEnabled"].ToString(),
                });
            }

            string sendContent = paymentList.Count > 0 ? setContent(paymentList) : "查無資料";
            _robotApi.RobotApi(userid, sendContent);
        }


        private string setContent(List<ThirdInfoModel> paymentlist)
        {
            string sendContent = "";
            try
            {
                //三方名去重
                HashSet<string> thirdname = paymentlist.Select(o => o.payName).ToHashSet();
                foreach (var third in thirdname)
                {
                    var thirdInfo = paymentlist.Where(o => o.payName == third).Select(o => o);
                    string payMethod = string.Join(",", thirdInfo.Select(o => o.PayWay));
                    payMethod = setContent("支付方式 : ", payMethod);
                    SendThirdInfo sendThirdInfo=new SendThirdInfo();
                    foreach (var info in thirdInfo)
                    {
                        sendThirdInfo.payName = setContent("",info.payName);
                        //支付資訊(網關、支付方式、備註)
                        sendThirdInfo.paySetting = 
                            setContent("支付網關 : ", info.RedirectURL)
                            + payMethod 
                            + setContent("備註 : ", info.remark); ;
                        //代付資訊
                        sendThirdInfo.withdrawSetting = 
                            setContent("代付網關 : ", info.WithdrawURL) 
                            + setContent("查詢網關 : ", info.WithdrawQueryUrl) 
                            + setContent("密鑰綁定說明 : ", info.WithdrawRemark);
                        
                        if(info.isEnabled == "0" && info.WithdrawIsEnabled == "0")
                        {
                            sendThirdInfo.isEnabled = (!string.IsNullOrEmpty(info.RedirectURL) || !string.IsNullOrEmpty(info.WithdrawURL)) ?"此第三方目前是停用狀態": "";
                        }
                    }


                    string[] sendContentArray = new string[4] 
                    { 
                        sendThirdInfo.payName, 
                        sendThirdInfo.paySetting, 
                        sendThirdInfo.withdrawSetting, 
                        sendThirdInfo.isEnabled 
                    };

                    sendContent += string.Join($"---------------------{Environment.NewLine}", 
                        sendContentArray.Where(o => !string.IsNullOrEmpty(o)).Select(o => o));

                    sendContent +=$"{ Environment.NewLine }{ Environment.NewLine }";
                }

                return sendContent;
            }
            catch(Exception e)
            {
                _robotApi.RobotApi(0000, $"some error in setcontent, msg: {e.Message}");
                return "查無資料";
            }
        }

        private static string setContent(string format,string props)
        {
            props = !string.IsNullOrEmpty(props) ? $"{format}{props}{Environment.NewLine}" : props;
            return props;
        }

        private struct SendThirdInfo
        {
            public string payName;
            public string paySetting; 
            public string withdrawSetting; 
            public string isEnabled; 
        }

    }
}