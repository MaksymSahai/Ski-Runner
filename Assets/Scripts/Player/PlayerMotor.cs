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

        void Start()
        {
            _scoreHealper = GetComponent<ScoreHelper>();
        }


        void Update()
        {
        }

        public void SetSpeed(float modifier)
        {
            _speed = (_speed + (modifier / 10) * -1)/2;
            Debug.Log(_speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == StringConstants.EnemyTag)
            {
                Death();
            }
        }

        private void Death()
        {
            _isDead = true;
            Debug.Log(_isDead);
            Debug.Log("Dead");
            _scoreHealper.OnDeath();
        }
    }
}