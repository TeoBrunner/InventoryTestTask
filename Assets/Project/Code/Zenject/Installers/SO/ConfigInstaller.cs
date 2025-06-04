using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
{
    [SerializeField] PlayerConfig playerConfig;
    public override void InstallBindings()
    {
        Container.BindInstance(playerConfig);
    }
}