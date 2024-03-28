using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemData> content = new List<ItemData>();           //Création  d'une liste de type ItemData afin de pouvoir stocker

    [SerializeField]
    private GameObject inventoryPanel;                              //

    const int INVENTORYSIZE = 8;                                    //Taille maximum de l'inventaire

    [Header("Action Panel References")]

    [SerializeField]
    private GameObject actionPanel;

    [SerializeField]
    private GameObject useItemButton;

    [SerializeField]
    private GameObject dropItemButton;

    [SerializeField]
    private GameObject readItemButton;

    private ItemData itemCurrentlySelected;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))                             //Si l'on appuit sur I
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);   //L'inventaire prend l'état opposé de celui auquelle il est actuellement
        }

    }

    public bool IsFull()
    {
        return INVENTORYSIZE == content.Count;                      //si taille inventaire max = taille actuel alors l'inventaire est plein
    }

    public void OpenActionPanel(ItemData item)
    {
        itemCurrentlySelected = item;

        if (item == null)
        {
            return;
        }

        switch (item.itemType)
        {
            case ItemType.Decor:
                readItemButton.SetActive(false);
                useItemButton.SetActive(false);
                break;
            case ItemType.Enigme:
                readItemButton.SetActive(false);
                break;
        }
        actionPanel.SetActive(true);
    }

    public void DropActionButton()
    {

    }
}

