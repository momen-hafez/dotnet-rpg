namespace dotnet_rpg.Models{
    /* T : the actual type of the data to return same like generic datatype*/
    /* this model is more useful in a big projects */ 
    public class ServiceResponse <T>{
         public T Data {get; set;}   
         public bool Success {get; set;} = true;
         public string Messaqge {get; set;} = null;
    }
}