using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AnimationController : MonoBehaviour
    {
        private CameraMotor _cameraMotor = new CameraMotor();
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        internal void MoveLeftAnimation()
        {

        }

        internal void DeadAnimation()
        {
            _animator.SetTrigger("Dead");
            _animator.SetBool("IsRun", false);
        }

        internal void StartGame(bool isStartGame)
        {
            if (isStartGame)
                StartCoroutine(StopStartGame(_cameraMotor.AnimationDuration));
            else
                StartCoroutine(StopStartGame(3));
        }

        private IEnumerator StopStartGame(float second)
        {
            _animator.SetBool("IsStart", true);
            _animator.SetBool("IsRun", false);

            yield return new WaitForSeconds(second);
            _animator.SetBool("IsStart", false);
            _animator.SetBool("IsRun", true);
        }
    }
}