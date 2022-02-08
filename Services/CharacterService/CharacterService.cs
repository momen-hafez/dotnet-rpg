using System.Collections.Generic;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService{
    public class CharacterService : ICharacterService{
         private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {ID = 1 , Name = "Momen"}
        };
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter){
            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            serviceResponse.Data = characters;
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Character>>> GetAllCharacters(){
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }
        public async Task<ServiceResponse<Character>> GetCharacterById(int id){
           var serviceResponse = new ServiceResponse<Character>();
           serviceResponse.Data = characters.FirstOrDefault(c => c.ID == id);
           return  serviceResponse;/* 200 status*/
        }
        
    }
}