using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class LoadLevel : MonoBehaviour
    {

        public void LoadNewScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}