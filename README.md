# Socket-Vs-WebSocket-TestTool
一个用 C# 写的 Socket 和 WebSocket 性能测试工具



这个项目不是计划内的 。 我要 呵呵 了 。 因为 QQ 群里有网友提到 “WebSocket 的效率比 Socket 低” ， 所以就想看一下实际情况到底怎么样 。

解决方案 里 包含 4 个项目， SocketTest , SocketTestTool , WebSocketTest , WebSocketTestTool 。 

SocketTest :  Socket 测试的服务器端

SocketTestTool :  Socket 并发测试工具

WebSocket :  WebSocket 测试的服务器端

WebSocketTestTool :  WebSocket 并发测试工具


测试原理 ： 测试工具发送 2 Byte 的数据 “aa” 到 服务器端 ， 服务器端收到数据后回发这 2 Byte 的数据给测试工具，测试工具接收到回发数据算一次请求完成 。 本次请求完成后才会发出下一次请求 。

测试结果 ：    

Socket : 每秒请求数最高可达到 25000 ， CPU 占用率 ： 测试工具 15% , 服务器端 22% , System进程 27%

WebSocket : 每秒请求数最高可达 7500 - 8000 ， CPU 占用率 ： 测试工具 30% , 服务器端 48% , System进程 7%

注 ： System 进程 应该就是 Win Socket 工作线程所在的进程 。

从这组测试数据看起来 ， WebSocket 的效率大概是 Socket 的 1/3 - 1/4 之间 。

有一个现象值得注意 ： 在测试中 ， Socket 组 的 CPU 占用率普遍低于 WebSocket 组 ， 还有一点 ， Socket 测试中 CPU 占用率最高的是 System 进程 ， 而 WebSocket 测试中 CPU 占用率 最高的是 服务器端 进程 ， 并且 System 进程的 CPU 占用率 最低 和 很低 。

好的 ， 上面是测试结果 。

下面对 测试工具 和 服务器端 程序作一些说明 ：

WebSocketTest.exe 需要 “以管理员身份运行” ， 不然会报 “拒绝访问” 的异常 。

测试工具 界面上有一个 文本框 “连接数” ， 默认值 是 800 。

还有一个 文本框 “线程数” ， 这个文本框的默认值是 4 ， “线程数” 的 意思是 用于发送测试请求 的 线程数 ，通常设定为和 CPU 的 核数 相同即可 （可以把 虚拟线程(超线程) 算进去） 。 发送请求的线程数太多的话 ， 会占用过多的 CPU 资源 ， 同时 测试表现 会下降 。

还有一个 文本框 “发送内容” ， 默认值是 “aa” ， 目前 服务器端 的 程序 写死只接收 2 Byte 的数据 ， 如果要发送更长的内容 ， 服务器端 程序 需要相应的作一些修改 ， 不然超出 2 Byte 的数据会在 Socket 和 WebSocket 的 缓冲区 里 堆积 起来 。  



这次还发现了一些有趣的东西 ：  

async await 有些鸡肋 。 Thread , Monitor , Task , Task.Wait() 可以很好的完成 异步工作 。 async await 增加了 语言 的 复杂性 和 目标代码 的 复杂性 。 希望通过 async 一个 关键字 就能使一个 普通方法 变成 异步方法 ， 这个想法很好 。 通过 await 来完成 等待异步调用 的 设计也很好 。 但 async 和 await 两者 应该可以单独使用 ， 彼此之间不必有关联 。 这样的话 ， 用 async 关键字就可以很容易的使一个方法变成 异步方法 ， 而用 await 也可以很方便的 等待 异步方法 的 调用 。 两者之间不必有什么关联 。 实际上 ， async await 要解决的 ，或者说 适合解决 的 一个场景 是 AJAX 里 充满异步调用 的 场景 。 在 AJAX 里 ， 几乎每个事件都有 异步调用 ， 每个 事件函数 都 对应 回调函数 ， 只要有和服务器的交互的话 。 async await 可以来解决这样的场景 。 让 AJAX 事件函数里访问服务器的 WebApi 和 后端代码里访问 数据库 一样 ， 同步执行 ， 顺序执行 。 但 async await 之间不必有关联 。 实际上 ， async 方法里 必须 有 await 正是 async await 的 败笔 所在 。




从这个项目中 ， 我们再次体会到 ， 测试 是 一个 专业 ， 是 和 开发 不可分割 的 一部分 ， 和 开发 一起组成 软件生产力 。 测试 是 DevOps 的 主干力量 。




































