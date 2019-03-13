using System;

namespace DrawingDayTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] t = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                Console.Clear();
                Console.WriteLine(CalculateStudentId(t));
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static int CalculateStudentId(int[] t)
        {
            int studentsDoneCounter = 0;
            int x = 1;
            int maxStudentsDone = 0;
            int minutesCounter = 0;

            //This for-loop will count how many students are finished with their drawings for every "x"
            for (int i = 0; i < t.Length; i++)
            {
                studentsDoneCounter = 0;

                //Set minutesCounter to the right value when testing x and x
                if (i > 0)
                {
                    minutesCounter = t.Length - i;
                }

                for (int j = 0; j < t.Length; j++)
                {
                    //Check if is possible that starting at "x" get a greater value than the current maxStudentsDone, if not breaks the loop
                    if (t.Length - j + studentsDoneCounter <= maxStudentsDone)
                    {
                        break;
                    }

                    //Set the counter to 0 once we get to the "x" we are checking
                    if (j == i)
                    {
                        minutesCounter = 0;
                    }

                    if (t[j] < t.Length && t[j] == 0 || t[j] - minutesCounter <= 0)
                    {
                        studentsDoneCounter++;
                    }

                    minutesCounter++;
                }

                if (studentsDoneCounter > maxStudentsDone)
                {
                    maxStudentsDone = studentsDoneCounter;
                    x = i + 1;
                }
            }
            return x;
        }
    }
}
