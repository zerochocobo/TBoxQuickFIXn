using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBoxDll.CustomModel
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrdStatusEnum
    {
        New = '0',
        PartiallyFilled = '1',
        Filled = '2',
        Cancelled = '4',
        PendingCancel = '6',
        Replaced = '5',
        Rejected = '8',
        Suspended = '9',
        PendingNew = 'A',
        Expired = 'C',
        PendingReplace = 'E',
        Unknown = 'X' // 未知状态，自己定义的，避免转换失败
    }

    /// <summary>
    /// 1 - 买入
    ////2 - 卖出
    ////3-融资买入
    ////4-融券卖出
    ////5 - 买券还券
    ////6-卖券还款
    /// 7-零股卖出
    /// </summary>
    public enum SideEnum
    {
        Buy = '1',
        Sell = '2',
        MarginBuy = '3',
        MarginSell = '4',
        BuyBack = '5',
        SellBack = '6',
        OddLotSell = '7',
        Unknown = 'X'
    }

    /// <summary>
    /// 0-New， 1-Cancel， 2-Correct
    /// </summary>
    public enum ExecTransTypeEnum
    {
        New = '0',
        Cancel = '1',
        Correct = '2',
        Unknown = 'X'
    }
    /// <summary>
    /// 1 - Market  2 - Limit, 7 - LimitOrBetter
    /// </summary>
    public enum OrdTypeEnum
    {
        Market = '1',
        Limit = '2',
        LimitOrBetter = '7',
        Unknown = 'X'
    }
    /// <summary>
    /// "0 - Day
    ///2-AT_THE_OPENING  "40=2, 59=2港股的竞价限价单"
    ///
    /// </summary>
    public enum TimeInForceEnum
    {
        Day = '0',
        AtTheOpening = '2',
        Unknown = 'X'
    }

    /// <summary>
    /// Identifies the type of request that a Cancel Reject <3> is in response to. 
    //// Valid values:
    ////1 - Order Cancel Request<F> 
    ////2 - Order Cancel/Replace Request<G>
    /// </summary>
    public enum CxlRejResponseToEnum
    {
        OrderCancelRequest = '1',
        OrderCancelReplaceRequest = '2',
        Unknown = 'X'
    }
}
