using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

class Square_equation
{
    private float[] b = new float[3];

    public Square_equation() { }
    public Square_equation(float b1) { this.b[0]=b1; }
    public Square_equation(float b1,float b2) { this.b[0] = b1; this.b[1]=b2; }
    public Square_equation(float b1, float b2,float b3)
    {
        this.b[0]=b1; this.b[1]=b2; this.b[2]=b3;
    }
    public Square_equation(float[] b) { this.b = b;}
    public void Setb(int n,float b) { this.b[n]=b; }
    public void Setb(float[] b) { this.b = b;}
    public float Getb(int n) {  return b[n]; }
    public string PrintB()
    {
        string output = "";
        for (int i = 0; i < b.Length; i++)
        {
           output+= b[i] + ",";
        }
        return output;
    }
    public bool X1val(float x)
    {
        if (b[0]*(x * x) + b[1] * x + b[2] == 0) { return true; }
        else { return false; }
    }
    public double? GetSolution(int n)
    {
        double D = b[1] * b[1] - 4 * b[0] * b[2];
        if (D < 0) return null;
        else if(n == 1) return (-1) * b[1] + Math.Sqrt(D) / 2 * b[0];
        else if(n == 2 && D!=0) return (-1) * b[1] + (-1)*Math.Sqrt(D) / 2 * b[0];
        else return null;
    }
}
class Cubic_equation : Square_equation
{
    private float[] a = new float[4];
    public Cubic_equation(float[] a, float[] b) { this.a = a;Setb(b); }
    public Cubic_equation(float a1, float a2, float a3, float a4, float b1, float b2, float b3) { this.a[0] = a1; this.a[1] = a2; this.a[2] = a3; this.a[3] = a4; Setb(0, b1); Setb(1, b2); Setb(2, b3); }
    public void Seta(int n, float a) { this.a[n] = a; }
    public float Geta(int n) { return this.a[n]; }

    public void PrintA()
    {
        for(int i=0; i<a.Length; i++)
        {
            Console.Write(a[i]+",");
        }
    }
    public bool X2val(float x)
    {
        if (a[0] * (x * x * x) + a[1] * (x * x) + a[2]*x+ a[3]==0) return true;
        else return false;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter a3,a2,a1,a0,b2,b1,b0:");
            float a3 = float.Parse(Console.ReadLine());
            float a2 = float.Parse(Console.ReadLine());
            float a1 = float.Parse(Console.ReadLine());
            float a0 = float.Parse(Console.ReadLine());
            float b2 = float.Parse(Console.ReadLine());
            float b1 = float.Parse(Console.ReadLine());
            float b0 = float.Parse(Console.ReadLine());
            Cubic_equation Cub_Equ = new(a3, a2, a1, a0, b2, b1, b0);
            Console.WriteLine("Solutions for a square equation with b2,b1,b0 =" + Cub_Equ.PrintB() + " are :" + Cub_Equ.GetSolution(1) + " and " + Cub_Equ.GetSolution(2));
            Console.WriteLine("Write x for Cubic equation: ");
            float x = float.Parse(Console.ReadLine());
            if (Cub_Equ.X2val(x))
            {
                Console.WriteLine("the x is correct!");
            }
            else Console.WriteLine("the x is incorrect");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}
