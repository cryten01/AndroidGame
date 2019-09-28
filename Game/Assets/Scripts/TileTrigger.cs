using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    private TileManager tileManager;
    private void Start()
    {
        tileManager = GameObject.FindObjectOfType<TileManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited tile");
            tileManager.SpawnTile();
            tileManager.DeleteTile();
            tileManager.ChangeActiveTile();
        }
    }
}
