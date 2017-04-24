using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileManager
{
    public class TileManager : MonoBehaviour
    {

        public GameObject[] tilePrefabs;

        private Transform _playerTransform;
        private float _spawnZ = 0.0f;
        private float _saveZone = 10.0f;
        private float _tileLength = 22.5f;
        private int _amountTilesOnScreen = 4;

        private int _lastPrefabIndex = 0;

        private List<GameObject> _activeTiles;

        // Use this for initialization
        private void Start()
        {
            _activeTiles = new List<GameObject>();
            _playerTransform = GameObject.FindGameObjectWithTag(StringConstants.PlayerTag).transform;
            for (int i = 0; i < _amountTilesOnScreen; i++)
            {
                if (i < 2)
                    SpawnTile(0);
                else
                    SpawnTile();
            }
        }

        private void Awake()
        {
            var _light = GameObject.FindGameObjectWithTag("light").GetComponent<Light>();
            _light.intensity = 1.6f;

        }
        // Update is called once per frame
        private void Update()
        {
            if (_playerTransform.position.z - _saveZone > (_spawnZ - _amountTilesOnScreen * _tileLength))
            {
                SpawnTile();
                DeleteTile();
            }
        }

        private void SpawnTile(int prefabIndex = -1)
        {
            GameObject _go;

            if (prefabIndex == -1)
                _go = Instantiate(tilePrefabs[GetRandomPrefabIndex()]) as GameObject;
            else
                _go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

            _go.transform.SetParent(transform);
            _go.transform.position = Vector3.forward * _spawnZ;
            _spawnZ += _tileLength;
            _activeTiles.Add(_go);
        }

        private void DeleteTile()
        {
            Destroy(_activeTiles[0]);
            _activeTiles.RemoveAt(0);
        }

        private int GetRandomPrefabIndex()
        {
            if (tilePrefabs.Length <= 1)
                return 0;

            int _randomIndex = _lastPrefabIndex;
            while (_randomIndex == _lastPrefabIndex)
            {
                _randomIndex = Random.Range(0, tilePrefabs.Length);
            }

            _lastPrefabIndex = _randomIndex;
            return _randomIndex;
        }
    }
}