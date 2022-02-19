namespace Flies.Interfaces;

public interface IDocument
{
    string Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime ModifiedAt { get; set; }
}
