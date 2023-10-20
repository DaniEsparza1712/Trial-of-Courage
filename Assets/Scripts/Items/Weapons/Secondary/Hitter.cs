using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitter : MonoBehaviour
{
    public SecondaryWeaponManager weaponManager;
    public AudioManager audioManager;
    public ItemData itemData;
    public int audioInt;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy")){
            if(!other.GetComponent<StateMachine>().GetInvincible){
                audioManager.PlayAudioAtPoint(audioInt);
                Vector3 sparkDir = (other.transform.position - transform.position).normalized;
                Vector3 sparkPos = transform.position + sparkDir * 0.5f;
                Instantiate(itemData.secondaryWeapon.helperGameObject, sparkPos, itemData.secondaryWeapon.helperGameObject.transform.rotation);
                other.GetComponent<LifeSystem>().ApplyDamage(0);
                other.GetComponent<StateMachine>().ChangeTo("Dizzy");
            }
        }
        else if(other.CompareTag("Piston")){
            Vector3 sparkDir = (other.transform.position - transform.position).normalized;
            Vector3 sparkPos = transform.position + sparkDir * 0.5f;
            Instantiate(itemData.secondaryWeapon.helperGameObject, sparkPos, itemData.secondaryWeapon.helperGameObject.transform.rotation);
            other.GetComponent<Piston>().hitted = true;
        }
    }
}
