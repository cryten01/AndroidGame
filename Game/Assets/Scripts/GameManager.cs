using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool ballMode = false;
    public GameObject activeObject;

    public Material activeMaterial;
    public Material environmentMaterial;

    public TextMeshProUGUI WinText;
    public TextMeshProUGUI LoseText;

    public bool isWon;
    public bool isLost;
    public float restartDelay = 1.0f;
    
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

    // Changes the material of the gameobject
    public void changeMaterial(GameObject target)
    {
        activeObject.GetComponent<Renderer>().material = environmentMaterial;
        
        // Gets transforms of all childs   
        Transform[] children = target.GetComponentsInChildren<Transform>();

        foreach (Transform t in children)
        {
            if (t.CompareTag("Environment"))
            {
                Renderer rend = t.GetComponent<Renderer>();
                rend.material = activeMaterial;
            }
        }
    }


    public void CompleteLevel()
    {
        Debug.Log("LEVEL WON!");
        WinText.gameObject.SetActive(true);
        Invoke("RestartLevel", restartDelay);
    }

    // Gets called when game is won
    public void GameOver()
    {
        if (!isLost)
        {
            isLost = true;
            Debug.Log("GAME OVER!");
            LoseText.gameObject.SetActive(true);
            Invoke("RestartLevel", restartDelay);
        }
    }

    // Restarts the scene
    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}