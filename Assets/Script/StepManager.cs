using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[System.Serializable]
public class DisplayEvent : UnityEvent<string> { }


public class StepManager : MonoBehaviour
{

    public List<Step> StepList;
    public DisplayEvent OnDisplay;
    public int CurrentStep;

    // Start is called before the first frame update
    void Start()
    {
        StepList = GetComponentsInChildren<Step>().ToList();

        CurrentStep = 0;

        foreach (Step s in StepList)
        {
            s.gameObject.SetActive(false);
        }
        StartStep(0);

        //GameObject UiRooit = GameObject.Find("Canvas");
        //var BTNList = UiRooit.GetComponentsInChildren<UnityEngine.UI.Button>();     

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (OutOfBounds())
        {
            return;
        }

        if (Input.GetKeyDown(StepList[CurrentStep].TargetKey))
        {
            StepList[CurrentStep].gameObject.SetActive(false);
            CurrentStep++;

            if (!OutOfBounds())
            {
                StepList[CurrentStep].gameObject.SetActive(true);
            }
        }
        */
    }

    public void ReceiveEvent(string key)
    {
        if(OutOfBounds())
        {
            //ResetStep();
            return;
        }

        if(StepList[CurrentStep].TargetKey == key)
        {
            StepList[CurrentStep].OnComplete.Invoke(true);
            StepList[CurrentStep].gameObject.SetActive(false);
            CurrentStep++;

            if (!OutOfBounds())
            {
                StartStep(CurrentStep);
            }
        }
    }

    void StartStep(int StepIndex)
    {
        OnDisplay.Invoke(StepList[StepIndex].Description);
        StepList[StepIndex].OnStart.Invoke(true);
        StepList[StepIndex].gameObject.SetActive(true);
    }




    bool OutOfBounds()
    {
        return CurrentStep < 0 || CurrentStep >= StepList.Count;
    }

}
