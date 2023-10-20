using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonPlatform : MonoBehaviour
{
    public Piston pistonA;
    public Piston pistonB;
    public Platform platform;
    public float timeToReturn;
    private void Start() {
        platform.SetTarget(pistonB.targetPos);
    }
    public void ChangePiston(){
        if(platform.CanGoUp){
            if(pistonA.GetActivated){
                pistonA.SetDeactivated();
                pistonB.SetActivated();
                platform.SetTarget(pistonB.targetPos);
                StopCoroutine("WaitForReturn");
            }
            else{
                pistonA.SetActivated();
                pistonB.SetDeactivated();
                platform.SetTarget(pistonA.targetPos);
                if(timeToReturn > -1)
                    StartCoroutine("WaitForReturn", timeToReturn);
            }
        }
        else{
            pistonA.hitted = false;
            pistonB.hitted = false;
        }
    }
    private void Update() {
        if(pistonA.hitted || pistonB.hitted){
            ChangePiston();
        }
    }
    public IEnumerator WaitForReturn(float secs){
        yield return new WaitForSeconds(secs);
        if(pistonA.GetActivated)
            ChangePiston();
    }
}
