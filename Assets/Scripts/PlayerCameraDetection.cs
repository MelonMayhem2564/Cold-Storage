using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


public class PlayerCameraDetection : MonoBehaviour
{
    Camera camera;
    MeshRenderer MeshRenderer;
    Plane[] cameraFrustum;
    Collider collider;

    public float playerReach = 3f;
    Interactable currentInteractable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
        MeshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            CheckInteraction();
            if (Input.GetKeyDown(KeyCode.X) && currentInteractable != null)
            {
                currentInteractable.Interact();
            }
        }
        else
        {

        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // if colliders with anything within player reach
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable")  // if looking at interactable object
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                // if there is a currentInteractable and it is not the newInteractable
                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else  // if new interactable is not enabled
                {
                    DisableCurrentInteractable();
                }
            }
            else  // if not an interactable
            {
                DisableCurrentInteractable();
            }
        }
        else  // if nothing in reach
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HUDController.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {
        HUDController.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
