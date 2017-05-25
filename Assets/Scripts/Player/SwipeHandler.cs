using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Transform _player;
    private CameraMotor _cameraMotor = new CameraMotor();
    private AnimationController _animationController;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(StringConstants.PlayerTag).transform;
        _animationController = GameObject.FindGameObjectWithTag(StringConstants.PlayerTag).GetComponent<AnimationController>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Time.timeSinceLevelLoad <= _cameraMotor.AnimationDuration)
            return;

        if (eventData.delta.x > 0 && _player.transform.position.x < 1.55f)
        {
            Vector3 _position = _player.transform.position;
            _position.x += 1.55f;
            _player.transform.position = _position;
            
        }
        else if (eventData.delta.x < 0 && _player.transform.position.x > -1.55f)
        {
            _animationController.MoveLeftAnimation();
            StartCoroutine(SwapLeft());
            
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
