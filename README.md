# TBoxQuickFIXn
TBox封装后的.NET用的Dll，方便后续开发调用。基于.NET 6.0

主要是方便前端调用消息发送，以及delegate回调后端输出的消息。
Dll中也增加了对网络连接状态监控，状态改变也会回调到前端

麻烦的点主要是新增持仓查询的类，无法用MessageCracker来Type Safe查询，只能手动转。
