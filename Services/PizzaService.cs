using System.Collections.Generic;
using DotNetCoreWebApi.Models;
using System.Linq;

namespace DotNetCoreWebApi.Services{
    public static class PizzaService{
        static List<Pizza> Pizzas {get;}
        static int nextId = 3;

        static PizzaService(){
            Pizzas = new List<Pizza>{
                new Pizza {Id = 1, Name = "Margarita", IsGlutenFree = false},
                new Pizza {Id = 2, Name = "Barbeque", IsGlutenFree = true}
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(Pizza pizza){
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(Pizza pizza){
            pizza = Get(pizza.Id);
            if(pizza is null) return;
            Pizzas.Remove(pizza);
        }
        

        public static void Update(Pizza pizza){
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if(index == -1  ) return;
            Pizzas[index] = pizza;
        }
    }
}