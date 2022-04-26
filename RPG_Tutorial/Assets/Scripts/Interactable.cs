
using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    //The distance the player needs to be inorder to interact with items
    public float radius = 3f;

    public Transform interactionTransform;

    bool isFocus = false;

    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        //Can be overwritten
        Debug.Log("This is interacting with " + transform.name);
    }

    void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
            interactionTransform = transform;
            
        Gizmos.color = Color.yellow;        //For the color of the object
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
