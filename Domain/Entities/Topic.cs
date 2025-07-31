namespace Domain.Entities;

public class Topic
{
    public int Id { get; set; }
    public string TopicName { get; set; }
    public string SubTopicName { get; set; }
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}