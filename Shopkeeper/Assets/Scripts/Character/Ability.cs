using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character.Actions
{

    public class Ability : MonoBehaviour
    {
        public readonly Generic.CoroutineTracker coroutineTracker;

        public float Cooldown { get; private set; }
        public string Name { get; private set; }

        public Ability(Generic.CoroutineTracker tracker, float cooldown, string name)
        {
            this.coroutineTracker = tracker;
            this.Name = name;
            this.Cooldown = cooldown;
        }

        virtual public IEnumerator Use()
        {
            yield return new WaitForEndOfFrame();
        }
    }
}