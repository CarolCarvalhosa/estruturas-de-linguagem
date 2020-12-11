using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace Main {
					
	public class Program {
		public static void Main() {
            // Instanciando produtos
            Product p1 = new Product { Name = "Eisenbahn", Price = 3.79 };
            Product p2 = new Product { Name = "Heineken", Price = 3.99 };
            Product p3 = new Product { Name = "Estrella Galicia", Price = 6.80 };
            Product p4 = new Product { Name = "Blue Moon", Price = 13.99 };
            Product p5 = new Product { Name = "Quilmes", Price = 33.90 };

            // Instanciando clientes
            Customer c1 = new Customer { Name = "Ana", Product = p1 };
            Customer c2 = new Customer { Name = "Ana", Product = p2 };
            Customer c3 = new Customer { Name = "Joana", Product = p3 };
            Customer c4 = new Customer { Name = "Joana", Product = p4 };
            Customer c5 = new Customer { Name = "Juliana", Product = p2 };
            Customer c6 = new Customer { Name = "Juliana", Product = p5 };

            // Criando as listas de clientes e produtos
            List<Customer> customers = new List<Customer> { c1, c2, c3, c4, c5, c6 };
            List<Product> products = new List<Product> { p1, p2, p3, p4, p5 };

            // Agrupa os clientes e soma o valor gasto por eles na compra
            var customersMoneySpent =
                (
                    from product in products
                    join customer in customers on product equals customer.Product
                    group customer by customer.Name into customerGroup
                    select new
                    {
                        // Nome do cliente
                        CustomerName = customerGroup.Key,
                        // Soma do quantia gasta na compra dos produtos
                        MoneySpent = customerGroup.Sum(x => x.Product.Price),
                    }
                ).ToList();

            // Imprimindo os nomes dos clientes e valor gasto na compra
            foreach (var cms in customersMoneySpent)
            {
                WriteLine("Cliente: {0}; Compra: {1}", cms.CustomerName, cms.MoneySpent);
            }
		}
    }
		
    class Customer {
        public string Name;
        public Product Product;
    }
    
    class Product {
        public string Name;
        public double Price;
    }
}