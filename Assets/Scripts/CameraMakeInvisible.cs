using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMakeInvisible : MonoBehaviour
{
    public float translucentDistance;
    RaycastHit hit;
    Vector3 direction;
    public Transform target;
    GameObject obstruction;
    GameObject newObstruction;
    Material obstructionMaterial;
    Material newObstructionMaterial;
    List<Material> materialsOnCoroutine = new List<Material>();
    private void Start() {

    }
    // Update is called once per frame
    void Update()
    {
        direction = target.position - transform.position;
        if(Physics.Raycast(transform.position, direction.normalized, out hit, translucentDistance)){
            newObstruction = hit.transform.gameObject;
            if(!newObstruction.CompareTag("Player")){
                newObstructionMaterial = newObstruction.GetComponentInChildren<Renderer>().material;
                //StartCoroutine(LerpTransparecy(0.4f, newObstructionMaterial));
                Color color = newObstructionMaterial.GetColor("_BaseColor");
                newObstructionMaterial.SetColor("_BaseColor", new Color(color.r, color.g, color.b, 0.4f));
            }
            if(obstruction != newObstruction){
                if(obstruction != null && !obstruction.CompareTag("Player")){
                    obstructionMaterial = obstruction.GetComponentInChildren<Renderer>().material;
                    //StartCoroutine(LerpTransparecy(1, obstructionMaterial));
                    Color color = newObstructionMaterial.GetColor("_BaseColor");
                    newObstructionMaterial.SetColor("_BaseColor", new Color(color.r, color.g, color.b, 1f));
                }
            }
            obstruction = hit.transform.gameObject;
        }
    }

    IEnumerator LerpTransparecy(float alphaDest, Material objMaterial){
        while(materialsOnCoroutine.Contains(objMaterial)){
            yield return null;
        }
        materialsOnCoroutine.Add(objMaterial);

        Material material = objMaterial;
        Color color = material.GetColor("_BaseColor");
        float startAlpha = color.a;
        float alphaLerp = 0;

        while(material.GetColor("_BaseColor").a != alphaDest){
            float alpha = Mathf.Lerp(startAlpha, alphaDest, alphaLerp);
            material.SetColor("_BaseColor",new Color(color.r, color.g, color.b, alpha));
            alphaLerp += 0.1f;
            yield return null;
        }
        
        materialsOnCoroutine.Remove(objMaterial);
    }
    private void OnDrawGizmos() {
        Vector3 direction = target.transform.position - transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction);
    }
}
