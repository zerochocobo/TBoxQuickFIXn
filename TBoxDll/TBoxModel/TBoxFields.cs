using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TBoxDll.TBoxModel
{
    ///TBox自定义的一些类

    /// <summary>
    /// 委托方的机器网络信息
    /// </summary>
    public sealed class NetInfo : StringField
    {
        public const int Tag = 10014;
        public NetInfo()
            : base(Tag)
        {
        }
        public NetInfo(string val)
            : base(Tag, val)
        {
        }
    }

    public sealed class IPAddress : StringField
    {
        public const int Tag = 10012;

        public IPAddress()
            : base(Tag)
        {
        }

        public IPAddress(string val)
            : base(Tag, val)
        {
        }
    }

    public sealed class MACAddress : StringField
    {
        public const int Tag = 10013;

        public MACAddress()
            : base(Tag)
        {
        }

        public MACAddress(string val)
            : base(Tag, val)
        {
        }
    }
    /// <summary>
    /// 订单类型，默认SMART
    /// "SMART：普通委托，直接报单
    /// DESK：手工确认单，
    /// ALGO：算法单"
    /// </summary>
    public sealed class Strategy : StringField
    {
        public const int Tag = 6000;

        public Strategy()
            : base(Tag)
        {
        }

        public Strategy(string val)
            : base(Tag, val)
        {
        }
    }

    /// <summary>
    /// 当6000=ALGO时候，每个算法类型有不同的参数需求，当需设置多个参数时，用:连接，由策略模块自行解析
    /// </summary>
    public sealed class StrategyParam : StringField
    {
        public const int Tag = 6001;

        public StrategyParam()
            : base(Tag)
        {
        }

        public StrategyParam(string val)
            : base(Tag, val)
        {
        }
    }
}
