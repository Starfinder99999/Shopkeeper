using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    public class Skill : MonoBehaviour
    {
        [SerializeField] public string skillName = "Skill";
        [SerializeField] public string skillDescription = "A Skill";
        [SerializeField] public int energyCost = 0;
        [SerializeField] public int healthCost = 0;
        [SerializeField] public int baseSpeed = 1;
        [SerializeField] public float cooldown = 1f;

        virtual public IEnumerator Use() { yield return new WaitForEndOfFrame();}
    }

    public class WeaponTechnique : Skill
    {
        [SerializeField] public WeaponMasteryTypes WeaponMasteryType = WeaponMasteryTypes.oneHandedBade;
        [SerializeField] public float RequiredMastery = 0f;

        
    }

    public class Spell : Skill
    {
        [SerializeField] public float WisdomRequired = 0f;
        [SerializeField] float IntelligenceRequired = 0f;

    }

    public class Whirlwind : WeaponTechnique
    {

        public override IEnumerator Use()
        {
            return base.Use();
        }
    }

    public class Wait : Skill
    {
        [SerializeField] new public float cooldown = 0f;

        public IEnumerator Use(float time)
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