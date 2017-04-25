using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenuScript : MonoBehaviour
{
    public Text ScoreText;
    public Image BackgroundImage;
    public GameObject SwipePanel;

    private bool _isShowned = false;
    private float _transition = 0.0f;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(value: false);
    }

    private void Update()
    {
        if (!_isShowned)
            return;

        _transition += Time.deltaTime;
        BackgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.white, _transition);
    }

    // Update is called once per frame
    public void ToogleDeathMenu(float score)
    {
        SwipePanel.SetActive(value: false);
        gameObject.SetActive(value: true);
        ScoreText.text = ((int)score).ToString();
        _isShowned = true;
    }

    public void GameReload()
    {
        Debug.Log("GameReload");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(StringConstants.MenuScene);
    }
}
