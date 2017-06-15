using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMotor : MonoBehaviour
    {
        private CameraMotor _cameraMotor = new CameraMotor();

        private float _speed = -0.1f;

        public float Speed { get { return _speed; } }

        private bool _isDead = false;
        public bool IsDead { get { return _isDead; } }

        private ScoreHelper _scoreHealper;
        private AnimationController _animationController;

        void Start()
        {
            _scoreHealper = GetComponent<ScoreHelper>();
            _animationController = GetComponent<AnimationController>();
            _animationController.StartGame(isStartGame: true);
        }

        public void SetSpeed(float modifier)
        {
            _speed = (_speed + (modifier / 10) * -1)/2;
            _animationController.StartGame(isStartGame: false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == StringConstants.EnemyTag)
            {
                _animationController.DeadAnimation();
                Death();
            }
        }

        private void Death()
        {
            _isDead = true;
            _scoreHealper.OnDeath();
        }
    }
}