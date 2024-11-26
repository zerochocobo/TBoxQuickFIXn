using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBoxDll.CustomModel
{
    public class PositionsReq
    {
        public PositionsReq(string posReqID, string account)
        {
            PosReqID = posReqID;
            Account = account; // 只有这个非必须值能筛选账号？怎么没有clientid
        }
        /// <summary>
        /// Required field
        /// </summary>
        public string PosReqID { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public DateTime TransactTime { get; set; }

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
