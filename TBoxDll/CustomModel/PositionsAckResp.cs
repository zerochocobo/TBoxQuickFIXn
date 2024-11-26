using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBoxDll.CustomModel
{
    public class PositionsAckResp
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
        public string Account { get; set; }

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
