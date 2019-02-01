using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generic
{
    public class CoroutineTracker : MonoBehaviour
    {

        public List<IEnumerator> runningCoroutinesByEnum;


        public Coroutine StartTrackedCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(GenericCoroutine(coroutine));
        }

        public bool IsTrackedCoroutineRunning(IEnumerator coroutine)
        {
            return this.runningCoroutinesByEnum.Contains(coroutine);
        }

        public void StopTrackedCoroutine(IEnumerator coroutine)
        {
            if (!this.runningCoroutinesByEnum.Contains(coroutine)) return;

            StopCoroutine(coroutine);
            this.runningCoroutinesByEnum.Remove(coroutine);

        }

        public IEnumerator GenericCoroutine(IEnumerator coroutine) //TODO make more efficient tracked coroutines
        {
            this.runningCoroutinesByEnum.Add(coroutine);
            yield return StartCoroutine(coroutine);
            this.runningCoroutinesByEnum.Remove(coroutine);
        }
    }
}

