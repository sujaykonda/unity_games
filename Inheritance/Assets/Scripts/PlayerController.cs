using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float lim = float.PositiveInfinity; 
    public float time;
    float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        speed = speed*0.85f;
        if(Input.GetKey(KeyCode.UpArrow)){
            speed = 0.5f;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            speed = -0.5f;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(0f,1f,0f,Space.Self);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(0f,-1f,0f,Space.Self);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("swordHide")){
                anim.SetFloat("swordWalkSelect", speed);
            }
            else{
                anim.SetFloat("walkSelect", speed);
            }
        if(Input.GetKeyDown(KeyCode.Z)){
            if(anim.GetCurrentAnimatorStateInfo(0).IsTag("swordHide")){
                anim.SetTrigger("swordStrikeTrigger");
            }
            else{
                anim.SetTrigger("idleToSwordTrigger");
                lim = Time.time+7f;

            }
        } 
        
        

        if(Time.time >= lim){
            anim.SetTrigger("swordToIdleTrigger");
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(Input.GetKey(KeyCode.Space)){
            anim.SetTrigger("JumpTrigger");
            
        }
    }
}
