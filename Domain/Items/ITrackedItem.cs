namespace Domain
{
    public interface ITrackedItem
    {
        int Id { get; set; }
        int? StorageID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        
    }
}