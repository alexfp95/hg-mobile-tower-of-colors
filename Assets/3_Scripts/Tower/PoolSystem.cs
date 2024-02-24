using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoolSystem : MonoBehaviour
{

    public static PoolSystem Instance;

    [SerializeField] private TowerTile tilePrefab;
    [SerializeField] private TowerTile[] specialTilePrefabs;
 
    private TilePool tilePool;
    private TilePool[] specialsTilePool;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        tilePool = new TilePool();
        if (specialTilePrefabs == null)
        {
            return;
        }
        specialsTilePool = new TilePool[specialTilePrefabs.Length];
        for (int i = 0; i < specialsTilePool.Length; i++)
        {
            specialsTilePool[i] = new TilePool();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unload in use pools
        if (tilePool != null)
        {
            UnloadInUsePool(tilePool);
        }
        if (specialsTilePool != null)
        {
            for (int i = 0; i < specialsTilePool.Length; i++)
            {
                UnloadInUsePool(specialsTilePool[i]);
            }
        }
    }

    private void UnloadInUsePool(TilePool pool)
    {
        for (int i = 0; i < pool.InUse.Count; i++)
        {
            pool.InUse[i].OnTileDestroyed = null;
            pool.InUse[i].gameObject.SetActive(false);
            pool.Available.Add(pool.InUse[i]);
        }
        pool.InUse.Clear();
    }

    public int GetSpecialTilesCount()
    {
        return specialTilePrefabs != null ? specialTilePrefabs.Length : 0;
    }

    public Quaternion GetTilePrefabRotation()
    {
        return tilePrefab.transform.rotation;
    }

    public TowerTile GetTile()
    {
        return HandlePoolGet(tilePrefab, tilePool);
    }

    public TowerTile GetSpecialTile(int index)
    {
        if (specialTilePrefabs == null || index >= specialTilePrefabs.Length)
        {
            Debug.LogError("Invalid use of special tiles in pooling system.");
            return null;
        }
        return HandlePoolGet(specialTilePrefabs[index], specialsTilePool[index]);
    }

    private TowerTile HandlePoolGet(TowerTile prefabType, TilePool pool)
    {
        TowerTile tile;
        if (pool.Available.Count > 0)
        {
            // Existing available tile
            tile = pool.Available[0];
            pool.Available.RemoveAt(0);
        }
        else
        {
            // Instantiate new tile for the pool
            tile = Instantiate(prefabType, transform);
            tile.OwnerPool = pool;
        }
        pool.InUse.Add(tile);
        tile.gameObject.SetActive(true);
        return tile;
    }

    public void DisposeTile(TowerTile tile, TilePool tilePool)
    {
        if (!tilePool.InUse.Contains(tile))
        {
            Debug.LogError("Tile not found in selected pool");
            return;
        }
        tilePool.InUse.Remove(tile);
        tilePool.Available.Add(tile);
        tile.gameObject.SetActive(false);
    }

    public class TilePool
    {
        public List<TowerTile> Available = new List<TowerTile>();
        public List<TowerTile> InUse = new List<TowerTile>();
    }
}
