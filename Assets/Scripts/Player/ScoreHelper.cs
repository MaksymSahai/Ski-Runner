using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class ScoreHelper : MonoBehaviour
    {

        public Text ScoreText;
        ///public DeathMenuScript DeathMenu;

        private float _score = 0.0f;

        private int _difficultyLevel = 1;
        private int _maxDifficultyLevel = 10;
        private int _scoreToNextLevel = 10;

        private bool _isDead = false;

        private PlayerMotor _playerMotor;

        // Use this for initialization
        private void Start()
        {
            _playerMotor = GetComponent<PlayerMotor>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_isDead)
                return;

            if (_score >= _scoreToNextLevel)
                LevelUp();

            _score += (Time.deltaTime * _difficultyLevel) / 2;
            ScoreText.text = ((int)_score).ToString();
        }

        private void LevelUp()
        {
            if (_difficultyLevel == _maxDifficultyLevel)
                return;

            _scoreToNextLevel *= 2;
            _difficultyLevel++;

            _playerMotor.SetSpeed(_difficultyLevel);
            
        }

        public void OnDeath()
        {
            _isDead = true;

            if (PlayerPrefs.GetFloat("HightScore") < _score)
                PlayerPrefs.SetFloat("HightScore", _score);
            //DeathMenu.ToogleDeathMenu(_score);
        }
    }
}