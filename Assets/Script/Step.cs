using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class StepEvent : UnityEvent<bool> { }


public class Step : MonoBehaviour
{
    [TextArea]
    public string Description;
    public string TargetKey;

    public StepEvent OnStart;
    public StepEvent OnComplete;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
