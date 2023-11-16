using System;
using System.Collections.Generic;
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
            //return (IsExistV2(num/10, digit)||(num%10==digit) );

            return ((num%10==digit) || IsExistV2(num/10, digit));
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
            if (num / 10 % 2 == num % 2)
                return true;
            return Kuku(num / 10);
        }

        #endregion

    }
}
