using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableFlashlight : MonoBehaviour
{
    [SerializeField]
    public VRTK_InteractableObject LinkedObject;
    [SerializeField]
    public GameObject MyLight;

    bool IsOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected virtual void OnEnable()
    {
        MyLight.SetActive(false);
        LinkedObject = (LinkedObject == null ? GetComponent<VRTK_InteractableObject>() : LinkedObject);

        if (LinkedObject != null && MyLight!= null)
        {
            LinkedObject.InteractableObjectUsed += InteractableObjectUsed;
            LinkedObject.InteractableObjectUnused += InteractableObjectUnused;
        }
        else
        {
            Debug.LogError("Bad Flashlight setting! No root or no light!");
        }
    }

    protected virtual void OnDisable()
    {
        if (LinkedObject != null)
        {
            LinkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            LinkedObject.InteractableObjectUnused -= InteractableObjectUnused;
        }
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        IsOn = true;
        MyLight.SetActive(true);
        //set Flashlight's direction
        //LinkedObject.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
        IsOn = false;
        MyLight.SetActive(false);
    }
}


