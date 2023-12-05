using Scriptable_objects;

namespace CodeBase.Infrustructure
{
    public class AnswerService
    {
        public Answer Answer;

        public void SetAnswer(int indexOfAnswer)
        {
            string Answer = (indexOfAnswer).ToString();
            this.Answer.CurrentAnswer = Answer;
            SetAnswerHistory(this.Answer.CurrentAnswer);
        }

        public string GetAnswer =>
            Answer.AnswerHistory;
        public string GetAnswerHistory => 
            Answer.AnswerHistory;
        private void SetAnswerHistory(string answer)
        {
            Answer.AnswerHistory += answer;
        }

    }


}