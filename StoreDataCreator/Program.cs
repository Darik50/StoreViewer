﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StoreDataCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> prod = new List<Product>();

            prod.Add(new Product(1, 1, "Pencil", new DateTime(2020, 4, 28), 100, 5, 9.99));
            prod.Add(new Product(1, 2, "Milk", new DateTime(2019, 4, 14), 5, 10, 5));
            prod.Add(new Product(2, 3, "Gold bar", new DateTime(1578, 6, 2), 99999, 10, 54915.73));
            prod.Add(new Product(2, 4, "Watch", new DateTime(2012, 8, 17), 3, 50, 385.35));
            prod.Add(new Product(2, 5, "Tape", new DateTime(2020, 4, 30), 365, 50, 53.67));
            prod.Add(new Product(3, 6, "Croissant", new DateTime(2020, 3, 29), 30, 50, 23.67));
            prod.Add(new Product(3, 7, "Salbutamol", new DateTime(2019, 12, 28), 300, 50, 16.84));
            prod.Add(new Product(4, 8, "Socks", new DateTime(2016, 2, 28), 720, 50, 945.31));
            prod.Add(new Product(5, 9, "Box", new DateTime(2020, 1, 1), 365, 50, 5.54));
            prod.Add(new Product(5, 10, "Ring", new DateTime(2019, 4, 1), 365, 33, 645.00));

            XDocument doc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Products",
                    from p
                    in prod
                    select new XElement("Product",
                        new XAttribute("ID", p.ID),
                        new XElement("StoreID", p.storeID),
                        new XElement("Name", p.name),
                        new XElement("Date", p.arrivalDate.ToString("yyyy-MM-dd")),
                        new XElement("ShelfLife", p.shelfLife),
                        new XElement("Quantity", p.quantity),
                        new XElement("Price", p.price)
                    )
                )
            );
            doc.Save(@"C:\Users\Znatok\Desktop\container.xml");


            //var prod2 = from p in XDocument.Load(@"C:\Users\Znatok\Desktop\container.xml").Descendants("Product")
            //            select p;

            //foreach (var pel in prod2){
            //    Console.WriteLine(pel.Attribute("ID"));
            //    Console.WriteLine(pel.Element("Name"));

            //}

            //Console.ReadKey();

        }
    }
}
