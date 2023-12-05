using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrustructure
{
    public class GameBootStrapper: MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootStrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}