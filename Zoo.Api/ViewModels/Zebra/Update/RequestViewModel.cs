namespace Zoo.Api.ViewModels.Zebra.Update
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int? EnclosureId { get; set; }
    }
}