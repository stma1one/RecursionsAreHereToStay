using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionsAreHereToStay
{
    //מחחקה סטטית כי כל הפעולות הן סטטיות
    public static class RecurssionSamples
    {

        #region פעולות רקורסיביות סופרות
        /// <summary>
        /// פעולה הסופרת מספר ספרות
        /// אם המספר קטן מ-10 המשמעות היא שמדובר במספר בעל ספרה 1=תנאי העצירה
        /// כל עוד יש ספרות במספר- נספור את הספרה הנוכחית + כמות הספרות שיש בלי הספרה האחרונה

        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int CountDigitsV1(int num)
        {
            if (Math.Abs(num) < 10)
                return 1;
            return 1 + CountDigitsV1(num / 10);
        }

        /// <summary>
        /// על אותו עיקרון אם כאשר נקצץ את הספרה האחרונה נקבל 0
        /// המשמעות היא שקיימת רק ספרה אחת במספר - תנאי עצירה
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int CountDigitsV2(int num)
        {
            if (Math.Abs(num)/10 == 0)
                return 1;
            return 1 + CountDigitsV2(num / 10);
        }
        #endregion


        #region פעולות רקורסיביות סוכמות
        /// <summary>
        /// תנאי עצירה - כאשר הגענו לספרה בודדת
        /// סכום של ספרה בודדת הוא הספרה עצמה!
        /// כל עוד לא הגענו לתנאי עצירה 
        /// הסכום הוא ספרת האחדות + הסכום הספרות של שאר המספר
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int SumDigits(int num)
        {
            if (Math.Abs(num) < 10)
                return num;
            return num%10 + SumDigits(num / 10);
        }
        #endregion

        #region פעולות בוליאניות
        //א. לבדוק שתמיד יש לנו 
        //לפחות אחד מכל אופציה
        //return true;
        //return false;
        //ב. לא לשכוח קריאה רקורסיבית


        public static bool IsExistV0(int num, int digit)
        {
            //אם ספרה בודדת- נחזיר אמת אם היא שווה לספרה ושקר אחרת
            if (num == 0)
            {
                if (digit == 0)
                    return true;
                return false;
            }
                 
            //אם המספר יותר מספרה אחת, נבדוק האם ספרת האחדות זהה לספרה שמחפשים
            if (num % 10 == digit)
                return true;
            //אם לא זהה- נמשיך לחפש בשאר המספר
            return IsExistV0(num / 10, digit);
        }
        public static bool IsExistV1(int num,int digit)
        {
            //אם ספרה בודדת- נחזיר אמת אם היא שווה לספרה ושקר אחרת
            if (num / 10 == 0)
                return num == digit;
            //אם המספר יותר מספרה אחת, נבדוק האם ספרת האחדות זהה לספרה שמחפשים
            if (num % 10 == digit)
                return true;
            //אם לא זהה- נמשיך לחפש בשאר המספר
            return IsExistV1(num/10, digit);  
        }
        public static bool IsExistV2(int num,int digit)
        {
            //אם ספרה בודדת- נחזיר אמת אם היא שווה לספרה ושקר אחרת
            if (num / 10 == 0)
                return num == digit;
            //אם המספר יותר מספרה אחת, נבדוק האם ספרת האחדות זהה לספרה שמחפשים
            //או שהיא קיימת בשאר המספר

            //חשבו-----> האם משנה אם נהפוך את סדר הבדיקה בתנאים
            //האם יש הבדל מהשורה הבאה?
            return (IsExistV2(num/10, digit)||(num%10==digit) );

            //return ((num%10==digit) || IsExistV2(num/10, digit));
        }
        #endregion

        #region שאלת מעקב
        //מה הבעיה הלוגית בפעולה הבאה
        //בצעו מעקב עבור המספרים 359
        //426
        //132
        //מה הפעולה עושה
        public static bool Kuku(int num)
        {
            if (num / 10 == 0)
                return true;
            if (num / 10 % 2 != num % 2)
                return false;
            return Kuku(num / 10);
        }

        #endregion

        //שאלה 5
        public static int Mana(int x,int y)
        {
            //אם המונה 0
            if(x==0)
                return 0;
            //אם המונה והמכנה שווים
            if (x == y)
                return 1;
            //אם המונה גדול מהמכנה
            if (Math.Abs(x) >= Math.Abs(y))
            {
                //אם שני המספרים שליליים או שניהם חיובים
                if ((x < 0 && y < 0) || (x > 0 && y > 0))
                    return 1 + Mana(x - y, y);
                //אם סימנים מנוגדים
                return (-1)*(1 +  Mana(Math.Abs(x) - Math.Abs(y), y));
            }
            //אם המכנה יותר גדול- מנת שלמים היא 0
            return 0;

        }

        public static int Fibonacchi(int n)
        {
            //האיבר הראשון הוא 0
            if(n == 0) return 0;
            //האיבר השני הוא 1
            if(n==1) return 1;  
            //כל איבר הוא סכום של שני האיברים הקודמים לו
            return Fibonacchi(n-1)+Fibonacchi(n-2); 
        }

        #region פעולות VOID
        /// <summary>
        /// פעולה תדפיס רקורסיבית את כל המספרים הזוגיים בין 2 ל-num
        /// </summary>
        /// <param name="num"></param>
        public static void PrintEvenUpToNumV1(int num)
        {
            //תנאי עצירה כשהגענו ל0 אם המספר היה זוגי או 1 אם המספר אי זוגי
            if (num == 0 || num == 1) return;
            //אם המספר זוגי נדפיס אותו ונדפיס את שאר המספרים הזוגיים בטוןח
            if (num % 2 == 0)
            {
                Console.WriteLine(num);
                PrintEvenUpToNumV1(num - 2);
            }
            //אחרת המספר הוא אי זוגי- אז לא נדפיס ונדפיס את שאר המספרים הזוגיים בטווח
            else
                PrintEvenUpToNumV1(num-1);  
        }

        public static void PrintEvenFrom2ToNum(int num)
        {

            //תנאי עצירה כשהגענו ל0 אם המספר היה זוגי או 1 אם המספר אי זוגי
            if (num == 0 || num == 1) return;
            //אם המספר זוגי נדפיס אותו ונדפיס את שאר המספרים הזוגיים בטוןח
            if (num % 2 == 0)
            {
                //קודם נבצע את הרקורסיה
                PrintEvenUpToNumV1(num - 2);
                Console.WriteLine(num);
            }
            //אחרת המספר הוא אי זוגי- אז לא נדפיס ונדפיס את שאר המספרים הזוגיים בטווח
            else
                PrintEvenUpToNumV1(num - 1);
        }
        #endregion

            #region תרגיל מהספר 1*2+2^2+3*2+4^2+...
            //פתרון חישובי - מחזיר תוצאה
            private static int SidraQuestionResult(int num)
{
   //תנאי עצירה 1*2
    if(num==1)
       {
          return num*2;                   
       }
       //אם המספר הוא זוגי - נעלה בריבוע + סכום של השאר לפי הנוסחה
     if(num%2==0)
       return  num*num + SidraQuestionResult(num-1);
        //אם אי זוגי - נחזיר את הערך * 2 + הסכום של שאר הערכים בסדרה
     return num*2+SidraQuestionResult(num-1);
}
    
     

    
   
//פתרון הדפס 
        //מדפיס את הנוסחה
        //שאלה- מה קורה אם את ההדפסות הייתי עושה לפני הקריאה הרקורסיבית?
  private static void SidraQuestion(int num)
  {
    //תנאי עצירה 1*2
    if(num==1)
       {
         Console.Write($"{num}*2");
       return;
       }
     //נצמצם את הבעיה עד שנגיע ל1
     SidraQuestion(num-1);

    //ערכים זוגיים נעלה בריבוע
     if(num%2==0)
        Console.Write($"+{num}^2");
        //ערכים אי זוגיים נכפיל
    else
        Console.Write($"+{num}*2");
   
  }
            #endregion 

        #region רקורסיה על מערכים
        #region מציאת מקסימום
        //אופציה 1 : 
        //נשתמש בפרמטרים  max,i 
        //לפרמטרים של הפעולה
        //i- למעבר על תאי המערך
        //max- למקסימום עד התא ה i
        public static int RecMaxInArray(int[] arr, int max, int i)
        {
            //תנאי עצירה כשהגענו לסוף המערך
            if (i == arr.Length)
            {
                //אם סיימנו לסרוק- נחזיר את המקסימום שמצאנו עד כה
                return max;
            }
            //אם לא הגענו לסוף נבדוק אם הערך הנוכחי גדול מהערך המקסימלי הנוכחי 
            if (arr[i] > max)
                max = arr[i];
            //נקדם את i 
            //באמצעות הקריאה הרקוסיבית שנשלח אליה את ה
            //max הנוכחי
            //והמיקום התא הבא לסריקה
            return RecMaxInArray(arr, max, i + 1);

        }

        //חלופה ב: 
        //דרך נוספת ללא העברת הפרמטר MAX
      
        //נשתמש בפעולת MATH.MAX
        //זה הערך המקסימלי מבין התא הנוכחי במערך לבין המקסימום של שאר התאים שאחריו במערך
        //המקסימום של תא האחרון במערך הוא הערך שלו עצמו כי אין עוד תאים להשוואה
        private static int RecMaxInArray(int[] arr, int i)
        {
            //המקסימום בין התא האחרון לתאריך שאחריו הוא הוא עצמו
            if (i == arr.Length - 1)
            {
                return arr[i];
            }
            //נחזיר את המקסימום שבין התא הנוכחי לאלו שבאים אחריו
            return Math.Max(arr[i], RecMaxInArray(arr, i + 1));
        }

        //חלופה ב1
        //אם נרצה פעולה שתסתיר את הפרמטר שאיתו סורקים את המערך
        //נגדיר פעולת מעטפת
        //שקוראת לפעולה הרקורסיבית
        public static int RecMaxInArray(int[] arr)
        {
            return RecMaxInArray(arr, 0);
        }
        #endregion

        #region סכום מערך
        private static int SumArray(int[] arr, int i)
        {
            //אם עוד לא הגענו לסוף המערך
            if(i<=arr.Length-1)
            {
                //הערך של תא הנוכחי + סכום של שאר תאי המערך
                return arr[i]+SumArray(arr, i+1);

            }
            //אם הגענו לסוף המערך
            return 0;
        }
        public static int SumArray(int[] arr) { return SumArray(arr, 0);}

        //מעבר מסוף המערך להתחלה
        private static int SumArrayFromEnd(int[] arr,int i)
        {
            //אם הגענו לתא הראשון במערך
            if (i == 0)
                return arr[0];
            return arr[i]+ SumArrayFromEnd(arr,i-1);    
        }
        public static int SumArrayFromEnd(int[] arr)
        { return SumArrayFromEnd(arr,arr.Length-1); }
        #endregion


        #region פעולות בוליאניות
        public static bool IsExists(int[] arr, int num, int i)
        {
            //חלופה 1
            //אם הגעתי לתא האחרון נחזיר האם הערך נמצא שם או לא נמצא
            if (i == arr.Length - 1)
                return arr[i] == num;
            /*חלופה 2
             *אם עברנו על כל התאים כולל האחרון - לא מצאנו
             * if(i==arr.Length)
             * return false;
             */

            //אופציה אחת
            //אם מצאנו את הערך בדרך
            if (arr[i] == num)
                return true;
            return IsExists(arr, num,i + 1);
            /* אופציה 2
             * כתיבה כתנאי של או
             * return arr[i]==num||IsExists(arr,num,i+1);
             */

        }
        #endregion
        #endregion

    }
}
