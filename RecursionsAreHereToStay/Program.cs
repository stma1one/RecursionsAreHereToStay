namespace RecursionsAreHereToStay
{
    internal class Program
    {

        public class Klik
        {
            private int balls;
            static Random rnd=new Random();
            public Klik()
            {
                balls=rnd.Next(100);
            }

            public bool IsEmpty()
            {
                return balls == 0;
            }

            public int TakeOne()
            {
                balls--;
                return 1;

            }


        }

        public static int HowMany(Klik klik)
        {
            int counter = 0;
            while (!klik.IsEmpty())
            {
                klik.TakeOne();    
                counter++; }
            return counter;
        }

        public static int HowManyRecursive(Klik klik)
        {
            if(klik.IsEmpty())
                return 0;
            return klik.TakeOne() +HowManyRecursive(klik);
        }
       
        static void Main(string[] args)
        {
            
            Klik klik = new Klik();
            Console.WriteLine(  HowManyRecursive(klik));

        }
    }
}