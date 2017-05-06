using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TileManager
{
    public class TileManager : MonoBehaviour
    {

        public GameObject[] tilePrefabs;

        private Transform _playerTransform;
        private float _spawnZ = 0.0f;
        private float _tileLength = 11.3f;
        private int _amountTilesOnScreen = 10;

        private int _lastPrefabIndex = 0;

        private List<GameObject> _activeTiles;

        private static TileManager _instance;
        
        public static TileManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = GameObject.FindObjectOfType<TileManager>();

                return _instance;
            }
        }

        // Use this for initialization
        private void Start()
        {
            _activeTiles = new List<GameObject>();
            _playerTransform = GameObject.FindGameObjectWithTag(StringConstants.PlayerTag).transform;
            for (int i = 0; i < _amountTilesOnScreen; i++)
            {
                if (i < 5)
                    SpawnTile(0, isStartSpawn: true);
                else
                    SpawnTile(isStartSpawn: true);
            }
        }

        private void Awake()
        {
            var _light = GameObject.FindGameObjectWithTag("light").GetComponent<Light>();
            _light.intensity = 0.7f;

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == StringConstants.PlayerTag)
            {
                SpawnTile();
                DeleteTile();
            }
        }

        public void SpawnTile(int prefabIndex = -1, bool isStartSpawn = false)
        {
            GameObject _go;

            if (prefabIndex == -1)
            {
                _go = Instantiate(tilePrefabs[GetRandomPrefabIndex()]) as GameObject;
            }
            else
            {
                _go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            }

            _go.transform.SetParent(transform);

            if (isStartSpawn)
            {
                _go.transform.position = Vector3.forward * _spawnZ;
                _spawnZ += _tileLength;
            }
            else
            {
                _go.transform.position = Vector3.forward * 105.7f;
            }

            
            _activeTiles.Add(_go);
        }

        public void DeleteTile()
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