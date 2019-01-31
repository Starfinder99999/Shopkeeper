using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character.Actions
{
    public class Skill : MonoBehaviour
    {
        public string Name { get;  set; }
        public int EnergyCost { get;  set; }
        public int HealthCost { get;  set; }
        public int BaseSpeed { get;  set; }
        public float Cooldown { get;  set; }

        virtual public bool Use() { return true; }
    }

    public class WeaponTechnique : Skill
    {
        public WeaponMasteryTypes WeaponMasteryType { get; private set; }
        public float RequiredMastery { get; private set; }

        
    }

    public class Spell : Skill
    {
        public float WisdomRequired { get; private set; }
        public float IntelligenceRequired { get; private set; }

    }

    public class Whirlwind : WeaponTechnique
    {

        override public bool Use()
        {
            //TODO make actualy working techniques
            return true;
        }
    }

    public class Wait : Skill
    {
        public Wait()
        {
            this.Cooldown = 0f;
        }

        override public bool Use()
        {
            return this.Use(1f);
        }

        public bool Use(float time)
        {
            StartCoroutine(UseWait(time));
            return true;
        }

        private IEnumerator UseWait(float time)
        {
            float timeWaited = 0f;

            while (timeWaited < time)
            {
                timeWaited += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}