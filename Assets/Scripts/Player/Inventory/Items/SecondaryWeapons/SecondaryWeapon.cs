using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory System/Secondary Weapon")]
public class SecondaryWeapon : ScriptableObject
{
    public enum SecondaryType{
        none,
        caster,
        hitter,
        spawner
    }
    public SecondaryType secondaryType;
    public GameObject helperGameObject;
    public string animTrigger;
}
