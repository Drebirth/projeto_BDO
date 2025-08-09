namespace projetoBDO.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new();

    }
}
