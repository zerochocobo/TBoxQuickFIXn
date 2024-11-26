using Microsoft.VisualBasic.FileIO;
using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBoxDll.CustomModel
{
    public class OrderCancelReq
    {
        private string _symbol = "";

        public OrderCancelReq(string clOrdID,string origClOrdID,string symbol, SideEnum side)
        {
            ClOrdID = clOrdID;
            OrigClOrdID = origClOrdID;
            Symbol = symbol;
            Side = side;
        }

        /// <summary>
        /// 撤销时使用新值；
        /// </summary>
        public string ClOrdID { get; set; }
        /// <summary>
        /// 35=F撤销时，11采用新值，41使用原有值
        /// </summary>
        public string OrigClOrdID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderID { get; set; }
        public string Account { get; set; }
        public string ClientID { get; set; }
        /// <summary>
        /// CS - Common Stock
        ////FUT - Future
        ////OPT - Option
        ////REPO - REPO
        /// </summary>
        public string SecurityType { get { return "CS"; } }
        /// <summary>
        /// Local Code
        /// Example 000001
        /// </summary>
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (value.Length == 8)
                {
                    _symbol = value.Substring(2, 6);
                }
            }
        }
        public SideEnum Side { get; set; }
        public int OrderQty { get; set; }
        public OrdTypeEnum OrdType { get; set; }
        public decimal Price { get; set; }
        public string Text { get; set; }
        public TimeInForceEnum TimeInForce { get { return TimeInForceEnum.Day; } }
        public DateTime TransactTime { get { return DateTime.UtcNow.AddHours(8); } }
    }
}
