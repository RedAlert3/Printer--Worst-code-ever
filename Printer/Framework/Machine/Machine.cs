namespace Printer.Framework.Machine
{
    public abstract class Machine
    {
        /// <summary>
        /// 机器重量
        /// </summary>
        public abstract double Weight { get; set; }

        /// <summary>
        /// 机器占地宽度
        /// </summary>
        public abstract double Width { get; set; }

        /// <summary>
        /// 机器占地长度
        /// </summary>
        public abstract double Length { get; set; }

        /// <summary>
        /// 机器占地高度
        /// </summary>
        public abstract double Height { get; set; }

        /// <summary>
        /// 启动机器
        /// </summary>
        public abstract void Start(Energy.Energy energy);

        /// <summary>
        /// 机器开始工作
        /// </summary>
        public abstract void Work(Action act);

        /// <summary>
        /// 机器停止工作
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// 向机器输入
        /// </summary>
        /// <param name="input">内容</param>
        public abstract void Input(object input);

        /// <summary>
        /// 获取机器输出
        /// </summary>
        /// <returns>输出内容</returns>
        public abstract object Output();

        /// <summary>
        /// 机器的工作队列
        /// </summary>
        public abstract Queue<object> WorkingQueue { get; set; }

        /// <summary>
        /// 并行处理数量
        /// </summary>
        public abstract int SameTimeProcessNum { get; set; }

        /// <summary>
        /// 消耗能量
        /// </summary>
        /// <param name="energy">能量</param>
        public abstract void ResumeEnergy(Energy.Energy energy);
    }
}
