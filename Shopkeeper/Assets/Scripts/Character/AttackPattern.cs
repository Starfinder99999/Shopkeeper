using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    public class AttackPattern : Ability
    {
        private List<IEnumerator> skillSequence;
        private Coroutine coroutine;

        public AttackPattern(string name, List<IEnumerator> skills) : base(name)
        {
            this.skillSequence = skills;
        }

        


    }
}