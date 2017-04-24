using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class PlayerMotor : MonoBehaviour
    {
        private CameraMotor _cameraMotor = new CameraMotor();
        private CharacterController _controller;
        private Vector3 _moveVector;

        private float _speed = 5.0f;
        private float _verticalVelocity = 0.0f;
        ///private float _gravity = 12.0f;

        ///private float _startTime;

        private bool _isDead = false;
        public bool IsDead { get { return _isDead; } }

        private ScoreHelper _scoreHealper;

        void Start()
        {
            _controller = GetComponent<CharacterController>();
            _scoreHealper = GetComponent<ScoreHelper>();
        }


        void Update()
        {
            if (_isDead)
                return;

            if (Time.time < _cameraMotor.AnimationDuration)
            {
                _controller.Move(Vector3.forward * _speed * Time.deltaTime);
                return;
            }

            _moveVector = Vector3.zero;

            _moveVector.x = Input.GetAxisRaw("Horizontal") * _speed;
            _moveVector.y = _verticalVelocity;
            _moveVector.z = _speed;


            _controller.Move(_moveVector * Time.deltaTime);
        }

        public void SetSpeed(int modifier)
        {
            _speed = _speed + modifier;
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.tag == StringConstants.EnemyTag)
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