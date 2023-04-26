using System;
using System.IO;
using System.Text;

public class Smartphone : IComparable
{
    public string model;
    public int price;
    public int diagonal;

    public class Program
    {
        public static void Main(string[] args)
        {
            int cntPhones = 0;
            Console.WriteLine("Количество устройств:");
            cntPhones = Convert.ToInt32(Console.ReadLine());
            if (cntPhones < 1)
            {
                Environment.Exit(0);
            }
            else
            {
                GadgetFactory gadgetFactory = new GadgetFactory(cntPhones);
                gadgetFactory.Fill();
                gadgetFactory.Sort();
                gadgetFactory.PrintToFile();
            }
        }
    }

    public Smartphone(string model, int price, int diagonal)
    {
        this.model = model;
        this.price = price;
        this.diagonal = diagonal;
    }

    public string ToString()
    {
        return string.Format("Модель: {0}  Цена: {1} Размер диагонали: {2}", model, price, diagonal);
    }

    public int CompareTo(object obj)
    {
        Smartphone compared = obj as Smartphone;
        if (compared != null)
        {
            int result = model.CompareTo(compared.model);
            if (result != 0)
            {
                return result;
            }
            return diagonal.CompareTo(compared.diagonal);
        }
        else
        {
            throw new Exception("Невозможно сравнить два объекта");
        }
    }

}

public class GadgetFactory
{
    int cntPhones;
    public Smartphone[] Phones;

    public GadgetFactory(int cntPhones)
    {
        this.cntPhones = cntPhones;
        Phones = new Smartphone[cntPhones];
    }

    public void Fill()
    {
        string model;
        int price;
        int diagonal;
        for (int i = 0; i < this.cntPhones; i++)
        {
            Console.WriteLine("[Смартфон № " + (i + 1) + "]");
            Console.WriteLine("Модель:");
            model = Console.ReadLine();
            Console.WriteLine("Цена:");
            price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Размер диагонали экрана:");
            diagonal = Convert.ToInt32(Console.ReadLine());
            this.Phones[i] = new Smartphone(model, price, diagonal);
        }
    }

    public void Sort()
    {
        Array.Sort(this.Phones);
    }

    public void PrintToFile()
    {
        using (StreamWriter file = new StreamWriter("final.txt", false, Encoding.UTF8))
        {
            foreach (Smartphone compared in this.Phones)
            {
                file.WriteLine(compared.ToString());
            }
        }
    }
}
