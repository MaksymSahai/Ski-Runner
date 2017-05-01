using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuScript : MonoBehaviour
    {
        public Text HightScore;

        private void Start()
        {
            HightScore.text = "Hightscore : " + ((int)PlayerPrefs.GetFloat("HightScore")).ToString();
        }

        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}