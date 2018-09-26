using Encog.Engine.Network.Activation;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;

namespace FirstLife.Lib
{
    public class NeuroBrain
    {
        private readonly BasicNetwork _network;
        
        private NeuroBrain(BasicNetwork network)
        {
            _network = network;
        }

        public static NeuroBrain CreateBasicBrain()
        {
            var network = new BasicNetwork();
            network.AddLayer(new BasicLayer(new ActivationReLU(), true, 4));
            return new NeuroBrain(network);
        }
    }
}