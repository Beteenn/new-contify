namespace Rentfy.Application.ViewModels
{
    public abstract class APersonViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
    }
}
