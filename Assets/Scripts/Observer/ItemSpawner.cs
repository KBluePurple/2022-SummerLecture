using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject EggPrefab;
    public GameObject MedkitPrefab;

    public Terrain terrain;

    TerrainData terrainData;


    public enum ItemPrefabs
    {
        Egg,
        Medkit,
    }

    private Dictionary<ItemPrefabs, GameObject> itemPrefabs = new ();

    private void Awake()
    {
        itemPrefabs.Add(ItemPrefabs.Egg, EggPrefab);
        itemPrefabs.Add(ItemPrefabs.Medkit, MedkitPrefab);
    }

    private void Start()
    {
        terrainData = terrain.terrainData;

        InvokeRepeating("CreateEgg", 1, 1);
    }

    private void CreateEgg()
    {
        SelectItemPrefab(ItemPrefabs.Egg);
    }

    private void SelectItemPrefab(ItemPrefabs itemPrefab)
    {
        GameObject item = itemPrefabs[itemPrefab];
        Vector3 spawnPosition = new Vector3(Random.Range(0, terrainData.size.x), 0, Random.Range(0, terrainData.size.z));
        spawnPosition.y = terrain.SampleHeight(spawnPosition) + 10;
        var itemObj = Instantiate(item, spawnPosition, Quaternion.identity);
        itemObj.transform.SetParent(transform);
    }
}
