namespace Data.Entities;
public class WordType
{
    public int Id { set; get; }
    public string Vi { set; get; }
    public string En { set; get; }
    public ICollection<WordTypeLink> WordTypeLinks { set; get; }
}