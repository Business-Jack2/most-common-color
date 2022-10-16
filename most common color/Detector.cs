using System;
using System.IO;
using System.Drawing;
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
			if (G < 255 && G > 225)
            {
				if (R > 0 && R < 125)
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
                if (B == 0)
                {
                    if (G >= 125 && G <= 255)
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
            if (B == 255)
            {
				if (G <= 125)
                {
					if (R <= 125)
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
            return "";
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
                    monkeys[whatisit]++;
                }
            }
            return monkeys;
        }
        public String theMost(Dictionary<String, int> colors)
        {
            int highest = 0;
            String notlock = "";
            foreach ( KeyValuePair<String, int> color in colors)
            {
                if (color.Value > highest)
                {
                    highest = color.Value;
                    notlock = color.Key;
                    Console.WriteLine(notlock);
                }
            }
            return notlock;
        }
	}
}
