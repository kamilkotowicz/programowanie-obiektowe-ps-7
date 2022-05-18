using System;

namespace MyApp
{
    public class Program
    {
        public static int read_int()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void Main(string[] args)
        {
            Trojkat tr = new Trojkat("niebieski", new Punkt(0, 0), new Punkt(0, 1), new Punkt(1, 1));
            Console.WriteLine("To jest trojkat");
            Console.WriteLine(tr);
            Console.Write("Kolor: ");
            Console.WriteLine(tr.getKolor());
            
            Czworokat cz = new Czworokat("zielony", new Punkt(0, 0), new Punkt(0, 1), new Punkt(1, 1), new Punkt(1, 0));
            Console.WriteLine("To jest czworokat");
            Console.WriteLine(cz);
            Console.Write("Kolor: ");
            Console.WriteLine(cz.getKolor());

            Prostokat pr = new Prostokat("czerwony", new Punkt(0, 0), new Punkt(2, 2));
            Console.WriteLine("To jest prostokat");
            Console.WriteLine(pr);
            Console.Write("Kolor: ");
            Console.WriteLine(pr.getKolor());

            Kwadrat kw = new Kwadrat("zolty", new Punkt(0, 0), 1);
            Console.WriteLine("To jest kwadrat");
            Console.WriteLine(kw);
            Console.Write("Kolor: ");
            Console.WriteLine(kw.getKolor());

        }
    }
    public class Punkt
    {
        private int x, y;

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public Punkt(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
        public Punkt() : this(0, 0) { }
        public Punkt(Punkt p) : this(p.x, p.y) { }
        public void przesun(int dx, int dy)
        {
            x += dx;
            y += dy;
        }
        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
        public static Punkt wczytaj()
        {
            return new Punkt(Program.read_int(), Program.read_int());
        }
    }
    public class Linia
    {
        private Punkt p1, p2;
        public Linia(Punkt pkt1, Punkt pkt2)
        {
            p1 = new Punkt(pkt1);
            p2 = new Punkt(pkt2);
        }
        public Linia()
        {
            p1 = new Punkt();
            p2 = new Punkt();
        }
        public Linia(Linia linia) : this(linia.p1, linia.p2) { }
        public void przesun(int dx, int dy)
        {
            p1.przesun(dx, dy);
            p2.przesun(dx, dy);
        }
        public override string ToString()
        {
            return "(" + p1.ToString() + "," + p2.ToString() + ")";
        }
    }

    public class Figura
    {
        protected string kolor;
        public Figura(string kolor)
        {
            this.kolor = kolor;
        }
        public string getKolor()
        {
            return kolor;
        }
        public void setKolor(string kolor)
        {
            this.kolor = kolor;
        }
    }

    public class Trojkat : Figura
    {
        protected Linia l1, l2, l3;
        public Trojkat(string kolor, Punkt p1, Punkt p2, Punkt p3) : base(kolor)
        {
            l1 = new Linia(p1, p2);
            l2 = new Linia(p2 , p3);
            l3 = new Linia(p3 , p1);
        }

        public override string ToString()
        {
            return "(" + l1.ToString() + "," + l2.ToString() + "," + l3.ToString() + ")";
        }
    }
    public class Czworokat : Figura
    {
        protected Linia l1, l2, l3, l4;
        public Czworokat(string kolor, Punkt p1, Punkt p2, Punkt p3, Punkt p4) : base(kolor)
        {
            l1 = new Linia(p1 , p2);
            l2 = new Linia(p2 , p3);
            l3 = new Linia (p3 , p4);
            l4 = new Linia(p4 , p1);
        }
        public override string ToString()
        {
            return "(" + l1.ToString() + "," + l2.ToString() + "," + l3.ToString() + "," + l4.ToString() + ")";
        }
    }
    public class Prostokat : Czworokat
    {
        public Prostokat(string kolor, Punkt p1, Punkt p2) : base(kolor, p1, new Punkt(p1.getX(),p2.getY()), p2, new Punkt(p2.getX(), p1.getY()))
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Kwadrat : Prostokat
    {
        public Kwadrat(string kolor, Punkt p, int bok) : base(kolor, p, new Punkt(p.getX()+bok, p.getY() + bok))
        {

        }
    }
}
