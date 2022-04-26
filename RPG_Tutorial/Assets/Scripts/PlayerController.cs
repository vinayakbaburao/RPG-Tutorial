using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent (typeof(PlayerMoter))]

public class PlayerController : MonoBehaviour
{
    //For the focus
    public Interactable focus;	

    //For filtering out unwanted objects from Raycast
    public LayerMask movementMask;

    //For storing the camera
    Camera cam;
    //For the player motor
    PlayerMoter motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMoter>();
    }

    // Update is called once per frame
    void Update()
    {

        if(EventSystem.current.IsPointerOverGameObject())
            return;

        //To check for input from left mouse button
        if(Input.GetMouseButtonDown(0))
        {
            //It casts out a ray to the object that we click
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //For storing the information about the hit
            RaycastHit hit;

            //For casting the ray
            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {   
                //If some thing its move the player
                motor.MoveToPoint(hit.point);

                //Stop focusing on the object
                RemoveFocus();
            }
        }

        //To focus on objects
        if(Input.GetMouseButtonDown(1))
        {
            //It casts out a ray to the object that we click
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //For storing the information about the hit
            RaycastHit hit;

            //For casting the ray
            if(Physics.Raycast(ray, out hit, 100))
            {   
                //To check if we hit something interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //If hit something
				if (interactable != null)
				{
					SetFocus(interactable);
				}

            }
        }
    }
    //Function for focus
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDeFocused();
                       
            focus = newFocus;
            motor.followTarget(newFocus);
        }

        
        newFocus.OnFocused(transform);
       
    }

    //Function for removing focus
    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDeFocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}
