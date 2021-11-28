namespace Zoo.Api.ViewModels.Giraffe.Update
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NeckLengthInCm { get; set; }

        public int EnclosureId { get; set; }
    }
}