using System;
using System.IO;
using System.Drawing;
using System.Colletions.Generic;

namespace most_common_color
{
	private Bitmap imgi;
	public class Detector
	{
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
        }
		public Dictonary<String, int> coloRetrieval()
        {
			for (int i = 0; i < this.imgi.Width; i++)
            {

            }
        }
	}
}