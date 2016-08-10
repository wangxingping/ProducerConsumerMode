﻿// ******************************************************
// 文件名（FileName）:               Program.cs  
// 功能描述（Description）:          此文件用于定义写数据类。
// 数据表（Tables）:                 nothing
// 作者（Author）:                   wangxingping
// 日期（Create Date）:              2016-08-02
// 修改记录（Revision History）:     nothing
// ******************************************************
using System;
using System.Collections.Generic;

namespace ProducerConsumerMode
{
    class Program
    {
        /// <summary>
        /// 锁的对象
        /// </summary>
        public static object ObjectLock = new object();

        /// <summary>
        /// 公用的队列
        /// </summary>
        private static Queue<Goods> queue = new Queue<Goods>();

        static void Main(string[] args)
        {
            //下面使用CacheData初始化Producer和Consumer两个类，生产和消费次数均为20次
            Producer producerA = new Producer(queue, 5);
            Consumer consumerA = new Consumer(queue, 5);

            producerA.thread.Name = "生产工人A线程";
            consumerA.thread.Name = "消费者A线程";

            //生产者任务和消费者任务都已经被创建，但是没有开始执行 
            try
            {
                //启动
                producerA.thread.Start();
                consumerA.thread.Start();

                producerA.thread.Join();
                consumerA.thread.Join();

                Console.ReadLine();
            }
            catch (AggregateException ex)
            {
                foreach (var str in ex.InnerExceptions)
                {
                    Console.WriteLine(str.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
