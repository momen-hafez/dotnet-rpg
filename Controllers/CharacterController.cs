using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
namespace dotnet_rpg.Controllers
{
    /*
    ControllerBase: abstract class for an MVC controller without
    view support
    */
    [ApiController]     /*  type and all derived types used to HTTP API response*/
                        /*   enables several API specific features -> attribute routing  and -> automatic HTTP 400 */

    [Route("[controller]")] /* it means that this controller can be accessed by its name, in our case Character*/
    public class CharacterController : ControllerBase{
        //private static Character knight = new Character(); /* instance from the character class in the Models*/
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {ID = 1 , Name = "Momen"}
        };
        /*
        enables us to send specific HTTP status code back to the client 
        together with the actual data that was requested 
        */
        [HttpGet]     /* this is just for swegger to decide that is a GET reponse*/
        /* 
        using IActionResult doesn't show the Schemas so we need to change it 
        to ActionResult<model class>
        */
        // public IActionResult Get(){
        //     /* 
        //      As the name of the method starts with Get, the API assumes 
        //      that the used HTTP method is also get 
        //      */
        //     return Ok(knight); /* 200 status*/

        // }


        /* 
        As there's two get methods the controller doesn't know which one
        to return so we need to add the route
        */
        [Route("GetAll")]

        /* or [HttpGet("GetAll")]*/
        public ActionResult<List<Character>>Get(){
            return Ok(characters); /* 200 status*/
        }
        // [HttpGet]

        [HttpGet("{id}")] /* this is used in case we want to return the character with a specific ID*/
        public ActionResult<List<Character>>GetSingle(int id){
            return Ok(characters.FirstOrDefault(c => c.ID == id)); /* 200 status*/
        }

        [HttpPost] // send data
        public ActionResult<List<Character >> AddCharacter(Character newCharacter){
            characters.Add(newCharacter);
            return Ok(characters);
        }

    }
}