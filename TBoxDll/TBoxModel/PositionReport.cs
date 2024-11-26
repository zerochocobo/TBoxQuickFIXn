using QuickFix.Fields;
using QuickFix;

namespace TBoxDll.TBoxModel
{
    /// <summary>
    /// 其实没啥用，暂时无法注入DLL进行类型安全调用
    /// </summary>
    public class PositionReport : Message
    {
        public const string MsgType = "AP";

        public PositionReport()
        {
            base.Header.SetField(new MsgType("AP"));
        }

        public PositionReport(PosMaintRptID posMaintRptID)
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

        public SecurityExchange SecurityExchange
        {
            get
            {
                SecurityExchange field = new SecurityExchange();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public Symbol Symbol
        {
            get
            {
                Symbol field = new Symbol();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public SettlCurrency SettlCurrency
        {
            get
            {
                SettlCurrency field = new SettlCurrency();
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

        public ClientID ClientID
        {
            get
            {
                ClientID field = new ClientID();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public Currency Currency
        {
            get
            {
                Currency field = new Currency();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public SettlPrice SettlPrice
        {
            get
            {
                SettlPrice field = new SettlPrice();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public LeavesQty LeavesQty
        {
            get
            {
                LeavesQty field = new LeavesQty();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public BuyVolume BuyVolume
        {
            get
            {
                BuyVolume field = new BuyVolume();
                GetField(field);
                return field;
            }
            set
            {
                SetField(value);
            }
        }

        public SellVolume SellVolume
        {
            get
            {
                SellVolume field = new SellVolume();
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
