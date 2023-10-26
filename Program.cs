using System;

namespace Lesson7
{
  class Program
  {
    static ExamResult[] examResults = new ExamResult[int.Parse(Console.ReadLine())];
    static void Main()
    {
      ReadIn();
      WritePassed();
      WriteAveragePoint();
      WriteHighestPoint();
    }

    static void ReadIn()
    {
      for (int i = 0; i < examResults.Length; i++)
      {
        string line = Console.ReadLine();
        if (line == "")
        {
          ExamResult er = new ExamResult();
          examResults[i] = er;
        }
        else 
        {
          string neptun = Console.ReadLine();
          string point = Console.ReadLine();
          ExamResult er = new ExamResult(neptun, int.Parse(point));
          examResults[i] = er;
        }
      }
    }

    static void WritePassed()
    {
      Console.WriteLine("Passed:");
      for (int i = 0; i < examResults.Length; i++)
      {
        if (examResults[i].Passed)
          Console.WriteLine("   " + examResults[i].NeptunCode);
      }
    }

    static void WriteAveragePoint()
    {
      Console.WriteLine("Average point:");
      int sum = 0;
      for (int i = 0; i < examResults.Length; i++)
      {
        sum += examResults[i].Point;
      }
      Console.WriteLine(sum / examResults.Length);
    }

    static void WriteHighestPoint()
    {
      Console.WriteLine("Best:");
      int highest = 0;
      for (int i = 1; i < examResults.Length; i++)
      {
        if (examResults[i].Point > examResults[highest].Point)
          highest = i;
      }
      Console.WriteLine("   " + examResults[highest].NeptunCode);
    }
  }
}
