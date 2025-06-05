using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemCollector : MonoBehaviour
{
    private SignalBus signalBus;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out CollectibleItem component))
        {
            signalBus.Fire(new CollectItemSignal(component.ItemData,component.Amount));
            Destroy(component.gameObject);
        }
    }
}
