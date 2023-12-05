using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DG.Tweening;
using FullSerializer;
using Scriptable_objects;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.Infrustructure.InputService
{
    public class UIMessageService : MonoBehaviour
    {

        private string ANSWERS_PATH;
        private string ALL_MESSAGES_PATH;
        
        
        [SerializeField]private List<Autor> _autorsList;
        
        
        [Header("UI elements")]
        [SerializeField] private TMP_Text _textOfStory;
        [SerializeField] private Image _autorIcon;
        [SerializeField] private GameObject _autorGameObject;
        [SerializeField] private Image _panel;
        [SerializeField] private GameObject PanelWithButtons;
        [SerializeField] private TMP_Text Button1;
        [SerializeField] private TMP_Text Button2;
        [SerializeField] private TMP_Text _textOfAutor;
        [SerializeField] private GameObject DialogPanel;

        
        private Tween typeWriteTween;
         
        private Message currentMessage;
        private MessageProvider _messageProvider;
        private bool flag=true;
        private string branch="1"; 
        private int i=1;
        private float typeSpeed=15f;

        private void Awake()
        {
            ANSWERS_PATH = Application.streamingAssetsPath + "\\Story.json";
            ALL_MESSAGES_PATH = Application.streamingAssetsPath + "\\SomePart1.json";
            _messageProvider = new MessageProvider();
            _messageProvider.GenerateLineOfMessages(ALL_MESSAGES_PATH,ANSWERS_PATH, _autorsList);
            _messageProvider.WriteStartMessagesToCurrentLine();

        }


        public void ButtonClick1()
        {
            if (Button1.text.Equals("Выход"))
                Exit();
            _messageProvider.SetAnswer(1);
            _messageProvider.SwitchPartsOfStory(_messageProvider.GetAnswer());
            
            flag = true;
        }
        public void ButtonClick2()
        {
            if (Button2.text.Equals("Выход"))
                Exit();
            _messageProvider.SetAnswer(2);
            _messageProvider.SwitchPartsOfStory(_messageProvider.GetAnswer());
            
            flag = true;
        }
        

        public void NextMessage()
        {
            if(flag)
            {
                if(PanelWithButtons.transform.localScale.x>0)
                    PanelWithButtons.transform.DOScale(0, 1f).SetEase(Ease.OutBack);

                _autorGameObject.transform.localScale = new Vector3(1f, 0.5f, 0);
                _autorGameObject.transform.DOScale(2, 1f).SetEase(Ease.OutBack);
                DialogPanel.transform.localScale = new Vector3(1f, 0.5f, 0);
                DialogPanel.transform.DOScale(2, 1f).SetEase(Ease.OutBack);
                currentMessage = _messageProvider.GetCurrentMessage();
                if (currentMessage.isInteracrable)
                {
                    PanelWithButtons.transform.DOScale(2, 1f).SetEase(Ease.OutBack);
                    i++;
                    Button1.text = _messageProvider.GetVariantOfAnswer(0);
                    Button2.text = _messageProvider.GetVariantOfAnswer(1);
                    

                    flag = false;
                }

                
                _autorIcon.sprite = currentMessage.Autor.Icon;
                _panel.color = currentMessage.Autor.Color;
                _textOfAutor.text = currentMessage.Autor.Name;
                _textOfAutor.color = currentMessage.Autor.Color;
                _messageProvider.DeleteFirstMessage();
                string text = "";

                typeWriteTween = DOTween
                    .To(() => text, x => text = x, currentMessage.Text, currentMessage.Text.Length / typeSpeed).OnUpdate(
                        () =>
                        {
                            _textOfStory.text = text;
                        });
                
            }
            
        }

        private void Exit()
        {
            Application.Quit();
        }

    }
}