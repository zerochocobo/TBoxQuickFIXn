using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBoxDll.CustomModel
{
    public class ExecReportResp
    {
        /// <summary>
        /// Unique identifier of the order
        /// </summary>
        public string ClOrdID { get; set; }
        /// <summary>
        /// "针对35=F部分回报需要发送tag 41。
        /// ，其他场景中tag 11和41值保持一致"
        /// </summary>
        public string OrigClOrdID { get; set; }
        /// <summary>
        /// 唯一订单标识符
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 产品编码（基金代码）
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 客户资金帐号
        /// </summary>
        public string ClientID { get; set; }

        public string SecondaryOrderID { get; set; }
        /// <summary>
        /// Used for firm identification in third-party transactions
        /// </summary>
        public string ExecBroker { get; set; }
        /// <summary>
        /// 交易所返回的成交编号
        /// </summary>
        public string ExecID { get; set; }
        /// <summary>
        /// 0-New， 1-Cancel， 2-Correct
        /// </summary>
        public ExecTransTypeEnum ExecTransType { get; set; }
        public string ExecRefID { get; set; }
        /// <summary>
        /// Used for firm identification in third-party transactions
        /// "A - Pending New
        ////0 - New
        ////1 - Partial Fill
        ////2 - Fill
        ////4 - Cancelled
        ////6 - Pending Cancel
        ////5 - Replace
        ////8 - Rejected"
        /// </summary>
        public OrdStatusEnum ExecType { get; set; }
        /// <summary>
        /// Current state of order
        /// A - Pending New
        ////0 - New
        ////1 - Partial Fill
        ////2 - Fill
        ////4 - Cancelled
        ////6 - Pending Cancel
        ////5 - Replace
        ////8 - Rejected
        /// </summary>
        public OrdStatusEnum OrdStatus { get; set; }

        /// <summary>
        /// "Local Code        Example 000001"
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// 1 - 买入
        ////2 - 卖出
        ////3-融资买入
        ////4-融券卖出
        ////5 - 买券还券
        ////6-卖券还款
        /// </summary>
        public SideEnum Side { get; set; }
        /// <summary>
        /// 整形（但新定案发送时decimal)
        /// </summary>
        public decimal OrderQty { get; set; }
        /// <summary>
        /// dicimal，例如56.25
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 1 - Market  2 - Limit
        /// </summary>
        public OrdTypeEnum OrdType { get; set; }
        /// <summary>
        /// 0 - Day
        /// </summary>
        public TimeInForceEnum TimeInForce { get; set; }
        /// <summary>
        /// Executed quantity in this Execution Report本笔成交量
        /// </summary>
        public decimal LastQty { get; set; }
        /// <summary>
        /// Executed price in this Execution Report本笔成交执行价格
        /// </summary>
        public decimal LastPrx { get; set; }
        /// <summary>
        /// Amount of shares open for further execution剩余数量
        /// </summary>
        public decimal LeavesQty { get; set; }
        /// <summary>
        /// Currently executed shares for chain of orders已成交数量
        /// </summary>
        public decimal CumQty { get; set; }
        /// <summary>
        /// 已成交量的成交均价
        /// </summary>
        public decimal AvgPx { get; set; }
        /// <summary>
        /// "携带原因值        建议携带，便于运维"
        /// 出错时也附带错误原因
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Time the transaction represented by this ExecutionReport occurred
        /// </summary>
        public DateTime TransactTime { get; set; }
        /// <summary>
        /// Total number of shares canceled for this order撤销量
        /// </summary>
        public decimal CxlQty { get; set; }
    }
}
