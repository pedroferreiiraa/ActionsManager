using _5W2H.Core;

namespace _5W2H.Application.Models;

public class CreateProjectInputModel
{
    public string Title { get; private set; }
    public string What { get; private set; }
    public string Why { get; private set; }
    public DateTime When { get; private set; }
    public string Where { get; private set; }
    public string Who { get; private set; }
    public string How { get; private set; }
    public decimal HowMuch { get; private set; }
    
    public Project ToEntity()
        => new(Title, What, Why, When, Where, Who, How, HowMuch);
}