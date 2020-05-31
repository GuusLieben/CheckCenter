namespace Domain
{
    public interface IGenericEvent
    {
        int Id { get; set; }
        void SetTitle(string title);
    }
}
