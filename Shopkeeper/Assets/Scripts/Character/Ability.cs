using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character.Actions
{
    public class Ability : MonoBehaviour
    {
        
        virtual public bool Use()
        {
            return true;
        }
    }
}