using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item item;
    bool alreadyPickup = false;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventory.Singleton.PickupItem(item);
                alreadyPickup = true;
                Destroy(this.gameObject);
            }
        }
    }
}
