# Socket-Vs-WebSocket-TestTool
一个用 C# 写的 Socket 和 WebSocket 性能测试工具



这个项目不是计划内的 。 我要 呵呵 了 。 因为 QQ 群里有网友提到 “WebSocket 的效率比 Socket 低” ， 所以就想看一下实际情况到底怎么样 。

解决方案 里 包含 4 个项目， SocketTest , SocketTestTool , WebSocketTest , WebSocketTestTool 。 

SocketTest :  Socket 测试的服务器端

SocketTestTool :  Socket 并发测试工具

WebSocket :  WebSocket 测试的服务器端

WebSocketTestTool :  WebSocket 并发测试工具


测试原理 ： 测试工具发送 2 个 Byte 的数据 “aa” 到 服务器端 ， 服务器端收到数据后会发这 2 个 Byte 的数据给测试工具，测试工具接收到回发数据算一次请求完成 。 本次请求完成后才会发出下一次请求 。

测试结果 ：    

Socket : 每秒请求数最高可达到 25000 ， CPU 占用率 ： 测试工具 15% , 服务器端 22% , System进程 27%

WebSocket : 每秒请求数最高可达 7500 - 8000 ， CPU 占用率 ： 测试工具 26% , 服务器端 44% , System进程 7%

注 ： System 进程 应该就是 Win Socket 工作线程所在的进程 。

从这组测试数据看起来 ， WebSocket 的效率大概是 Socket 的 1/3 - 1/4 之间 。

有一个现象值得注意 ： 在测试中 ， Socket 组 的 CPU 占用率普遍低于 WebSocket 组 ， 还有一点 ， Socket 测试中 CPU 占用率最高的是 System 进程 ， 而 WebSocket 测试中 CPU 占用率 最高的是 服务器端 进程 ， 并且 System 进程的 CPU 占用率 最低 和 很低 。













