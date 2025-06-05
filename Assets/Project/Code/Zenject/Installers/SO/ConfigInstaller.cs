using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
{
    [SerializeField] ItemDatabase itemDatabase;
    [Space]
    [SerializeField] PlayerConfig playerConfig;
    [SerializeField] BackpackConfig backpackConfig;
    public override void InstallBindings()
    {
        Container.BindInstance(itemDatabase);

        Container.BindInstance(playerConfig);
        Container.BindInstance(backpackConfig);
    }
}