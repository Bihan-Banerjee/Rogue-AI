using UnityEngine;
public class GridManager : MonoBehaviour
{
    public int width = 8, height = 8;
    public GameObject tilePrefab, agentPrefab, enemyPrefab, rewardPrefab;
    [HideInInspector] public Vector2Int agentPos, rewardPos, enemyPos;
    GameObject agent, reward, enemy;

    void Start()
    {
        GenerateGrid();
        SpawnObjects();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
    }

    void SpawnObjects()
    {
        agentPos = GetRandomPos();
        agent = Instantiate(agentPrefab, new Vector3(agentPos.x, agentPos.y, 0), Quaternion.identity);

        rewardPos = GetRandomFreePos(agentPos);
        reward = Instantiate(rewardPrefab, new Vector3(rewardPos.x, rewardPos.y, 0), Quaternion.identity);

        enemyPos = GetRandomFreePos(agentPos, rewardPos);
        enemy = Instantiate(enemyPrefab, new Vector3(enemyPos.x, enemyPos.y, 0), Quaternion.identity);
    }

    Vector2Int GetRandomPos()
    {
        return new Vector2Int(Random.Range(0, width), Random.Range(0, height));
    }
    Vector2Int GetRandomFreePos(params Vector2Int[] taken)
    {
        Vector2Int pos;
        do { pos = GetRandomPos(); }
        while (System.Array.Exists(taken, t => t == pos));
        return pos;
    }
}
