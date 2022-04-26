
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("We have picked up " + item.name);

        bool wasPickedUp = Inventory.instance.Add(item);

        //Add it to the inventory
        if(wasPickedUp)
            Destroy(gameObject);
    }
}
