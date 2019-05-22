
using UnityEngine;
using System.Collections;

public class HiderInTime : MonoBehaviour
{
    public Animator anim;
    IEnumerator ExecuteAfterTime(float time)
    {
        anim.SetTrigger("swordToIdleTrigger");
        yield return new WaitForSeconds(time);

        GetComponent<WeaponHide>().turned = false;

        GetComponent<SkinnedMeshRenderer>().enabled = false;
    }

    public void hide(float t)
    {
        Debug.Log("hide");
        StartCoroutine(ExecuteAfterTime(t));
    }

    public void restore()
    {
        GetComponent<WeaponHide>().turned = true;
    }
}
