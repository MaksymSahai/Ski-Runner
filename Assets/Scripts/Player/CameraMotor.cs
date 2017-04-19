using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CameraMotor : MonoBehaviour
    {

        private Transform _lookAt;
        private Vector3 _startOffset;
        private Vector3 _moveVector;

        private float _transition = 0.0f;
        private float _animationDuration = 3.0f;
        public float AnimationDuration { get { return _animationDuration; } }
        private Vector3 _animationOffset = new Vector3(0, 5, 5);


        // Use this for initialization
        void Start()
        {
            _lookAt = GameObject.FindGameObjectWithTag(StringConstants.PlayerTag).transform;
            _startOffset = transform.position - _lookAt.position;
        }

        // Update is called once per frame
        void Update()
        {
            _moveVector = _lookAt.position + _startOffset;

            _moveVector.x = 0;
            _moveVector.y = Mathf.Clamp(_moveVector.y, 3, 5);

            if (_transition > 1.0f)
            {
                transform.position = _moveVector;
            }
            else
            {
                transform.position = Vector3.Lerp(_moveVector + _animationOffset, _moveVector, _transition);
                _transition += Time.deltaTime * 1 / _animationDuration;
                transform.LookAt(_lookAt.position + Vector3.up);
            }
        }
    }
}