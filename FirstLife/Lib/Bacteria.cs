using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstLife.Lib
{
    public class Bacteria
    {
        private double _pL, _pR, _pB, _pT = 0.0; //значения движителей
        private double _sL, _sR, _sB, _sT = 0.0; //значения сенсоров

        public int Nearcount = 0;
        public int Borncount = 0;
        public int Borntimeout = 0;
        public int Starttimeout = 0;

       
        public double X { get; set; }
        public double Y { get; set; }
        public string Id = Guid.NewGuid().ToString();
        
        Random rnd = new Random((int)(DateTime.Now.Ticks%int.MaxValue ) );
        List<Bacteria> World;
        NeuroBrain NeuroBrain;
        Gen Genotype;

        public Bacteria(List<Bacteria> world,
            double x,
            double y,
            NeuroBrain brain,
            NeuroBrain neuroBrain, 
            Bacteria parent = null,
            List<LayerConfig> newgen = null)
        {
            X = x;
            Y = y;
            _pL = _pR = _pB = _pT = 0.0; 
            _sL = _sR = _sB = _sT = 0.0;
            NeuroBrain = NeuroBrain.CreateBasicBrain();
            Genotype = Gen.GenerateGen(newgen);
            
            if (newgen == null )
            {
                var maxlayers = 3 + rnd.Next(15);
                for (var i = 0; i < maxlayers; i++)
                {
                    var bias = rnd.NextDouble() >= 0.5;
                    var layer = new LayerConfig((byte)rnd.Next(0, 16), bias, rnd.Next(100) + 10);
                    Genotype.AddLayer(layer);
                }
            }
            else
            {
                Genotype = Genotype.Mutate();
            }
            
            
            World = world;
        }

       
    }
}