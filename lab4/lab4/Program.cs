class Square_Equation
{
    protected float b2;
    protected float b1;
    protected float b0;

    public Square_Equation() { }
    public Square_Equation(float b2, float b1, float b0)
    {
        this.b2 = b2; 
        this.b1 = b1; 
        this.b0 = b0;
    }
    public void Setb0(float b) { this.b0 = b; }
    public void Setb1(float b) { this.b1 = b; }
    public void Setb2(float b) { this.b2 = b; }
    public float Getb0() { return b0; }
    public float Getb1() { return b1; }
    public float Getb2() { return b2; }
    public string PrintB()
    {
        return b2 + "," + b1 + "," + b0;
    }
    public bool X1val_Valid(float x)
    {
        if (b2 * (x * x) + b1 * x + b0 == 0) { return true; }
        else { return false; }
    }
    public double? GetSolution(int n)
    {
        double D = b1 * b1 - 4 * b2 * b0;
        if (D < 0) return null;
        else if (n == 1) return (-1) * b1 + Math.Sqrt(D) / 2 * b2;
        else if (n == 2 && D != 0) return (-1) * b1 + (-1) * Math.Sqrt(D) / 2 * b2;
        else return null;
    }
}
class Cubic_Equation : Square_Equation
{
    private float a0;

    public Cubic_Equation(float b2, float b1, float b0, float a0) 
    { 
        this.b2 = b2;
        this.b1 = b1;
        this.b0 = b0;
        this.a0 = a0; 
    }

    public float Geta0() {return a0;}
    public void Seta0(float a0) { this.a0 = a0; }

    public void PrintA()
    {
        Console.WriteLine(b2 + "," + b1 + "," + b0 + "," + a0 + ",");
    }
    public bool X2val_Valid(float x)
    {
        if (b2 * (x * x * x) + b1 * (x * x) + b0 * x + a0 == 0) return true;
        else return false;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter a3=b2,a2=b1,a1=b0,a0:");
            float a3 = float.Parse(Console.ReadLine());
            float a2 = float.Parse(Console.ReadLine());
            float a1 = float.Parse(Console.ReadLine());
            float a0 = float.Parse(Console.ReadLine());
            Cubic_Equation Cub_Equ = new(a3, a2, a1, a0);
            Console.WriteLine("Solutions for a square equation with b2,b1,b0 =" + Cub_Equ.PrintB() + " are :" + Cub_Equ.GetSolution(1) + " and " + Cub_Equ.GetSolution(2));
            Console.WriteLine("Write x for Cubic equation " + Cub_Equ.Getb2() + "*x^3+" + Cub_Equ.Getb1() + "*x^2+" + Cub_Equ.Getb0() + "*x+" + Cub_Equ.Geta0() + " : ");
            float x = float.Parse(Console.ReadLine());
            if (Cub_Equ.X2val_Valid(x))
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
