namespace Data.Entities;
public class Example
{
    public int Id { set; get; }
    public int WordMeaningId { set; get; }
    public string EnExample { set; get; }
    public string ViMeaning { set; get; }

    public WordMeaning WordMeaning { set; get; }
}