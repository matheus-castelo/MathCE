namespace Domain.Entities;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int TopicId { get; set; }
    public Topic Topic { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public Answer CorrectAnswer { get; set; }
}