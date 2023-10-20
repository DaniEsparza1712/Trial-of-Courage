using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeSystem : MonoBehaviour
{
    public float totalLife = 200;
    public float life = 200;
    public Image image;
    public ParticleSystem disappearParticles;

    void Update()
    {
        life = (life < 0)? 0 : life;
        life = (life > totalLife)? totalLife: life;
        
        if(image != null)
            image.fillAmount = Mathf.Lerp(image.fillAmount, life / totalLife, 10 * Time.unscaledDeltaTime);
    }

    public void ApplyDamage(int damage)
    {
        if(life > 0)
            life -= damage;
    }
    public void AddLife(int points){
        life += points;
    }
    public void InstantiateDisappearParticles(){
        Instantiate(disappearParticles, transform.position, disappearParticles.transform.rotation);
    }
}
