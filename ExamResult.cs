using System;

namespace Lesson7
{
  enum Grades
  {
    Jeles=4,
    Jó=3,
    Közepes=2,
    Elégséges=1,
    Elégtelen=0
  }

  class ExamResult
  {
    private string neptunCode;
    private int point;
    private Random rnd = new Random();

    public ExamResult(string neptunCode, int point)
    {
      this.neptunCode = neptunCode;
      this.point = point;
    }

    public ExamResult()
    {
      neptunCode = NeptunCodeGenerator();
      point = rnd.Next(101);
    }

    private string NeptunCodeGenerator()
    {
      int[] tmp = new int[6];
      for (int i = 0; i < tmp.Length; i++)
      {
        int numOrChar;
        if (i == 0)
          numOrChar = 1;
        else
          numOrChar = rnd.Next(2);   

        if (numOrChar == 0)
          tmp[i] = rnd.Next(10);
        else
          tmp[i] = rnd.Next(65, 91);
      }
      string code = "";
      for (int i = 0; i < tmp.Length; i++)
      {
        if (tmp[i] > 64 && tmp[i] < 91)
          code += (char)tmp[i];
        else
          code += tmp[i];
      }
      return code;
    }

    public string NeptunCode
    {
      get => neptunCode;
      set { if (value.Length == 6) neptunCode = value; }
    }

    public int Point
    {
      get => point;
      set { if (value >= 0 && value <= 100) point = value; }
    }

    public bool Passed
    {
      get 
      {
        if(point >= 50) 
          return true;
        else 
          return false;
      }
    }

    public Grades Grade(int[] limits)
    {
      if (point < limits[0]) 
        return Grades.Elégtelen;
      else if (point < limits[1])
        return Grades.Elégséges;
      else if (point < limits[2])
        return Grades.Közepes;
      else if (point < limits[3])
        return Grades.Jó;
      else
        return Grades.Jeles;
    }
  }
}
