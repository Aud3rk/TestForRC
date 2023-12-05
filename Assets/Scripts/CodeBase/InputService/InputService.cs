using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace CodeBase.Infrustructure.InputService
{
    public class InputService : MonoBehaviour
    {
        [SerializeField]private UIMessageService uiMessageService;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                uiMessageService.NextMessage();
            }
        }

    }
}