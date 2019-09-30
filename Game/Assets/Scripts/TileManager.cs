using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // External References
    public Material activeMaterial;
    public Material environmentMaterial;
    
    // Params
    public GameObject[] tiletypes;
    public int numberOfActiveTiles = 10;
    public int activeTileNumber = 1;


    private Vector3 spawnPoint;
    private List<GameObject> activeTiles;
    private GameObject activeTile;


    // Testing only
    private int tileCount = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        spawnPoint = new Vector3(0, 0, 0);

        // Creates the first tiles
        for (int i = 0; i < numberOfActiveTiles - 1; i++)
        {
            SpawnTile();
        }

        // Set activeTile
        activeTile = activeTiles[activeTileNumber];
    }

    
    private void Update()
    {
//          activeTile.transform.localRotation = Quaternion.Euler(0, 0, -accelerationData.xFilt * 100);
//          activeTile.transform.position += new Vector3(-accelerationData.xFilt * 1,0, 0);
    }

    
    public void SpawnTile()
    {
        if (tileCount < 41)
        {
            GameObject tile;

            if (tileCount < 40)
            {
                tile = Instantiate(tiletypes[0]);
            }
            else
            {
                tile = Instantiate(tiletypes[1]);
            }

            // Puts it into the TileManager
            tile.transform.SetParent(transform);

            // Adds to the active tiles
            activeTiles.Add(tile);

            // Updates tileCount
            tileCount++;

            // Moves it the spawnPoint
            tile.transform.position = spawnPoint;

            // Updates spawnPoint
            spawnPoint.z += tiletypes[0].transform.localScale.z;
        }

        // Sets a random rotation
        if (tileCount > 20)
        {
//            tile.transform.localRotation = Quaternion.Euler(tile.transform.localRotation.x, tile.transform.localRotation.y, Random.Range(-20.0f, 20.0f));
        }
    }


    public void DeleteTile()
    {
        // Checks number of tiles
        if (activeTiles.Count > numberOfActiveTiles)
        {
            // Destroys actual gameObject
            Destroy(activeTiles[0]);

            // Removes reference
            activeTiles.RemoveAt(0);
        }
    }


    public void ChangeActiveTile()
    {
        // Resets lastActiveTile material
        SetTileMaterial(activeTile, environmentMaterial);

        // Sets new active tile
        activeTile = activeTiles[activeTileNumber];

        // Changes material of new active tile
        SetTileMaterial(activeTile, activeMaterial);
    }


    // Changes the material of the tile and its children
    public void SetTileMaterial(GameObject target, Material material)
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
}