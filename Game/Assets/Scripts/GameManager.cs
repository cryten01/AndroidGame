using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool platformMode = true;
    public GameObject activeObject;

    public Material activeMaterial;
    public Material environmentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        changeMaterial( GameObject.Find("Platform"));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void controlObjectTest()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject.Find("PlayerBall").GetComponent<MeshRenderer>().material = activeMaterial;
            GameObject.Find("Boundary S").GetComponent<MeshRenderer>().material = environmentMaterial;
            
        }
        else
        {
            GameObject.Find("PlayerBall").GetComponent<MeshRenderer>().material = environmentMaterial;
            GameObject.Find("Boundary S").GetComponent<MeshRenderer>().material = activeMaterial;
        }
    }

    public void changeMaterial(GameObject activeGO)
    {
        activeObject.GetComponent<Renderer>().material = environmentMaterial;
        
        // Gets transforms of all childs   
        Transform[] children = activeGO.GetComponentsInChildren<Transform>();

        foreach (Transform t in children)
        {
            if (t.CompareTag("Environment"))
            {
                Renderer rend = t.GetComponent<Renderer>();
                rend.material = activeMaterial;
            }
        }
    }
}