using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactoryProduction.Models;

namespace FactoryProduction.Models
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationContext db)
        {
            db.Database.EnsureCreated();

            if (db.Factories.Any() && db.Products.Any() && db.ProductTypes.Any() && db.PlanOfImplement.Any() && db.ReleacePlan.Any())
            {
                return;
            }

            Random randObj = new Random(1);

            //Заполнение таблицы фабрик.
            int Factories_number = 100;
            string factName;
            string name;
            string[] factName_arr = { "Huawei", "Samsung", "Nokia", "Apple", "Sony Ericsson" };
            string[] name_arr = { "Антимоник", "Ковалев", "Назаренко", "Сидоркин", "Прядихин" };

            int count_factName_arr_voc = factName_arr.GetLength(0);
            int count_name_arr_voc = name_arr.GetLength(0);


            for (int ID = 1; ID <= Factories_number; ID++)
            {
                factName = factName_arr[randObj.Next(count_factName_arr_voc)];
                name = name_arr[randObj.Next(count_name_arr_voc)];
                db.Factories.Add(new Factories {FactName = factName, Head = name});
            }
            db.SaveChanges();


            //Заполнение таблицы план реализации.
            int PlanOfImplement_number = 100;
            int impleplan;
            int price;
            for (int ID = 1; ID <= PlanOfImplement_number; ID++)
            {
                impleplan = randObj.Next(2000, 10000);
                price = randObj.Next(20000, 150000);

                db.PlanOfImplement.Add(new PlanOfImplement {  ImplePlan = impleplan, Price = price});
            }
            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

            //Заполнение таблицы план выпуска.
            int ReleacePlan_number = 100;
            int output;
            int pricereleace;
            for (int ID = 1; ID <= ReleacePlan_number; ID++)
            {
                output = randObj.Next(2000, 10000);
                pricereleace = randObj.Next(20000, 150000);

                db.ReleacePlan.Add(new ReleacePlan { OutputPlan = output, Price = pricereleace });
            }
            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

            //Заполнение таблицы типы продукции.
            int Product_types_number = 100;
            string producttype;
            string[] producttype_arr = { "Телефон", "Планшет", "Плеер", "Телевизор", "Приставка" };
            int count_producttype_arr_voc = producttype_arr.GetLength(0);
            for (int ID = 1; ID <= Product_types_number; ID++)
            {
                producttype = producttype_arr[randObj.Next(count_producttype_arr_voc)];
                db.ProductTypes.Add(new ProductTypes {ProductTypeName = producttype});
            }
            db.SaveChanges();


            //Заполнение таблицы продуктов.
            int Products_number = 1000;
            int factid;
            string productname;
            string unitofproduct;
            string[] productname_arr = { "G800", "E4B8", "P8 lite", "A30", "4310" };
            string[] unitofproduct_arr = { "1000 шт", "1700 шт", "956 шт", "312 шт", "540 шт" };
            int count_productname_arr_voc = productname_arr.GetLength(0);
            int count_unitofproduct_arr_voc = unitofproduct_arr.GetLength(0);


            for (int ID = 1; ID <= Products_number; ID++)
            {
                factid = randObj.Next(1, 50);
                productname = productname_arr[randObj.Next(count_productname_arr_voc)];
                unitofproduct = unitofproduct_arr[randObj.Next(count_unitofproduct_arr_voc)];
                db.Products.Add(new Products { FactoryId = factid, ProductName = productname, UnitOfProduct = unitofproduct});
            }
            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();
            
          
        }

    }
}

