using System.Collections.Generic;
using System.IO;
using System.Linq;
using FullSerializer;
using Scriptable_objects;

namespace CodeBase.Infrustructure.InputService
{
    public class MessageProvider
    {
        
        private readonly Story _messageListe;
        private readonly fsSerializer _serializer;
        private readonly AnswerService _service;

        public MessageProvider()
        {
            _messageListe = new Story();
            _messageListe.PartsofStoryLines = new Dictionary<string, List<Message>>();
            _messageListe.CurrentStoryLine = new List<Message>();
            _serializer = new fsSerializer();
            _service = new AnswerService();
            _service.Answer = new Answer();
        }
        private void DeserializeJsonForAnswer(string answerPath)
        {
            string str = File.ReadAllText(answerPath);
            fsData allAnswers = fsJsonParser.Parse(str);
            Dictionary<string, string[]> dictionary = null;
            _serializer.TryDeserialize(allAnswers, ref _service.Answer.AllAnswers);
            
        }

        public void GenerateLineOfMessages(string pathMessages, string answerPath, List<Autor> autorsList)
        {
            DeserializeJsonForAnswer(answerPath);
            var chain = MessageFromWritesMap(pathMessages);
            var autors = InitializeAutorsDictionary(autorsList);
            WriteMessagesToDictionary(chain, autors);
        }
        private Dictionary<string, MessageFromWrite[]> MessageFromWritesMap(string path)
        {
            Dictionary<string, MessageFromWrite[]> chainsOfMFW = null;
            string jsonMessagesFW = File.ReadAllText(path: path);
            fsData fsData = fsJsonParser.Parse(jsonMessagesFW);
            _serializer.TryDeserialize(fsData, ref chainsOfMFW);
            return chainsOfMFW;
        }

        
        
        private void WriteMessagesToDictionary(Dictionary<string, MessageFromWrite[]> chainOfMessages, Dictionary<string, Autor> autors)
        {
            foreach (var elem in chainOfMessages)
            {
                List<Message> newlist = new List<Message>();
                foreach (var s in elem.Value)
                {
                    foreach (var textMessage in s.Text)
                    {
                        Message temp = new Message();
                        temp.Autor = autors[s.Id];
                        
                        temp.Text = textMessage;
                        newlist.Add(temp);
                    }
                }

                newlist[newlist.Count - 1].isInteracrable = true;

                _messageListe.PartsofStoryLines.Add(elem.Key, newlist);
            }
        }

        private Dictionary<string, Autor> InitializeAutorsDictionary(List<Autor> _autorsList)
        {
            Dictionary<string, Autor> autors = new Dictionary<string, Autor>();
            foreach (var autor in _autorsList)
            {
                autors.Add(autor.Id, autor);
            }

            return autors;
        }
        
        public void WriteStartMessagesToCurrentLine()
        {
            foreach (var f in _messageListe.PartsofStoryLines["0"])
            {
                _messageListe.CurrentStoryLine.Add(f);
            }
        }
        public void SwitchPartsOfStory(string key)
        {
            
            foreach (var messageList in _messageListe.PartsofStoryLines[key])
            {
                _messageListe.CurrentStoryLine.Add(messageList);
            }

        }

        public string GetVariantOfAnswer( int j) 
            => _service.Answer.AllAnswers[_service.Answer.AnswerHistory].GetValue(j).ToString();

        

        public Message GetCurrentMessage()
        {
            return _messageListe.CurrentStoryLine.First();
        }

        public void DeleteFirstMessage()
            => _messageListe.CurrentStoryLine.Remove(_messageListe.CurrentStoryLine.First());

        public void SetAnswer(int i) 
            => _service.SetAnswer(i);

        public string GetAnswer()
            => _service.GetAnswer;
    }
}