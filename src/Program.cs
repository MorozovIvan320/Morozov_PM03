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
            int result = diagonal.CompareTo(compared.diagonal);
            if (result != 0)
            {
                return result;
            }
            return model.CompareTo(compared.model);
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
            Console.Write("[Смартфон № " + (i + 1) + "]");
            Console.Write("Модель:");
            model = Console.ReadLine();
            Console.Write("Цена:");
            price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Размер диагонали экрана:");
            diagonal = Convert.ToInt32(Console.ReadLine());
            this.Phones[i + 1] = new Smartphone(model, price, diagonal);
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
