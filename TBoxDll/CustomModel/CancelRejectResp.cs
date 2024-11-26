using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBoxDll.CustomModel
{
    public class CancelRejectResp
    {
        public string ClOrdID { get; set; }
        public string OrigClOrdID { get; set; }
        public OrdStatusEnum OrdStatus { get; set; }
        public string OrderID { get; set; }
        public string Account { get; set; }
        public string Text { get; set; }
        public DateTime TransactTime { get; set; }
        public CxlRejResponseToEnum CxlRejResponseTo { get; set; }
    }
}
