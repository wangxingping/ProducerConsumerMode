// ******************************************************
// 文件名（FileName）:               Producer.cs  
// 功能描述（Description）:          此文件用于定义写数据类。
// 数据表（Tables）:                 nothing
// 作者（Author）:                   wangxingping
// 日期（Create Date）:              2016-08-02
// 修改记录（Revision History）:     nothing
// ******************************************************

using System;
using System.Collections.Concurrent;
using System.Threading;
namespace ProducerConsumerPattern
{
    /// <summary>
    /// 生产者类
    /// </summary>
    public class Producer
    {
        /// <summary>
        /// 数据存放的队列
        /// </summary>
        private CacheQueue<Goods> ProductsQueue;

        /// <summary>
        /// 工作线程
        /// </summary>
        public Thread thread;

        /// <summary>
        /// 次数
        /// </summary>
        private int Number;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="number"></param>
        public Producer(CacheQueue<Goods> productsQueue, int number)
        {
            this.ProductsQueue = productsQueue;
            this.thread = new Thread(new ThreadStart(Produce));
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
        ///生产函数
        /// </summary>
        public void Produce()
        {
            Goods goods;
            for (int i = 0; i < Number; i++)
            {
                goods = new Goods(i.ToString(), "wang" + i.ToString(), i);
                //添加
                ProductsQueue.Enqueue(goods);
                Console.WriteLine(thread.Name + "生产的物品：" + "产品名字:" + goods.Name + "生产者名字：" + goods.Creator + "卖价:" + goods.SellPrice);
            }
        }
    }
}
