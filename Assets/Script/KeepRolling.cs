using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRolling : MonoBehaviour
{
    public VRTK.Controllables.ArtificialBased.VRTK_ArtificialRotator Rotator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rotator == null)
            return;
        //Debug.LogError(">>>> " + Rotator.GetValue().ToString());
        float CurrentAngle = Rotator.GetValue();
        if (CurrentAngle >= 180)
            Rotator.SetValue(CurrentAngle - 360);
        else if (CurrentAngle <= -180)
            Rotator.SetValue(CurrentAngle + 360);
        
    }
}
