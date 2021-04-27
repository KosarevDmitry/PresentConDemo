using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PresentConDemo.tests
{
    public class Tests
    {

        ServiceProvider serviceProvider;
        IDataSet dataset;
     
        [SetUp]
        public void Setup()
        {
             dataset = Substitute.For<IDataSet>();
            var country = Substitute.For<ICountry>();
            var log = Substitute.For<ILog>();
            dataset.Countries = new List<ICountry>() {
                new Country (){Id= 1,TaxRate=15, EUCountry=false, Name= "Argentina"  },
                new Country (){Id= 2,TaxRate=15, EUCountry=true, Name= "Austria"  },
                new Country (){Id= 3,TaxRate=15, EUCountry=false, Name= "Australia"  },
                new Country (){Id= 4,TaxRate=15, EUCountry=true, Name= "Netherlands"  },
                new Country (){Id= 5,TaxRate=21, EUCountry=true, Name= "Lithuania"  },
                new Country (){Id= 6,TaxRate=15, EUCountry=true, Name= "Spain"  }

            };
            dataset.Suppliers = new List<ISupplier>() {

            new Supplier(){Id=1, VATPayer =true, CountryId =1},
            new Supplier(){Id=2, VATPayer =true, CountryId =2},
            new Supplier(){Id=3, VATPayer =true, CountryId =3}
            };

            dataset.Customers = new List<ICustomer>()
            {
                 new Customer(){Id = 1, Name = "GmbH0", VATPayer = false, CountryId = 1},
                 new Customer(){Id = 2, Name = "GmbH1", VATPayer = true, CountryId = 1},
                 new Customer(){Id = 3, Name = "GmbH2", VATPayer = true, CountryId = 1},
                 new Customer(){Id = 4, Name = "GmbH3", VATPayer = false, CountryId = 1},
                 new Customer(){Id = 5, Name = "GmbH4", VATPayer = false, CountryId = 1},


            };
            dataset.Products = new List<IProduct>()  {
                                new Product () { Id =1, UnitPrice=2, Quantity=2, SupplierId=1 },
                                new Product (){ Id =2, UnitPrice=5, Quantity=2, SupplierId=2 },
                                new Product (){ Id =3, UnitPrice=5, Quantity=2, SupplierId=3 },
                                new Product (){ Id =4, UnitPrice=5, Quantity=2, SupplierId=1 },
                                new Product (){ Id =5, UnitPrice=5, Quantity=2, SupplierId=2 },
                                new Product (){ Id =6, UnitPrice=5, Quantity=2, SupplierId=3 },
                            };

            dataset.Orders =
                new List<IOrder>()
                {
                    new Order(1)
                        {
                            Products =   dataset.Products.Take(2).ToList()
                      },
                    new Order(2)
                        {
                             Products =   dataset.Products.Take(3).ToList()
                      },
                    new Order(3)
                        {
                              Products =   dataset.Products.Skip(2).Take(2).ToList()
                        }

               };

             serviceProvider = Substitute.For<ServiceProvider>(new object[] { false, country, log, dataset });


        }

        [Test]
        public void InvoiceTest()
        {
         var extprice= serviceProvider.CreateInvoice(2).ExtendedPrice);
           Assert.AreEqual(extprice, 24);
        }


        [Test]
        public void ProductTest()
        {
               decimal result = dataset.Products.Sum(x => x.UnitPrice);
               Assert.Equals(27, 27);
        }
    }
}