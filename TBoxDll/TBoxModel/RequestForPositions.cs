using QuickFix.Fields;
using QuickFix.FIX42;

namespace TBoxDll.TBoxModel
{
    public class RequestForPositions : Message
    {
        public const string MsgType = "AN";

        public RequestForPositions()
        {
            base.Header.SetField(new MsgType("AN"));
        }

        public RequestForPositions(PosReqID posReqID)
            : this()
        {
            PosReqID = posReqID;
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

        public TransactTime TransactTime
        {
            get
            {
                TransactTime field = new TransactTime();
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
