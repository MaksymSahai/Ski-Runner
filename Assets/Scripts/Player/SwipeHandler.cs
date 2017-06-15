using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Transform _player;
    Vector3 _endPosition;
    private CameraMotor _cameraMotor = new CameraMotor();
    private AnimationController _animationController;
    private float _moveAnimationSpeed;
    private bool _isMoveLeft;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(StringConstants.PlayerTag).transform;
        _animationController = GameObject.FindGameObjectWithTag(StringConstants.PlayerTag).GetComponent<AnimationController>();
        _endPosition = _player.transform.position;
        _moveAnimationSpeed = _animationController.GetSpeed();
    }

    private void Update()
    {
        if (_isMoveLeft)
        {
            if (_player.transform.position != _endPosition)
                _player.transform.position = Vector3.Lerp(_player.transform.position, _endPosition, Time.deltaTime * _moveAnimationSpeed * 3f);
            else
                _isMoveLeft = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Time.timeSinceLevelLoad <= _cameraMotor.AnimationDuration)
            return;

        if (eventData.delta.x > 0 && _player.transform.position.x < 1.55f)
        {
            _animationController.MoveRightAnimation();
            _endPosition.x += 1.55f;
            _isMoveLeft = true;
            //Vector3 _position = _player.transform.position;
            //_position.x += 1.55f;
            //_player.transform.position = _position;

        }
        else if (eventData.delta.x < 0 && _player.transform.position.x > -1.55f)
        {
            _animationController.MoveLeftAnimation();
            _endPosition.x -= 1.55f;
            _isMoveLeft = true;
            ///_player.transform.position = Vector3.Lerp(_player.transform.position, _endPosition, Time.deltaTime * 5.0f);
            ///_player.transform.position = Vector3(Mathf.Lerp(_player.transform.position, _endPosition, Time.deltaTime * 5.0f), 0, 0);
            ///StartCoroutine(SwapLeft());

        }
    }

    private IEnumerator SwapLeft()
    {
        yield return new WaitForSeconds(1);
        Vector3 _position = _player.transform.position;
        _position.x -= 1.55f;
        _player.transform.position = _position;
    }

    public void OnDrag(PointerEventData data)
    {
    }
    // Use this for initialization

}
