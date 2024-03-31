using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    [SerializeField] private List<GameObject> _roads; [SerializeField] private float _roadLenth = 40;
    private GameObject _road;
    private GameObject _roadNext;
    private Vector3 _roadPosition;

    private void Start()
    {
        _roadNext = _roads[Random.Range(0, _roads.Count - 1)];
        _road = Instantiate(_roadNext, transform.position, Quaternion.identity);
        _roadLenth = _road.transform.localScale.z;
        //_road = Instantiate(_roads[Random.Range(0, _roads.Count - 1)],
        //    new Vector3(0, 0, _roads[0].transform.localScale.z ), Quaternion.identity);
       
     
    }

    private void Update()
    {

        _roadPosition.z = _road.transform.position.z * 4;


        if (_road != null)
        {
            if (_roadPosition.z < _road.transform.localScale.z *20)
            {

                Spawn();
                
            }
        }
    }



    public void Spawn() {
        Vector3 position;
        position = transform.position;
        _roadNext = _roads[Random.Range(0, _roads.Count - 1)];

        if(_roadNext.transform.localScale.z <= _road.transform.localScale.z)
        {
            position.z = _road.transform.position.z + _road.transform.localScale.z;
        }
        else
        {
            position.z =  _road.transform.position.z + _roadNext.transform.localScale.z - _road.transform.localScale.z;
        }
        
        _road = Instantiate(_roadNext, position, Quaternion.identity);
    } 
}
