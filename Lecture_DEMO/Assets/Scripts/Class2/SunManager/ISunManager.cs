namespace Class2.SunManager
{
    public interface ISunManager
    {
        public void SunReduce(int sunCost);

        /// <summary>
        /// 获取阳光管理器里面的阳光数量
        /// </summary>
        /// <returns>返回值是阳光的数量</returns>
        public int GetSunValue();
    }
}