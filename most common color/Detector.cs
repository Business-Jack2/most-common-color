using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections.Generic;

namespace most_common_color
{
	public class Detector
	{
        private Bitmap imgi;

        public Detector(Bitmap image)
		{
			this.imgi = image;
		}
		private String getColor(Color color)
        {
			byte R = color.R;
			byte G = color.G;
			byte B = color.B;
			if (R > 0 && R < 125)
            {
				if (G < 255 && G > 225)
                {
					if (B > 0 && B < 125)
                    {
						return "Green";
                    }
                }
            }
            if (R == 0)
            {
                if (G <= 255 && G >= 125)
                {
                    if (B <= 255 && B >= 125)
                    {
                        return "Cyan";
                    }
                }
            }
            if (R >= 200 && R <= 255)
            {
                if (G >= 125 && G <= 255)
                {
                    if (B == 0)
                    {
                        return "Yellow";
                    }
                }
            }
            if (R >= 125 && R <= 255)
            {
                if(G == 0)
                {
                    if (B >= 125 && B <= 255)
                    {
                        return "MAGENTA";
                    }
                }
            }
            if (R <= 125)
            {
				if (G <= 125)
                {
					if (B == 255)
                    {
						return "Blue";
                    }
                }
            }

			if (R >= 225)
            {
				if (G <= 125)
                {
					if(B <= 125)
                    {
						return "Red";
                    }
                }
            }
            if (R >= 0 && R <= 30)
            {
                if (G >= 0 && G <= 30)
                {
                    if (B >= 0 && B <= 30)
                    {
                        return "back in black";
                    }
                }
            }
            if(R == 37 && G == 150 && B == 190)
            {
                return "Brown";
            }
            if (R >= 176 && R <= 242)
            {
                if (G >= 110 && G <= 167)
                {
                    if (B >= 4 && B <= 46)
                    {
                        return "brownish idk i am tired";
                    }
                }
            }
            if (R >= 230 && R <= 255)
            {
                if (G >= 230 && G <= 255)
                {
                    if (B >= 230 && B <= 255)
                    {
                        return "white";
                    }
                }
            }
            return "brown";
        }
		public Dictionary<String, int> colorRetrieval()
        {
            int count = 0;
            Dictionary<String, int> monkeys = new Dictionary<String, int>();
			for (int i = 0; i < this.imgi.Width; i++)
            {
                for (int j = 0; j < this.imgi.Height; j++)
                {
                    String whatisit = getColor(this.imgi.GetPixel(i, j));
                    if (!monkeys.ContainsKey(whatisit)){
                        monkeys.Add(whatisit, 0);
                    }
                    monkeys[whatisit] = monkeys[whatisit] + 1;
                }
            }
            return monkeys;
        }
        public String ToString(Dictionary<String, int> colors)
        {
            StringBuilder str = new StringBuilder();
            foreach (KeyValuePair<String, int> color in colors)
            {
                str.Append(String.Format("{0}:{1}\n", color.Key, color.Value));
            }
            return str.ToString();
        }
        public Dictionary<String, int> SortDict(Dictionary<String, int> colors)
        {
            Dictionary<String, int> tubular = new Dictionary<string, int>();
            foreach (var color in colors.OrderByDescending(key => key.Value))
            {
                tubular.Add(color.Key, color.Value);
            }
            return tubular;
        }
        public String theMost(Dictionary<String, int> colors)
        {
            int highest = 0;
            int secondhighest = 0;
            int thirdhighest = 0;
            String notlock = "hi";
            String secondnotlock = "hi2";
            String thirdlock = "hi3";
            Console.WriteLine("please dont delete me");
            foreach ( KeyValuePair<String, int> color in colors)
            {
                if (color.Value > highest)
                {
                    highest = color.Value;
                    notlock = color.Key;
                }
            }
            foreach (KeyValuePair<String, int> color in colors)
            {
                if (highest != secondhighest && color.Value > secondhighest)
                {
                    secondhighest = color.Value;
                    secondnotlock = color.Key;
                }
            }

            // return String.Format("{0}, {1} \n {2}, {3}", notlock, highest, secondnotlock, secondhighest) ;
            return ToString(SortDict(colors));
        }
	}
}