using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class BackpackSlotUI : MonoBehaviour, IPointerDownHandler
{
    private SignalBus signalBus;

    [SerializeField] Image icon;
    [SerializeField] Text counter;
    [SerializeField] Button destroyItemButton;

    public int index = -1;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }
    private void Awake()
    {
        icon.gameObject.SetActive(false);
        counter.gameObject.SetActive(false);
        destroyItemButton.gameObject.SetActive(false);

        destroyItemButton.onClick.AddListener(() => OnDestroyButton());
    }
    public void OnPointerDown(PointerEventData eventData)
        => signalBus.Fire(new BackpackSlotClickedSignal(index));

    public void UpdateContent(BackpackSlotData data)
    {
        if(data.isEmpty)
        {
            Clear();
            return;
        }

        icon.gameObject.SetActive(true);
        icon.sprite = data.ItemData.Icon;

        if(data.StackCount > 1)
        {
            counter.gameObject.SetActive(true);
            counter.text = data.StackCount.ToString();
        }
        else
        {
            counter.gameObject.SetActive(false);
        }

    }

    public void Clear()
    {
        icon.gameObject.SetActive(false);
        counter.gameObject.SetActive(false);
    }

    public void ShowDeleteButton(bool value) => destroyItemButton.gameObject.SetActive(value);
    private void OnDestroyButton()
    {
        signalBus.Fire(new BackpackSlotDeleteClickedSignal(index));
        ShowDeleteButton(false);
    }
}
