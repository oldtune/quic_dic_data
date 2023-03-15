namespace QuackQuack.Models;
public class ProjectResponse
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string Description { set; get; }
    public string? Url { set; get; }
    public DateTime From { set; get; }
    public DateTime? To { set; get; }
}