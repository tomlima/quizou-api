namespace Quizou.Domain.DTO;
public class EditQuestionDto
{
    public required int QuestionId { get; set; }
    public required string NewQuestion { get; set; }
}