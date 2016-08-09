// ******************************************************
// 文件名（FileName）:               Consumer.cs  
// 功能描述（Description）:          此文件用于定义读取数据。
// 数据表（Tables）:                 nothing
// 作者（Author）:                   wangxingping
// 日期（Create Date）:              2016-08-04
// 修改记录（Revision History）:     nothing
// ******************************************************
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ProducerConsumerPattern
{
    /// <summary>
    /// 消费者类
    /// </summary>
    public class Consumer
    {
        /// <summary>
        /// 数据存放的队列
        /// </summary>
        private CacheQueue<Goods> ConsumerGoodsQueue;

        /// <summary>
        /// 消费线程
        /// </summary>
        public Thread thread;

        /// <summary>
        /// 加进队列的次数
        /// </summary>
        int Number;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="number"></param>
        public Consumer(CacheQueue<Goods> productsQueue, int number)
        {
            this.ConsumerGoodsQueue = productsQueue;
            this.thread = new Thread(new ThreadStart(Consume));
            if (number <= 0)
            {
                this.Number = 1;
            }
            else
            {
                this.Number = number;
            }
        }

        /// <summary>
        ///消费的函数
        /// </summary>
        public void Consume()
        {
            for (int i = 0; i < Number; i++)
            {
                if (ConsumerGoodsQueue == null)
                {
                    return;
                }
                Goods product;
                var str = ConsumerGoodsQueue.TryDequeue(out product);
                if (str)
                {
                    Console.WriteLine(thread.Name + "消费的物品：" + "产品名字:" + product.Name + " 生产者名字：" + product.Creator + "卖价:" + product.SellPrice);
                }
            }
        }
    }
}
