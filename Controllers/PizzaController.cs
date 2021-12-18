using pizza.Models;
using pizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace pizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }


    //Get all pizzas
    [HttpGet]
    public ActionResult<List<Pizza>> getAll()
    {
        return PizzaService.GetAll();

    }

    //Get one pizza
    [HttpGet("{id}")]
    public ActionResult<Pizza> get(int id)
    {     var pizza = PizzaService.Get(id);

        if(pizza==null)
        return NotFound("id incorrecte");

       
        return pizza;
    }
     
     //CREATE PIZZA
     [HttpPost]
     public ActionResult<string> createPizza(Pizza pizza)
     {
        PizzaService.Add(pizza);
        if(pizza.Name==null || pizza.Name.Length==0)
        return BadRequest($"The name is incorrect name : {pizza.Name}");
         
        return pizza.Name;
     }


     //UPDATE

     [HttpPut]
     public ActionResult<Pizza> updatePizza(Pizza pizza)
     {
         if(PizzaService.Update(pizza))
         return pizza;
         return NotFound("Id incorrect");
     }

     [HttpDelete("{id}")]

     public ActionResult deletePizza(int id)
     {
       if(PizzaService.Delete(id))
       return NoContent();
       return NotFound();
     }




//     // GET all action
//    [HttpGet]
//   public ActionResult<List<Pizza>> GetAll() =>
//     PizzaService.GetAll();
//     // GET by Id action
// [HttpGet("{id}")]
// public ActionResult<Pizza> Get(int id)
// {
//     var pizza = PizzaService.Get(id);

//     if(pizza == null)
//         return NotFound();

//     return pizza;
// }
//     // POST action

// [HttpPost]
// public IActionResult Create(Pizza pizza)
// {            
//     PizzaService.Add(pizza);
//     return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
// }

//     // PUT action
// [HttpPut("{id}")]
// public IActionResult Update(int id, Pizza pizza)
// {
//     if (id != pizza.Id)
//         return BadRequest();

//     var existingPizza = PizzaService.Get(id);
//     if(existingPizza is null)
//         return NotFound();

//     PizzaService.Update(pizza);           

//     return NoContent();
// }
//     // DELETE action
//     [HttpDelete("{id}")]
// public IActionResult Delete(int id)
// {
//     var pizza = PizzaService.Get(id);

//     if (pizza is null)
//         return NotFound();

//     PizzaService.Delete(id);

//     return NoContent();
// }
}