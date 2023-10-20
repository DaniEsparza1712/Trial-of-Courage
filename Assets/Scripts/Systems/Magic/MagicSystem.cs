using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicSystem : MonoBehaviour
{
    public float totalMagic = 200;
    public float magic = 200;
    public Image image;

    void Update()
    {
        magic = (magic < 0)? 0 : magic;
        magic = (magic > totalMagic)? totalMagic: magic;

        image.fillAmount = Mathf.Lerp(image.fillAmount, magic / totalMagic, 10 * Time.unscaledDeltaTime);
    }

    public void DecreaseMagic(int magicPoints)
    {
        if(magic > 0)
            magic -= magicPoints;
    }
    public void AddMagic(int magicPoints){
        magic += magicPoints;
    }
}
