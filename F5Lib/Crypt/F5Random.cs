namespace F5.Crypt
{
	using System;

    internal class F5Random
    {
		private readonly Random random;

        public F5Random(string password)
        {
			this.random = new Random(password.GetHashCode());
        }


        /// <summary>
        /// get a random byte
        /// </summary>
        /// <returns>random signed byte</returns>
        public int GetNextByte()
        {
			Byte[] b = new Byte[1];
			random.NextBytes(b);
			return b[0];
        }

        /// <summary>
        /// get a random integer 0 ... (maxValue-1)
        /// </summary>
        /// <param name="maxValue">maxValue (excluding)</param>
        /// <returns>random integer</returns>
        public int GetNextValue(int maxValue)
        {
            int retVal = GetNextByte() | GetNextByte() << 8 | GetNextByte() << 16 | GetNextByte() << 24;
            retVal %= maxValue;
            return retVal < 0 ? retVal + maxValue : retVal;
        }
    }
}
