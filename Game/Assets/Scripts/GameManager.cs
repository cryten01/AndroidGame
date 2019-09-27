using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool ballMode = false;
    public GameObject LastGO;// currently controlled gameObject
    public GameObject ActiveGO;
    
    public Material activeMaterial;
    public Material environmentMaterial;
    public Button ballModeButton;

    public TextMeshProUGUI WinText;
    public TextMeshProUGUI LoseText;

    public bool isWon;
    public bool isLost;
    public float restartDelay = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        updateActiveGO();
    }
    
    // Switches between game mode between player and platform
    public void switchBallMode()
    {
        ballMode = !ballMode;
        Debug.Log("Ballmode: " + ballMode);
    }

    // Updates activeGO
    public void updateActiveGO()
    {        
        if (ballMode)
        {
            LastGO = GameObject.Find("Platform");
            ActiveGO = GameObject.Find("Player");
            ballModeButton.GetComponentInChildren<Text>().text = "Switch to platform";
        }
        else
        {
            LastGO = GameObject.Find("Player");
            ActiveGO = GameObject.Find("Platform");
            ballModeButton.GetComponentInChildren<Text>().text = "Switch to ball";
        }
        
        // Resets lastGO material to environmentMaterial
        setGOMaterial(LastGO, environmentMaterial);
        
        // Sets activeGO material to activeMaterial
        setGOMaterial(ActiveGO, activeMaterial);
    }

    // Changes the material of the gameobject and all of its children
    public void setGOMaterial(GameObject target, Material material)
    {
        target.GetComponent<Renderer>().material = material;
       
        // Gets all child transforms from activeGO 
        Transform[] children = target.GetComponentsInChildren<Transform>();

        foreach (Transform t in children)
        {
            // Checks if transform is part of activeGO
            if (t.CompareTag("Environment"))
            {
                Renderer rend = t.GetComponent<Renderer>();
                rend.material = material;
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