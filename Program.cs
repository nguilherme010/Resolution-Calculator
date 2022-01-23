using System;

namespace res_calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Início:
            Console.Title = "Resolution Calculator";
            string input;
            Console.WriteLine("Menu: \n1. Convert Resolution to Aspect Ratio\n2. Discover Aspect Ratio");
            input = Console.ReadLine();
            int menuOpt = Convert.ToInt32(input);

            if(menuOpt == 1)
            {
                Console.Clear();
                goto ConvertRes;
            }
            else if(menuOpt == 2)
            {
                Console.Clear();
                goto discoverAR;
            }
            else
            {
                Console.Clear();
                goto Início;
            }

            discoverAR:
            Console.WriteLine("Discover Aspect Ratio");
            Console.WriteLine("Input width:");
            double width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input height:");
            double height = Convert.ToDouble(Console.ReadLine());

            bool posNeg;

            if (width > height)
            {
                posNeg = true;
            }
            else{
                posNeg = false;
            }

            double arFrac;
            if (posNeg == true)
            {
                arFrac = width / height;
            }
            else{
                arFrac = height / width;
            }

            double arFracRounded = Math.Round(arFrac, 3, MidpointRounding.ToZero);
            bool commonAR = false;
            string [] ratiosFrac = {"1.777", "1.333", "1.6", "2.333"};
            string [] ratios = {"16:9", "4:3", "16:10", "21:9"};
            int arrInd = 0;

            for (int i = 0; i < ratios.Length; i++)
            {
                commonAR = Convert.ToBoolean(arFracRounded == Convert.ToDouble(ratiosFrac[i]));
                if (commonAR == true)
                {
                arrInd = i;
                break;
                }
            }


            if (commonAR == true)
            {
            Console.WriteLine("Ratio of " + width + "x" + height + " is " + ratios[arrInd]);
            }
            else{
                Console.WriteLine("Ratio of " + width + "x" + height + " is " + arFracRounded + ":1");
            }

            if (Console.ReadKey().Key == ConsoleKey.R)
            {
                Console.Clear();
                goto Início;
            }
            else if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                goto RealEnding;
            }

            RealEnding:
            {}

            ConvertRes:

            Console.WriteLine("Convert Resolution to Aspect Ratio");
            Console.WriteLine("Input Aspect Ratio (16:9, for example):");
            string aspRat = Console.ReadLine();
            int indexAspRat = aspRat.IndexOf(":");
            double aspWidth = Convert.ToDouble(aspRat.Substring(0, indexAspRat));
            double aspHeight = Convert.ToDouble(aspRat.Substring(indexAspRat + 1));

            double aspFrac;
            if(aspWidth > aspHeight)
            {
            aspFrac = Convert.ToDouble(aspWidth) / Convert.ToDouble(aspHeight);
            }
            else{
            aspFrac = Convert.ToDouble(aspHeight) / Convert.ToDouble(aspWidth);
            }

            Console.WriteLine("Input Resolution (1920x1080, for example): ");
            string res = Console.ReadLine();
            int indexres = res.IndexOf("x");
            int resWidth = Convert.ToInt32(res.Substring(0, indexres));
            int resHeight = Convert.ToInt32(res.Substring(indexres + 1));

            double newWidth1 = resHeight * aspFrac;
            double newHeight1 = resWidth / aspFrac;

            Console.WriteLine("\nConversion:");
            Console.WriteLine(newWidth1 + "x" + Convert.ToInt32(resHeight));
            Console.WriteLine(Convert.ToInt32(newHeight1) + "x" + resWidth);
            


            Console.WriteLine("\nPress R to restart, Enter to exit.");

            if (Console.ReadKey().Key == ConsoleKey.R)
            {
                Console.Clear();
                goto Início;
            }
            else if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                goto RealEnding;
            }
        }
    }
}
