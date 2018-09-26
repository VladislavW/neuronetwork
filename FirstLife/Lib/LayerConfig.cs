using System;

namespace FirstLife.Lib
{
    public class LayerConfig
    {
        private byte _activationType;
        private bool _hasBias;
        private int _neurons;

        public LayerConfig(byte atype, bool hasbias, int neuronscount)
        {
            _activationType = atype;
            _hasBias = hasbias;
            _neurons = neuronscount;
        }

        public void RecalculateBias(Random rnd)
        {
            _neurons += rnd.Next(_neurons / 10);
            _neurons -= rnd.Next(_neurons / 10);
            
            if (!(rnd.NextDouble() > 0.90))
            {
                return;
            }
            
            _hasBias = rnd.NextDouble() >= 0.5;
        }
    }
}