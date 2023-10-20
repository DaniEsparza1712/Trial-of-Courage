using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KissManager : MonoBehaviour
{
    public GameObject cloak;
    public GameObject body;
    public GameObject root;
    public GameObject bot;
    public ParticleSystem hearts;
    public Transform heartsPosition;

    public void ChangeToKiss(){
        cloak.SetActive(false);
        body.SetActive(false);
        root.SetActive(false);

        bot.SetActive(true);
    }

    public void ChangeToPlayer(){
        cloak.SetActive(true);
        body.SetActive(true);
        root.SetActive(true);

        bot.SetActive(false);
    }

    public void PlayHearts(){
        Instantiate(hearts, heartsPosition);
    }
}
