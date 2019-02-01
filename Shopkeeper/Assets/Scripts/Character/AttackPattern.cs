using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    public class AttackPattern : Ability
    {
        private List<IEnumerator> skillSequence;
        private Coroutine coroutine;

        public AttackPattern(Generic.CoroutineTracker tracker, float cooldown, string name, List<IEnumerator> skills) : base(tracker, cooldown, name)
        {
            this.skillSequence = skills;
        }

        public override IEnumerator Use()
        {
            foreach(IEnumerator skill in skillSequence)
            {
                this.coroutine = this.coroutineTracker.StartTrackedCoroutine(skill);
                while (this.coroutineTracker.IsTrackedCoroutineRunning(skill))
                {
                    yield return new WaitForEndOfFrame();
                }
            }
        }


    }
}