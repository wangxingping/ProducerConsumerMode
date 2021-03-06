﻿// ******************************************************
// 文件名（FileName）:               Consumer.cs  
// 功能描述（Description）:          此文件用于定义读取数据。
// 数据表（Tables）:                 nothing
// 作者（Author）:                   wangxingping
// 日期（Create Date）:              2016-08-09
// 修改记录（Revision History）:    
// ******************************************************
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumerMode
{
    /// <summary>
    /// 消费者类
    /// </summary>
    public class Consumer
    {
        /// <summary>
        /// 数据存放的队列
        /// </summary>
        private Queue<Goods> ConsumerQueue;

        /// <summary>
        /// 消费线程
        /// </summary>
        public Thread ConsumerThread;

        /// <summary>
        /// 加进队列的次数
        /// </summary>
        private int Number;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="number"></param>
        public Consumer(Queue<Goods> consumerQueue, int number)
        {
            this.ConsumerQueue = consumerQueue;
            this.ConsumerThread = new Thread(new ThreadStart(Consume));
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
            bool exitLoopFlag;//用于退出循环
            Goods goods;

            while (true)
            {
                lock (Program.ObjectLock)
                {
                    if (ConsumerQueue.Count > 0)
                    {
                        goods = ConsumerQueue.Dequeue();
                        //Monitor.Pulse(Program.LockObject);
                        if (goods == null)
                        {
                            continue;
                        }
                        Console.WriteLine(String.Format("{0}, 消费的物品：,产品名字：{1},生产者名字{2},卖价{3}", ConsumerThread.Name, goods.Name, goods.Creator, goods.SellPrice));
                    }
                    else
                    {
                        exitLoopFlag = Monitor.Wait(Program.ObjectLock, 1000);
                        if (!exitLoopFlag)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}

