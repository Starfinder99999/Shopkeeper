using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
    public enum WeaponMasteryTypes
    {
        oneHandedBade,
        twoHandedBlade,
        twinBlades,
        oneHandedBlunt,
        twoHandedBlunt
    }
    
    public class WeaponMastery : MonoBehaviour
    {
        public Dictionary<WeaponMasteryTypes, float> WeaponMasteryLevels { get; set; }

        //TODO add Skillknowledge
    }
}