using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BackpackHandler : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Button closeButton;
    [SerializeField] BackpackSlotUI slotPrefab;
    [SerializeField] Transform slotParent;


    public List<BackpackSlotData> slotsData = new();
    public List<BackpackSlotUI> slotsUI = new();

    private DiContainer container;
    private SignalBus signalBus;
    private BackpackConfig backpackConfig;
    private UIControlProvider uIControlProvider;

    [Inject]
    private void Construct(DiContainer container, SignalBus signalBus, BackpackConfig backpackConfig, UIControlProvider uIControlProvider)
    {
        this.container = container;
        this.signalBus = signalBus;
        this.backpackConfig = backpackConfig;
        this.uIControlProvider = uIControlProvider;
    }
    private void Awake()
    {
        Toggle(true);
        InitSlotsData();
        InitSlotsUI();
        Toggle(false);

        closeButton.onClick.AddListener(() => signalBus.Fire(new BackpackToggleSignal(false)));

        signalBus.Subscribe<CollectItemSignal>(s => TryCollectItem(s.ItemData,s.Amount));
        signalBus.Subscribe<BackpackSlotDeleteClickedSignal>(s => DestroyItemInSlot(s.Index));

        signalBus.Subscribe<BackpackSlotClickedSignal>(s => showDeleteButton(s.Index));
        signalBus.Subscribe<BackpackToggleSignal>(s => Toggle(s.Value));

    }
    private void InitSlotsData()
    {
        for (int i = 0; i < backpackConfig.SlotsCount; i++)
        {
            slotsData.Add(new BackpackSlotData());
        }
    }
    private void InitSlotsUI()
    {
        for (int i = 0; i < slotsData.Count; i++)
        {
            BackpackSlotUI slotUI = container.InstantiatePrefabForComponent<BackpackSlotUI>(slotPrefab);
            slotUI.transform.SetParent(slotParent);
            slotUI.index = i;
            slotUI.UpdateContent(slotsData[i]);

            slotsUI.Add(slotUI);
        }
    }
    private void TryCollectItem(ItemData itemData, int amount = 1)
    {
        var availableSlots = slotsData.Where(s => s.ItemData == itemData && s.StackCount < itemData.MaxStack || s.isEmpty);
        foreach (var slot in availableSlots)
        {
            amount = slot.AddToStack(itemData, amount);

            if(amount<=0) break;
        }

        UpdateSlotsUI();
    }
    private void DestroyItemInSlot(int index)
    {
        slotsData[index].Clear();
        slotsUI[index].Clear();
    }
    private void UpdateSlotsUI()
    {
        for (int i = 0; i < slotsUI.Count; i++)
        {
            slotsUI[i].UpdateContent(slotsData[i]);
        }
    }
    private void showDeleteButton(int index)
    {
        for (int i = 0; i < slotsUI.Count; i++)
        {
            slotsUI[i].ShowDeleteButton(index == i);
        }
    }
    private void Toggle(bool toggle)
    {
        if (toggle)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
            showDeleteButton(-1);
        }

    }
}
