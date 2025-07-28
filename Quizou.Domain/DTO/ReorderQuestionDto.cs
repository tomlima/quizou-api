using System.ComponentModel.DataAnnotations;

namespace Quizou.Domain.DTO
{
    public  class ReorderQuestionDto
    {
        [Required]
        public required int Id { get; set; }
        [Required]
        public required int Order { get; set; }
    }
}
