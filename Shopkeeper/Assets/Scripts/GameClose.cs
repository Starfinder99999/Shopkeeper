using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class GameClose : MonoBehaviour
    {

        public void CloseGame()
        {
            Debug.Log("quit");
            Application.Quit();
        }
    }
}