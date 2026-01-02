using System;

namespace _2200004759_TONGMINHTRIET_API
{
    public class TinhTong
    {
        private int _n;
        public int N
        {
            get { return _n; }
            set
            {
                if (value <= 0)
                {
                    _n = 0;
                }
                else
                {
                    _n = value;
                }
            }
        }

        public TinhTong(int nValue)
        {
            this.N = nValue; 
        }


        public TinhTong()
        {
            this._n = 0; 
        }

        public double CalculateSum()
        {
    
            if (this.N <= 0)
            {
                
                return 0; 
            }

            double sum = 0.0;
            for (int i = 1; i <= this.N; i++)
            {
                sum += 1.0 / i;
            }
            return sum;
        }
    }
}