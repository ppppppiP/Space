using UnityEngine;
using Zenject;

public class PortalTeleporter: MonoBehaviour
{
    [SerializeField] Transform _playerPosition;
    [SerializeField] Transform _newPosition;
    [Inject] SpecialEquipmentObserver _observ;

    private void OnEnable()
    {
        _observ.OnPortalEnter += Teleport;
    }

    private void OnDisable()
    {
        _observ.OnPortalEnter -= Teleport;
    }

    private void Teleport(Transform player)
    {
        Debug.Log("tpp");
        Debug.Log(_playerPosition.transform.position);
        player.transform.position = _newPosition.transform.position;
        
        Debug.Log(_newPosition.transform.position);
    }
}