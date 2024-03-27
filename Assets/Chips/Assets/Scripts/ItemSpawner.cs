using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class ItemSpawner: MonoBehaviour
{
    [SerializeField] List<Transform> _pointsToSpawn;
    [SerializeField] GameObject _item;

    [SerializeField, Range(0, 100f), Tooltip("Сюда записывается шанс выпадения айтемов. 20 - 20%, 68 - 68% к примеру")]
    float _randomPercent;
   
    float _random;

    private void OnEnable()
    {
        

        foreach(var point in _pointsToSpawn)
        {
            if(point == null)
            {
                _pointsToSpawn.Remove(point);
                Debug.LogAssertion("PLZ, DELETE NULL POINT IN SPAWNER)))");
            }
        }

        _random = Random.Range(0, 100);
        if (_random <= _randomPercent)
        {
            foreach (var points in _pointsToSpawn)
            {
               var a = LeanPool.Spawn(_item, points.transform.position, Quaternion.identity);
                a.transform.SetParent(points);
            }
        }
    }
}