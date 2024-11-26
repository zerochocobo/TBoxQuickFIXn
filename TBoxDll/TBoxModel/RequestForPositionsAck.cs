using QuickFix.Fields;
using QuickFix;

namespace TBoxDll.TBoxModel
{
    /// <summary>
    /// 其实没啥用，暂时无法注入DLL进行类型安全调用
    /// </summary>
    public class RequestForPositionsAck : Message
    {
        public const string MsgType = "AO";

        public RequestForPositionsAck()
        {
            base.Header.SetField(new MsgType("AO"));
        }

        public RequestForPositionsAck(PosMaintRptID posMaintRptID)
            : this()
        {
            PosMaintRptID = posMaintRptID;
        }

        public PosMaintRptID PosMaintRptID
        {
            get
            {
                PosMaintRptID field = new PosMaintRptID();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public PosReqID PosReqID
        {
            get
            {
                PosReqID field = new PosReqID();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public TotalNumPosReports TotalNumPosReports
        {
            get
            {
                TotalNumPosReports field = new TotalNumPosReports();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public Account Account
        {
            get
            {
                Account field = new Account();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public Text Text
        {
            get
            {
                Text field = new Text();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public EncodedTextLen EncodedTextLen
        {
            get
            {
                EncodedTextLen field = new EncodedTextLen();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public EncodedText EncodedText
        {
            get
            {
                EncodedText field = new EncodedText();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }
    }
}
