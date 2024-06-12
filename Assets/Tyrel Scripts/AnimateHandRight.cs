using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandRight : MonoBehaviour
{

    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    public bool shooting = false;
    float gripValue,triggerValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!shooting)
        {
            triggerValue = pinchAnimationAction.action.ReadValue<float>();
            gripValue = gripAnimationAction.action.ReadValue<float>();
        }
        else 
        {
            triggerValue = Mathf.Clamp(pinchAnimationAction.action.ReadValue<float>(), 0.2f, 0.7f);
            gripValue = 0.5f;
            
        }
        handAnimator.SetFloat("Trigger", triggerValue);
        handAnimator.SetFloat("Grip",gripValue);

    }
}
