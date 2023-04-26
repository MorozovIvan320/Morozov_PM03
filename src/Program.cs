using System;
using System.IO;
using System.Text;

public class Smartphone
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
