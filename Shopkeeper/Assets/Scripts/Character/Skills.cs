using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions.Skills
{
    public class Skill : MonoBehaviour
    {
        [SerializeField] public string skillName = "Skill";
        [SerializeField] public string skillDescription = "A Skill";
        [SerializeField] public AbilityRequirements requirements;

        virtual public IEnumerator Use() { yield return new WaitForEndOfFrame();}
    }



    public class Whirlwind : Skill
    {

        public override IEnumerator Use()
        {
            return base.Use();
        }
    }

    public class Wait : Skill
    {

        public IEnumerator Use(float time)
        {
            float timeWaited = 0f;
            Debug.Log("Start Wait");
            while (timeWaited < time)
            {
                timeWaited += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }
            Debug.Log("End Wait");
        }
    }
}