using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace Main {
					
	public class Program {
		public static void Main() {
		    // Lista de pessoas
			var list = new List<Person>();
			
			// Adicionando dados a lista
			list.Add(new Person() { Name = "Joao", Age = 10 });
			list.Add(new Person() { Name = "Maria", Age = 20 });
			list.Add(new Person() { Name = "Renata", Age = 10 });
			list.Add(new Person() { Name = "Jorge", Age = 30 });
			list.Add(new Person() { Name = "Julia", Age = 5 });
			
			// Filtra pessoas maiores de 18 anos (LINQ)
			var filteredList = list.Where(x => x.Age >= 18).ToList();
			
			// Imprime resultado na tela
			foreach(var person in filteredList) {
				WriteLine("Nome: {0} - Idade: {1}", person.Name, person.Age);
			}
			
			WriteLine();
			
			// Imprime a lista de nomes em ordem alfabética
			var orderedList = list.OrderBy(x => x.Name).ToList();
			foreach(var person in orderedList) {
				WriteLine("Nome: {0}", person.Name);
			}
		}
	}

    // Pessoa
	public class Person {
		public string Name;
		public int Age;
	}
}