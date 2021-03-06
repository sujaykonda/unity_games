﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    float lim = float.PositiveInfinity; 
    float startLim = float.NegativeInfinity;
    float startNext = float.NegativeInfinity;
    float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed = speed*0.85f;
        if(Input.GetKey(KeyCode.UpArrow)){
            speed = 0.4f;
            if(Input.GetKey(KeyCode.LeftShift)){
                speed = 1f;
            }

        }
        if(Input.GetKey(KeyCode.DownArrow)){
            speed = -0.5f;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)&& Time.time>startNext){
            if(anim.GetCurrentAnimatorStateInfo(0).IsTag("swordHide")){
                anim.SetTrigger("swordTurnRightTrigger");
            }
            else{
                anim.SetTrigger("turnRightTrigger");
            }
            startNext = Time.time+1f;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)&& Time.time>startNext){
            if(anim.GetCurrentAnimatorStateInfo(0).IsTag("swordHide")){
                anim.SetTrigger("swordTurnLeftTrigger");
            }
            else{
                anim.SetTrigger("turnLeftTrigger");
            }
            startNext = Time.time+1f;
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("swordHide")){
            anim.SetFloat("swordWalkSelect", speed);
        }
        else{
            anim.SetFloat("walkSelect", speed);
        }
        if(Input.GetKeyDown(KeyCode.Z)&& Time.time>startNext){
            if(anim.GetCurrentAnimatorStateInfo(0).IsTag("swordHide")){
                if(Time.time<lim&&startLim<Time.time){
                    anim.SetInteger("swordStrikeSelect",1);
                    anim.SetTrigger("swordStrikeTrigger");
                }
                
            }
            else{
                anim.SetTrigger("idleToSwordTrigger");
                lim = Time.time+7f;
                startLim = Time.time+1f;
            }
            startNext = Time.time+1f;
        }
        if(Input.GetKeyDown(KeyCode.X)&& Time.time>startNext){
            if(anim.GetCurrentAnimatorStateInfo(0).IsTag("swordHide")){
                if(Time.time<lim&&startLim<Time.time){
                    anim.SetInteger("swordStrikeSelect",4);
                    anim.SetTrigger("swordStrikeTrigger");
                }
                
            }
            else{
                anim.SetTrigger("idleToSwordTrigger");
                lim = Time.time+7f;
                startLim = Time.time+1f;
            }
            startNext = Time.time+1.7f;
        }
        if(Input.GetKeyDown(KeyCode.C)&& Time.time>startNext){
            if(anim.GetCurrentAnimatorStateInfo(0).IsTag("swordHide")){
                if(Time.time<lim&&startLim<Time.time){
                    anim.SetInteger("swordStrikeSelect",7);
                    anim.SetTrigger("swordStrikeTrigger");
                }
                
            }
            else{
                anim.SetTrigger("idleToSwordTrigger");
                lim = Time.time+7f;
                startLim = Time.time+1f;
            }
            startNext = Time.time+1.4f;
        }
        
        

        if(Time.time >= lim&& Time.time>startNext){
            anim.SetTrigger("swordToIdleTrigger");
        }
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        if(Input.GetKey(KeyCode.Space)){
            anim.SetTrigger("JumpTrigger");
            
        }
    }
}
