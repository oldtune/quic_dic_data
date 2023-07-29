using Data.Repositories;

namespace Data.Entities;
public class WordRecord : IDatabaseObject
{
    public string Word { set; get; }
    public string EnUkPronounce { set; get; }
    public string EnUsPronounce { set; get; }
    public string ViPronounce { set; get; }
    public ICollection<WordTypeLink> WordTypeLinks { set; get; }

    public string TableName => "Word";
}