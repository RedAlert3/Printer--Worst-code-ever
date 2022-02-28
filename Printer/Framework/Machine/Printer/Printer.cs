using Printer.Framework.Material;

#pragma warning disable CS8764 // 返回类型的为 Null 性与重写成员不匹配(可能是由于为 Null 性特性)。

namespace Printer.Framework.Machine.Printer
{
    public class Printer : Machine
    {
        #region 物理属性
        public override double Weight { get; set; }
        public override double Width { get; set; }
        public override double Length { get; set; }
        public override double Height { get; set; }
        #endregion

        /// <summary>
        /// 工作队列
        /// </summary>
        public override Queue<object>? WorkingQueue { get; set; }

        /// <summary>
        /// 并行处理量
        /// </summary>
        public override int SameTimeProcessNum { get => 1; set { } }

        /// <summary>
        /// 当前工作对象
        /// </summary>
        public Paper? WorkingPaper { get; set; }

        /// <summary>
        /// 获取输入
        /// </summary>
        /// <param name="input">纸张</param>
        /// <exception cref="Exception">没有输入纸张</exception>
        public override void Input(object input)
        {
            if (input is Paper paper)
            {
                WorkingPaper = paper;
            }
            else
            {
                throw new Exception("Input must be Paper!");
            }
        }

        /// <summary>
        /// 是否正在工作
        /// </summary>
        private bool IsWorking = false;

        public bool GetWorkingStatus() => IsWorking;

        /// <summary>
        /// 获取输出
        /// </summary>
        /// <returns>纸张</returns>
        public override object? Output() => WorkingPaper;

        /// <summary>
        /// 储存的能量
        /// </summary>
        private double SavedEnergy = 0;

        /// <summary>
        /// 尝试消耗能量
        /// </summary>
        /// <param name="num">要消耗的能量数值</param>
        /// <returns>是否消耗了</returns>
        public bool CanResumeSavedEnergy(double num)
        {
            if(SavedEnergy >= num)
            {
                SavedEnergy -= num;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 返回能量信息
        /// </summary>
        /// <returns>能量信息</returns>
        public double ShowEnergyValue() { return SavedEnergy; }

        /// <summary>
        /// 消耗能量
        /// </summary>
        /// <param name="energy">能量</param>
        public override void ResumeEnergy(Energy.Energy energy) => energy.Resume(ref SavedEnergy);

        /// <summary>
        /// 开启能源
        /// </summary>
        /// <param name="energy">启动能量</param>
        public override void Start(Energy.Energy energy)
        {
            ResumeEnergy(energy);
            IsWorking = true;
        }

        /// <summary>
        /// 停止能源
        /// </summary>
        public override void Stop() => IsWorking = false;

        /// <summary>
        /// 工作
        /// </summary>
        public override void Work(Action act)
        {
            if (IsWorking)
            {
                act.Invoke();
            }
        }
    }
}

#pragma warning restore CS8764 // 返回类型的为 Null 性与重写成员不匹配(可能是由于为 Null 性特性)。
