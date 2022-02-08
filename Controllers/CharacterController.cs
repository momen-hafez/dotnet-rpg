using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
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
        /* constructor*/

        private readonly ICharacterService _characterService; /* new private field we inject our service to the controller*/
                                                              /* here we use dependency injection */
                                                              /* 
                                                              * Dependency injection: you are able to use the same
                                                              * services in several controllers and if you want to
                                                              * change the actual implementation of a service, you just
                                                              * change one service class 
                                                              */         
        public CharacterController(ICharacterService characterService){
            _characterService = characterService;
        }
        // private static List<Character> characters = new List<Character> {
        //     new Character(),
        //     new Character {ID = 1 , Name = "Momen"}
        // };
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
        public async Task<ActionResult<ServiceResponse<List<Character>>>>Get(){
            return Ok(await _characterService.GetAllCharacters()); /* 200 status*/
        }
        // [HttpGet]

        [HttpGet("{id}")] /* this is used in case we want to return the character with a specific ID*/
        public async Task<ActionResult<ServiceResponse<List<Character>>>>GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id)); /* 200 status*/
        }

        [HttpPost] // send data
        public async Task<ActionResult<ServiceResponse<List<Character >>>> AddCharacter(Character newCharacter){ 
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

    }
}