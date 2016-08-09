// ******************************************************
// 文件名（FileName）:               Program.cs  
// 功能描述（Description）:          此文件主函数。
// 数据表（Tables）:                 nothing
// 作者（Author）:                   wangxingping
// 日期（Create Date）:              2016-08-02
// 修改记录（Revision History）:     nothing
// ******************************************************
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerPattern
{
    /// <summary>
    /// 主方法类
    /// </summary>
    class Program
    {
        /// <summary>
        /// 多任务共同操作的队列
        /// </summary>
        private static CacheQueue<Goods> ProductsQueue = new CacheQueue<Goods>();

        static void Main(string[] args)
        {
            //下面使用CacheData初始化Producer和Consumer两个类，生产和消费次数均为20次
            Producer producerA = new Producer(ProductsQueue, 10);
            Producer producerB = new Producer(ProductsQueue,10);
            Consumer consumerA = new Consumer(ProductsQueue, 12);
            Consumer consumerB = new Consumer(ProductsQueue, 12);

            producerA.thread.Name = "生产工人A线程";
            producerB.thread.Name = "生产工人B线程";
            consumerA.thread.Name = "消费者A线程";
            consumerB.thread.Name = "消费者B线程";

            //生产者任务和消费者任务都已经被创建，但是没有开始执行 
            try
            {
                //启动
                producerA.thread.Start();
                producerB.thread.Start();
                consumerA.thread.Start();
                consumerB.thread.Start();

                producerA.thread.Join();
                producerB.thread.Join();
                consumerA.thread.Join();
                consumerB.thread.Join();

                Console.ReadLine();
            }
            catch (AggregateException ex)
            {
                foreach(var str in ex.InnerExceptions)
                {
                    Console.WriteLine(str.Message);
                }
            }
        }
    }
}