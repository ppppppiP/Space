using UnityEngine;

namespace StarWars
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] Transform _playerPos;
        [SerializeField] private Transform _teleportPoint;
        [SerializeField] Speeds numberOfSpeed;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerHP>(out PlayerHP pla))
            {
                _playerPos = pla.gameObject.transform;
                _playerPos.transform.position = _teleportPoint.transform.position;
                Debug.Log("asdfasdfasdfasdf");
                switch (numberOfSpeed)
                {
                    case Speeds.Speed0:

                        RoadSpeed.Instance.CanMove = true;
                        RoadSpeed1.Instance.CanMove = false;
                        RoadSpeed2.Instance.CanMove = false;
                        RoadSpeed3.Instance.CanMove = false;
                        break;
                    case Speeds.Speed1:

                        RoadSpeed.Instance.CanMove = false;
                        RoadSpeed1.Instance.CanMove = true;
                        RoadSpeed2.Instance.CanMove = false;
                        RoadSpeed3.Instance.CanMove = false;
                        break;
                    case Speeds.Speed2:

                        RoadSpeed.Instance.CanMove = false;
                        RoadSpeed1.Instance.CanMove = false;
                        RoadSpeed2.Instance.CanMove = true;
                        RoadSpeed3.Instance.CanMove = false;
                        break;
                    case Speeds.Speed3:

                        RoadSpeed.Instance.CanMove = false;
                        RoadSpeed1.Instance.CanMove = false;
                        RoadSpeed2.Instance.CanMove = false;
                        RoadSpeed3.Instance.CanMove = true;
                        break;
                }
            }
        }
    }


  
}