using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SignalsInstaller", menuName = "Installers/SignalsInstaller")]
public class SignalsInstaller : ScriptableObjectInstaller<SignalsInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<CollectItemSignal>();

        Container.DeclareSignal<BackpackToggleSignal>();
        Container.DeclareSignal<BackpackSlotClickedSignal>();
        Container.DeclareSignal<BackpackSlotDeleteClickedSignal>();
    }
}