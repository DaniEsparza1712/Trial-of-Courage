using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDoor : MonoBehaviour
{
    public List<BoxButton> boxButtons = new List<BoxButton>();
    private bool opened;
    Vector3 startRotation;
    public AudioManager audioManager;
    private void Start() {
        startRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(!opened && OpenDoor()){
            StartCoroutine("RotateDoor");
        }
    }
    bool OpenDoor(){
        foreach(BoxButton boxButton in boxButtons){
            if(!boxButton.Activated && !opened){
                return false;
            }
        }
        return true;
    }
    IEnumerator RotateDoor(){
        audioManager.PlayAudioFromSource(0);
        Score.instance.AddScore(150);
        opened = true;
        while(transform.eulerAngles.y < startRotation.y + 90){
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, startRotation.y + 90, 0), 1 * Time.deltaTime);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, startRotation.y + 90, 0);
        yield return null;
    }
}
