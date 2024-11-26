using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBoxDll.TBoxModel
{
    /// <summary>
    /// 自己封装的新订单类，增加了一些自定义字段
    /// </summary>
    internal class TBoxNewOrderSingle:QuickFix.FIX42.NewOrderSingle
    {

        public NetInfo NetInfo
        {
            get
            {
                NetInfo param = new NetInfo();
                GetField(param);
                return param;
            }
            set
            {
                SetField(value);
            }
        }

        public IPAddress IPAddress
        {
            get
            {
                IPAddress param = new IPAddress();
                GetField(param);
                return param;
            }
            set
            {
                SetField(value);
            }
        }
        public MACAddress MACAddress
        {
            get
            {
                MACAddress param = new MACAddress();
                GetField(param);
                return param;
            }
            set
            {
                SetField(value);
            }
        }
        public Strategy Strategy
        {
            get
            {
                Strategy param = new Strategy();
                GetField(param);
                return param;
            }
            set
            {
                SetField(value);
            }
        }
        public StrategyParam StrategyParam
        {
            get
            {
                StrategyParam param = new StrategyParam();
                GetField(param);
                return param;
            }
            set
            {
                SetField(value);
            }
        }
        
    }
}
