using System.Collections.Generic;
using UnityEngine;

namespace Scriptable_objects
{
    public class Answer 
    {
        public string CurrentAnswer;
        public string AnswerHistory="0";
        public Dictionary<string, string[]> AllAnswers;
    }
}