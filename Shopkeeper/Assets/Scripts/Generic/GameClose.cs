using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class GameClose : MonoBehaviour
    {
        void Awake(){
            Debug.Log("Hallo");
        }

        public void CloseGame()
        {
            Debug.Log("quit");
            Application.Quit();
            Debug.Log("Close Game");
        }
    }
}