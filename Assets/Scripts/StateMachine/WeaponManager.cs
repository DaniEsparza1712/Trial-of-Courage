using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;
    public Collider swordCollider;
    public Collider swordColliderB;
    public GameObject weaponHolder;
    public Dictionary<string, GameObject> weapons = new Dictionary<string, GameObject>();
    private void Start() {
        foreach(Transform child in weaponHolder.transform){
            if(child.gameObject.CompareTag("Weapon")){
                weapons.Add(child.gameObject.name, child.gameObject);
                child.gameObject.SetActive(false);
            }
        }
    }
    public void ChangeColliderStatus(int value){
        switch(value){
            case 1: 
                swordCollider.enabled = true;
                break;
            case 2: 
                swordCollider.enabled = false;
                break;
        }
    }
    public void ChangeColliderBStatus(int value){
        switch(value){
            case 1: 
                swordColliderB.enabled = true;
                break;
            case 2: 
                swordColliderB.enabled = false;
                break;
        }
    }
    public void ChangeActiveWeapon(string weaponName){
        foreach(Transform child in weaponHolder.transform){
            if(child.gameObject.CompareTag("Weapon")){
                child.gameObject.SetActive(false);
            }
        }
        weapons[weaponName].SetActive(true);
    }
}
