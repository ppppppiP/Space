using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
       Container.Bind<SpecialEquipmentObserver>().FromNew().AsSingle();
    }
}