#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("QDbKaO+pG0BexK5PaihEHkGTOhTr2VLNtqH8lX8r7xzTjz0DledWEWZvakizIFK5gPZXKDoaqEgzx4f3tynoFjUxXoXzus52c3SrtiMvFxpXynymxY0f7LeoN4fQ3PdpbBlh7MmHENgpKf6/2YF1sG/yIAqJzsMsXtf7PuqvfeIp+XG7HQnd+XmdLubER0lGdsRHTETER0dGxkrjfShUPOPZyU6I99AvYvavulOGmgBxqkr2/qyq+mehx15jzjHpViSp7ipbc2tbKXHHR962f9dMIsvPpoEB8XHaokU4PC4N8ir+TGFQONLdQ2Jr08VJdsRHZHZLQE9swA7AsUtHR0dDRkWaSy4nVfs9EKJ7IfZ24ZOfGkLiG9ZaSK/Bgp/DXURFR0ZH");
        private static int[] order = new int[] { 6,13,12,5,5,12,11,13,10,9,10,13,13,13,14 };
        private static int key = 70;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
