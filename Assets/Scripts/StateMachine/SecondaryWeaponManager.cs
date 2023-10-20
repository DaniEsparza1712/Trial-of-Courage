using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryWeaponManager : MonoBehaviour
{
    public GameObject weaponHolder;
    public ItemData secondaryWeaponData;
    public ItemData secondaryWeaponDataB;
    private ItemData currentWeaponData;
    public Collider weaponCollider;
    public Transform castTransform;
    public Dictionary<string, GameObject> weapons = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in weaponHolder.transform){
            if(child.gameObject.CompareTag("Weapon")){
                weapons.Add(child.gameObject.name, child.gameObject);
                child.gameObject.SetActive(false);
            }
        }
        weaponHolder.SetActive(false);
    }

    public void ChangeActiveWeapon(){
        foreach(Transform child in weaponHolder.transform){
            if(child.gameObject.CompareTag("Weapon")){
                child.gameObject.SetActive(false);
            }
        }
        if(weapons.ContainsKey(secondaryWeaponData.itemName)){
            weapons[secondaryWeaponData.itemName].SetActive(true);
        }
        currentWeaponData = secondaryWeaponData;
    }

    public void ChangeActiveWeaponB(){
        foreach(Transform child in weaponHolder.transform){
            if(child.gameObject.CompareTag("Weapon")){
                child.gameObject.SetActive(false);
            }
        }
        if(weapons.ContainsKey(secondaryWeaponDataB.itemName)){
            weapons[secondaryWeaponDataB.itemName].SetActive(true);
        }
        currentWeaponData = secondaryWeaponDataB;
    }

    public void SecondaryAction(){
        MagicSystem magicSystem = GameObject.Find("Player").GetComponent<MagicSystem>();
        if(currentWeaponData.secondaryWeapon.secondaryType == SecondaryWeapon.SecondaryType.spawner && SpawnManager.spawnManager.CheckIfCanSpawn(secondaryWeaponData)){
            Inventory.instance.inventorySlots[currentWeaponData.id].RemoveItem(1);
            Instantiate(currentWeaponData.secondaryWeapon.helperGameObject, transform.position, currentWeaponData.secondaryWeapon.helperGameObject.transform.rotation);
        }
        else if(currentWeaponData.secondaryWeapon.secondaryType == SecondaryWeapon.SecondaryType.hitter){
            GetComponentInChildren<Hitter>().itemData = currentWeaponData;
            weaponCollider.enabled = true;
        }
        else if(currentWeaponData.secondaryWeapon.secondaryType == SecondaryWeapon.SecondaryType.caster){
            if(magicSystem.magic > 0){
                Instantiate(currentWeaponData.secondaryWeapon.helperGameObject, castTransform.position, transform.rotation);
                magicSystem.DecreaseMagic(currentWeaponData.value);
            }
        }
    }
    public void SecondaryActionFollowup(){
        if(currentWeaponData.secondaryWeapon.secondaryType == SecondaryWeapon.SecondaryType.hitter){
            weaponCollider.enabled = false;
        }
    }
}
