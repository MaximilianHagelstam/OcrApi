namespace OcrApi.Models
{
    public class Health
    {
        public Health(bool running)
        {
            Running = running;
        }

        public bool Running { get; set; }
    }
}
