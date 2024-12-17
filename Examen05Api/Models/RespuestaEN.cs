namespace Examen05Api.Models
{
    public class RespuestaEN<T>
    {
        public bool status { get; set; }
        public string? msg { get; set; }
        public T? value { get; set; }
    }
}
