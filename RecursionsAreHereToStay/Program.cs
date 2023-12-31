﻿
namespace RecursionsAreHereToStay
{
    internal class Program
    {

        /// <summary>
        /// מחלקה המיצגת שקית קליק.
        /// אנחנו לא יודעים כמה כדורים יש בשקית
        /// פעולות:
        /// 1. האם השקית ריקה?
        /// לקחת כדור אחד מהשקית.2
        /// </summary>
        public class Klik
        {
            private int balls;

            static Random rnd=new Random();
            public Klik()
            {
                balls=rnd.Next(10);
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

        /// <summary>
        /// בתהליך רגיל- נרוץ בלולאה עד שהשקית מתרוקנת
        /// 
        /// </summary>
        /// <param name="klik"></param>
        /// <returns></returns>
        public static int HowMany(Klik klik)
        {
            int counter = 0;
            while (!klik.IsEmpty())
            {
               counter+= klik.TakeOne();    
                }
            return counter;
        }

        /// <summary>
        /// התהליך הרקורסיבי בנוי על כך שבמקום לולאה מתבצעות קריאות
        /// בכל פעם אותה קריאה רק עם בעיה יותר קטנה.
        /// הקריאה הקודמת לא מסתיימת עד שמתקבלת תשובה מהקריאה הבאה
        /// והתהליך כאשר הגענו לבעיה שיש לנו עליה פתרון
        /// ואנו מתבססים על הפתרון הזה כדי להחזיר תשובה לכל אחת מהקריאות 
        /// 
        /// 
        /// </summary>
        /// <param name="klik"></param>
        /// <returns></returns>
        public static int HowManyRecursive(Klik klik)
        {
            //תנאי עצירה - השקית ריקה
            if(klik.IsEmpty())
                return 0;//יודעים בוודאות שבשקית ריקה יש 0 קליקים
            //צעד הרקורסיה- זה הקליק שהוצאתי  + כמה שנשאר בשקית
            return klik.TakeOne() +HowManyRecursive(klik);
        }
       
        static void Main(string[] args)
        {

            //Klik klik = new Klik();
            //Console.WriteLine(HowManyRecursive(klik));

            Console.WriteLine("Please enter number");
            int num=int.Parse(Console.ReadLine());
            int result1 = RecurssionSamples.CountDigitsV1(num);
            int result2 = RecurssionSamples.CountDigitsV2(num);
            bool result3 = RecurssionSamples.IsExistV1(num, 4);
            bool result4 = RecurssionSamples.IsExistV2(num, 4);
            Console.WriteLine(RecurssionSamples.Mana(8, 4));
            Console.WriteLine(RecurssionSamples.Mana(-8, 4));
            Console.WriteLine(RecurssionSamples.Mana(-8, -4));
            Console.WriteLine(RecurssionSamples.Mana(3, 4));
            Console.WriteLine(RecurssionSamples.Mana(0, 4));







        }
    }
}