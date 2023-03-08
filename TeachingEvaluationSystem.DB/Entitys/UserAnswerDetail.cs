namespace TeachingEvaluationSystem.DB.Entitys
{
    public class UserAnswerDetail : BaseEntity
    {
        public UserAnswerDetail()
        {
            OptionBank = new OptionBank();
            QuestionBank = new QuestionBank();
            UserAnswer = new UserAnswer();
        }
        public int UserAnswerId { get; set; }
        public UserAnswer UserAnswer { get; set; }
        public OptionBank OptionBank { get; set; }
        public QuestionBank QuestionBank { get; set; }
        public int QuestionScores { get; set; }
        public int OptionScores { get; set; }
    }
}
