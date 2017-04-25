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

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(StringConstants.PlayerTag).transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Time.time < _cameraMotor.AnimationDuration)
            return;

        if (eventData.delta.x > 0 && _player.transform.position.x < 1.55f)
        {
            Debug.Log("SwipeRight");
            Vector3 _position = _player.transform.position;
            _position.x += 1.55f;
            _player.transform.position = Vector3.Lerp(_player.transform.position, _position, 50.0f);
        }
        else if (eventData.delta.x < 0 && _player.transform.position.x > -1.55f)
        {
            Vector3 _position = _player.transform.position;
            _position.x -= 1.55f;
            _player.transform.position = Vector3.Lerp(_player.transform.position, _position, 50.0f);
        }
    }

    public void OnDrag(PointerEventData data)
    {
    }
    // Use this for initialization

}
