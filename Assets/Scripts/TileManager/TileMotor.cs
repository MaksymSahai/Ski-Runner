using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TileManager
{
    public class TileMotor : MonoBehaviour
    {

        private PlayerMotor _playerMotor;

        private void Start()
        {
            _playerMotor = GameObject.FindGameObjectWithTag(StringConstants.PlayerTag).GetComponent<PlayerMotor>();
        }

        void FixedUpdate()
        {
            if (_playerMotor.IsDead)
                return;

            transform.Translate(new Vector3(0f, 0f, _playerMotor.Speed));
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == StringConstants.PlayerTag)
            {
                TileManager.Instance.SpawnTile();
                TileManager.Instance.DeleteTile();
            }
        }
    }
}
