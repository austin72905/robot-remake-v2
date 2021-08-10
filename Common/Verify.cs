using System.Data;
using System.Data.SqlClient;

namespace TelebotStandBy.Common
{
    public class Verify
    {
        public static DataTable GetPaySetting(string payName)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@PayName",SqlDbType.VarChar){Value=payName}
                };

            DataTable dt = QueryNewDB("SELECT ThirdInfo.PayName," +
                "PayChannel.Name AS 'PayChannel'," +
                "PayWay.Name AS 'PayWay'," +
                "ThirdInfo.RedirectURL," +
                "ThirdInfo.WithdrawURL," +
                "ThirdInfo.WithdrawQueryUrl," +
                "ThirdInfo.Remark," +
                "ThirdInfo.WithdrawRemark," +
                "ThirdInfo.IsEnabled," +
                "ThirdInfo.WithdrawIsEnabled FROM ThirdPay" +
                " FULL JOIN ThirdInfo ON ThirdPay.ThirdInfoID = ThirdInfo.ID" +
                " FULL JOIN PayChannel ON ThirdPay.PayChannelID = PayChannel.ID" +
                " FULL JOIN PayWay ON ThirdPay.PayWayID = PayWay.ID" +
                "WHERE PayName=@PayName  ", parameters).Tables[0];

            return new DataTable();
        }

        public static DataTable GetPaymentUrl(string url)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@Url",SqlDbType.VarChar){Value=url}
                };

            DataTable dt = QueryNewDB("SELECT ThirdInfo.PayName," +
                "PayChannel.Name AS 'PayChannel'," +
                "PayWay.Name AS 'PayWay'," +
                "ThirdInfo.RedirectURL," +
                "ThirdInfo.WithdrawURL," +
                "ThirdInfo.WithdrawQueryUrl," +
                "ThirdInfo.Remark," +
                "ThirdInfo.WithdrawRemark," +
                "ThirdInfo.IsEnabled," +
                "ThirdInfo.WithdrawIsEnabled FROM ThirdPay" +
                " FULL JOIN ThirdInfo ON ThirdPay.ThirdInfoID = ThirdInfo.ID" +
                " FULL JOIN PayChannel ON ThirdPay.PayChannelID = PayChannel.ID" +
                " FULL JOIN PayWay ON ThirdPay.PayWayID = PayWay.ID" +
                "WHERE RedirectURL LIKE '%@Url%' OR WithdrawURL LIKE '%@Url%' ", parameters).Tables[0];

            return new DataTable();
        }

        public static DataSet GetPayRecord(string Record,int userid)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@Record",SqlDbType.VarChar){Value=Record},
                    new SqlParameter("@Status",SqlDbType.TinyInt){Value=0}
                };

            DataSet dt = QueryNewDB("SELECT * FROM ThirdRecode WHERE Record=@Record AND Status!=@Status",parameters);
            return new DataSet();
        }


        public static DataSet QueryNewDB(string SQLString, params SqlParameter[] cmdParams)
        {
            return new DataSet();
        }
    }
}