#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("WNvV2upY29DYWNvb2gotZv3gs9Nfgjbz4RH0K95zpKLGpw1RTsnLnlOFtNedB0F72D6JpxjTX6Gn6oCbr7+DKaqyHroVIGtft9XzFJV2cOhA/AuvLr11EIdYSAQ7dCUtuvWTCxVXrGD3rGrShOmeKPy468hdyU4DG523wuYyP/O+94NI8FSYJrTSXw7vOATw9xS1K3P+TivenPlCKFNUC+pY2/jq19zT8FySXC3X29vb39rZgHXM1o/eyCx1ehIW7/JgtKxKK7Gfc4I6ITeKWR5bbGDSlvmQLRVmr0I7O5ldEHUNKStgVZfN+xKbgHtiNYyqht0Jw1QtdOF7IHWVVGHKnDtA8bvZjQPSO8C0X+YaNMiBLreTRYpcBdpYubNccdjZ29rb");
        private static int[] order = new int[] { 1,7,3,10,4,6,11,10,10,10,10,13,12,13,14 };
        private static int key = 218;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
