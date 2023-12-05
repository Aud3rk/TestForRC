using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrustructure;
using UnityEngine;

namespace CodeBase.Infrustructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    
    }
} 
