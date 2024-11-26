using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBoxDll.CustomModel
{
    public class PositionReportResp
    {
        /// <summary>
        /// Required field
        /// </summary>
        public string PosMaintRptID { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string PosReqID { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public int TotalNumPosReports { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string SecurityExchange { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string SettlCurrency { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string ClientID { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public decimal SettlPrice { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public decimal LeavesQty { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public decimal BuyVolume { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public decimal SellVolume { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public int EncodedTextLen { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string EncodedText { get; set; }
    }
}
