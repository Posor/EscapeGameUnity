using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickable : MonoBehaviour
{
    [SerializeField]
    public Transform inventorySlotsParents;                                                       //Variable de type Transform 

    [SerializeField]
    public float pickupRange = 2.6f;                                                              //Variable de type float pour distance Raycast

    public Inventory inventory;                                                                   //Variable de type Inventory

    public ItemData item;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;                                                                           //Variable de type RaycastHit                                   

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))         //Création du raycast
        {
            if(hit.transform.CompareTag("Item"))                                                  //S'il touche un objet avec comme tag Item
            {

                Debug.Log("Il y a un item devant vous");                                          // Inscription dans la console

                if(Input.GetKeyDown(KeyCode.E) && !inventory.IsFull())                            //Si l'utilisateur appuie sur "E" et que l'inventaire n'est pas plein
                {
                    inventory.content.Add(hit.transform.gameObject.GetComponent<Item>().item);    //Il ajoute l'item dans l'inventaire
                    Destroy(hit.transform.gameObject);                                            //Le détruit physiquement
                    RefreshContent();                                                             //appelle la fonction RefreshContent
                }
            }

 
        }
        
    }

    private void RefreshContent()                                                                 //Fonction permettant d'actualiser les images dans l'inventaire
    {
        for (int i = 0; i < inventory.content.Count; i++)
        {
            Slot currentSlot = inventorySlotsParents.GetChild(i).GetComponent<Slot>();
            currentSlot.item = inventory.content[i];
            currentSlot.itemVisual.sprite = inventory.content[i].visual;


        }
    }


}
