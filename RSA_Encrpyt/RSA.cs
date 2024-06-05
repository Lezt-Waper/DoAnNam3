using RSA_Encrypt.RSACalculatorLib;

namespace RSA_Encrypt.RSALib
{
    public class RSA
    {
        private long privateKey;
        public long N { get; private set; }
        public long PublicKey { get; private set; }
        public long DestN { get; set; }
        public long DestPublicKey { get; set; }

        public RSA() 
        {
            Initial();
        }

        public  void Initial()
        {
            long p1 =  GeneratePrimes();
            long p2 =  GeneratePrimes();
            N = p1 * p2;
            GenerateKey((p1 - 1) * (p2 - 1));
        }

        public static long GeneratePrimes()
        {
            int prime = 0;
            Random random = new Random();
            bool isPrime = false;

            while (!isPrime)
            {
                prime = random.Next(10000, 50000);
                if (prime % 2 == 0) prime++;
                isPrime = RSACalculator.FermatPrimalityTest(prime);
            }

            return prime;
        }

        public void GenerateKey(long ring)
        {
            Random random = new Random();
            while (true)
            {
                PublicKey = random.NextInt64(10000, ring);
                if (RSACalculator.GCD(PublicKey, ring) == 1)
                {
                    break;
                }
            }

            privateKey = RSACalculator.Inverse(PublicKey, ring);
        }

        public IEnumerable<long> Encrypt(string arg)
        {
            List<long> result = new List<long>();
            long temp;

            foreach (int item in arg)
            {
                temp = RSACalculator.RemWithPower(item, DestPublicKey, DestN);
                result.Add(temp);
            }

            return result;
        }

        public string Decrypt(IEnumerable<long> arg)
        {
            string result = "";
            char temp;

            foreach (long item in arg)
            {
                temp = (char)RSACalculator.RemWithPower(item, privateKey, N);
                result += temp;
            }

            return result;
        }

        public void SetKey(long N, long P)
        {
            this.DestN = N;
            this.DestPublicKey = P;
        }
    }
}
