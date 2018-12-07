using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActivator : MonoBehaviour {


    public string AnimationName;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void CallThisFromButton()
    {
        anim.Play(AnimationName);
    }
}
