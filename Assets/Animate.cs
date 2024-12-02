using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator PlayerAnimator;
    void Awake() {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Horizontal") < -0.1f){
            float value;
            value = Input.GetAxis("Horizontal");
            if (Input.GetAxis("Horizontal") < -0.1f) {
                value = Input.GetAxis("Horizontal") * -1f;
            }
            PlayerAnimator.SetFloat("walk", value);
        } else if (Input.GetAxis("Vertical") > 0.1f || Input.GetAxis("Vertical") < -0.1f){
            PlayerAnimator.SetFloat("walk", Input.GetAxis("Vertical"));
        } else {
            PlayerAnimator.SetFloat("walk", 0f);
        }
    }
}