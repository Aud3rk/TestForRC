using System.Collections;
using UnityEngine;

namespace CodeBase.Infrustructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}