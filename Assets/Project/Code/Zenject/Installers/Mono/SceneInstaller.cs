using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] UIControlProvider uIControlProvider;
    public override void InstallBindings()
    {
        Container.BindInstance(uIControlProvider);
    }
}