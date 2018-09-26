using System;
using System.Collections.Generic;
using System.Linq;
using Encog.Engine.Network.Activation;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;

namespace FirstLife.Lib
{
    public class Gen
    {
        private List<LayerConfig> Layers { get; set; }
        
        private Gen(List<LayerConfig> layers)
        {
            Layers = layers;
        }

        public static Gen GenerateGen(List<LayerConfig> layers)
        {
            return new Gen(layers);
        }

        public void AddLayer(LayerConfig layerConfig)
        {
            Layers.Add(layerConfig);
        }

        public Gen Mutate()
        {
            var newLayers = Layers;
            var rnd = new Random((int) (DateTime.Now.Ticks % int.MaxValue));
            
            if (newLayers.Count > 3)
            {
                if (rnd.NextDouble() > 0.9)
                {
                    newLayers.RemoveAt(rnd.Next(newLayers.Count));
                }
            }

            if (rnd.NextDouble() > 0.90)
            {
                var bias = rnd.NextDouble() >= 0.5;
                var layer = new LayerConfig((byte) rnd.Next(0, 16), bias, rnd.Next(100) + 5);
                newLayers.Insert(rnd.Next(newLayers.Count), layer);
            }


            foreach (var g in newLayers)
            {
                g.RecalculateBias(rnd);
            }

            return new Gen(newLayers);
        }
    }
}