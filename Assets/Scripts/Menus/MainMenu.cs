using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClawBrawl
{
    public class MainMenu : MonoBehaviour
    {
        public static void OnClickPlay()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public static void OnClickQuit()
        {
            Application.Quit();
        }
    }
}
