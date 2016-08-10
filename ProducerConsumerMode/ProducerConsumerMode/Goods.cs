// ******************************************************
// 文件名（FileName）:               Goods.cs  
// 功能描述（Description）:          此文件主函数。
// 数据表（Tables）:                 nothing
// 作者（Author）:                   wangxingping
// 日期（Create Date）:              2016-08-09
// 修改记录（Revision History）:     
// ******************************************************

namespace ProducerConsumerMode
{
    /// <summary>
    /// 具体的产品类
    /// </summary>
    public class Goods
    {
        private string name;//产品名字
        private string creator;//生产者
        private int sellPrice;//卖价

        /// <summary>
        /// 产品名字
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 生产者
        /// </summary>
        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        /// <summary>
        /// 卖价
        /// </summary>
        public int SellPrice
        {
            get { return sellPrice; }
            set { sellPrice = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Goods(string name, string creator, int sellPrice)
        {
            this.name = name;
            this.creator = creator;
            this.sellPrice = sellPrice;
        }
    }
}
