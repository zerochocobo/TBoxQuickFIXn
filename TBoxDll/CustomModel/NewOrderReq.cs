using Microsoft.VisualBasic.FileIO;
using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBoxDll.CustomModel
{
    public class NewOrderReq
    {
        private string _symbol = "";
        private string _security_exchange = "SS";

        /// <summary>
        /// 简单的初始化
        /// </summary>
        /// <param name="clOrdID">可以用系统内的唯一订单序列编号，也可以用Guid.NewGuid().ToString()来生成全局唯一的</param>
        /// <param name="execBroker">系统内的订单序列编号</param>
        /// <param name="symbol">8位股票代码，sz或sh开头</param>
        /// <param name="side">"1 - 买入,2 - 卖出,3-融资买入,4-融券卖出,5 - 买券还券,6-卖券还款,7-零股卖出",</param>
        /// <param name="orderQty">买卖数量</param>
        /// <param name="ordType">1 - Market,  2 - Limit, 7 - LimitOrBetter(增强限价单，港股专用，59 = 0)</param>
        /// <param name="price">限价单必须填的，decimal</param>
        public NewOrderReq(string clOrdID, string execBroker, string account, string clientID, string symbol, SideEnum side, int orderQty, OrdTypeEnum ordType, decimal price)
        {
            ClOrdID = clOrdID;
            ExecBroker = execBroker;
            Account = account;
            ClientID = clientID;
            Symbol = symbol;
            Side =  side;
            OrderQty = orderQty;
            OrdType = ordType;
            Price = price;
        }

        /// <summary>
        /// 第三方生成唯一订单号
        /// </summary>
        public string ClOrdID { get; set; }
        /// <summary>
        /// 1 - Automated Execution
        /// </summary>
        public char HandlInst { get { return '1'; } }
        /// <summary>
        /// 产品编码（基金代码）
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 资金账户 对应资管系统外部账号
        /// </summary>
        public string ClientID { get; set; }
        /// <summary>
        /// Used for firm identification in third-party transactions
        /// </summary>
        public string ExecBroker { get; set; }
        /// <summary>
        /// Can contain multiple instructions, space delimited
        /// </summary>
        public string ExecInst { get; set; }
        /// <summary>
        /// SS - Shanghai Stock Exchange
        ////SZ - Shengzhen Stock Exchange
        ////BJ - Beijing StockExchange
        ////ShHK
        ////SzHK
        /// </summary>
        public string SecurityExchange { get { return _security_exchange; } set { _security_exchange = value; }  }
        /// <summary>
        /// CS - Common Stock
        //  FUT - Future
        //OPT - Option
        //REPO - REPO
        /// </summary>
        public string SecurityType { get
            {
                return "CS";//当前是固定值
            }
        }


        /// <summary>
        /// Local Code
        /// Example 000001
        /// </summary>
        public string Symbol { 
            get { return _symbol; }
            set
            {
                if (value.Length == 8)
                {
                    _symbol = value.Substring(2, 6);
                }
                if (value.ToLower().StartsWith("sz"))
                {
                    _security_exchange = "SZ";
                }
                else if(value.ToLower().StartsWith("bj"))
                {
                    _security_exchange = "BJ";
                }
                else
                {
                    _security_exchange = "SS";
                }
            }
        }
        /// <summary>
        /// 买卖方向
        /// "1 - 买入
        ////2 - 卖出
        ////3-融资买入
        ////4-融券卖出
        ////5 - 买券还券
        ////6-卖券还款
        ////7-零股卖出"
        /// </summary>
        public SideEnum Side { get; set; }
        /// <summary>
        /// 买卖数量
        /// </summary>
        public int OrderQty { get; set; }
        /// <summary>
        /// Decimal  example 56.25
        /// 当指令为限价（40=2、7）时，必须指定价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 1 - Market
        /// 2 - Limit
        /// 7 - LimitOrBetter(增强限价单，港股专用，59=0)
        /// </summary>
        public OrdTypeEnum OrdType { get; set; }
        /// <summary>
        /// "0 - Day
        /// 2-AT_THE_OPENING"	"40=2, 59=2港股的竞价限价单
        /// 暂时默认只有Day
        /// </summary>
        public TimeInForceEnum TimeInForce { get { return TimeInForceEnum.Day; } }
        /// <summary>
        /// 货币，当前固定CNY
        /// </summary>
        public string Currency { get { return "CNY"; } }
        /// <summary>
        /// 委托方的机器网络信息
        /// </summary>
        public string NetInfo { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        /// <summary>
        /// 携带原因值,        建议携带，便于运维
        /// </summary>
        public string Text { get; set; }
        public DateTime? ExpireTime { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public DateTime TransactTime { get { return DateTime.UtcNow.AddHours(8); } }
        /// <summary>
        /// "SMART：普通委托，直接报单
        /// DESK：手工确认单，
        /// ALGO：算法单"	订单类型，默认SMART
        /// </summary>
        public string Strategy { get; set; }
        public string StrategyParam { get; set; }
    }
}
