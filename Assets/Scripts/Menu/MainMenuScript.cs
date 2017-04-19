using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuScript : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}