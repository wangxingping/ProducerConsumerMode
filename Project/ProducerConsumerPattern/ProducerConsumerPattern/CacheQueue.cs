// ******************************************************
// 文件名（FileName）:               CacheQueue.cs  
// 功能描述（Description）:          此文件用于定义读取数据。
// 数据表（Tables）:                 nothing
// 作者（Author）:                   wangxingping
// 日期（Create Date）:              2016-08-04
// 修改记录（Revision History）:     nothing
// ******************************************************
using System.Collections.Concurrent;

namespace ProducerConsumerPattern
{
    /// <summary>
    /// 缓存区类
    /// </summary>
    public class CacheQueue<T> : ConcurrentQueue<T>
    {
        /// <summary>
        /// 尝试移除并返回位于 ConcurrentQueue<T> 开始处的对象
        /// </summary>
        /// <returns></returns>
        public T TryDequeueBox()
        {
            T _obj = default(T);
            if (!this.IsEmpty)//如果队列不为空，也就是有产品
                this.TryDequeue(out _obj);

            return _obj;
        }

        /// <summary>
        /// 将添加到队列末尾处
        /// </summary>
        /// <returns></returns>
        public void EnqueueBox(T box)
        {
            {
                this.Enqueue(box);
            }
        }
    }
}
