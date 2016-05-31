using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTest
{
    public class Matrix
    {
        public static void rotateMatrix()
        {
            for (int r = 0; r < 5; r++)
                for (int c = 0; c < 5; c++)
                {
                    //b[4 - c][r] = a[r][c];
                }
        }
    }
}


/*
if (choice==1)
{
	//fill array b, turn array a 90 degrees
	for (r=0;r<5;r++)
			for (c=0;c<5;c++)
				b[4-c][r]=a[r][c];
}
if (choice==2)
{
	//fill array b, turn array a 180 degrees
	for (r=0;r<5;r++)
			for (c=0;c<5;c++)
				b[4-r][4-c]=a[r][c];
}
if (choice==3)
{
	//fill array b, turn array a 270 degrees
	for (r=0;r<5;r++)
			for (c=0;c<5;c++)
				b[c][4-r]=a[r][c];
}
*/