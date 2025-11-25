using System.Collections.Generic;
using UnityEngine;

public class OreGenerator : Singleton<OreGenerator>
{
    [SerializeField] private SpriteRenderer boundSprite;
    [SerializeField] private Ore oreBase;
    [SerializeField] private OreDatabase database;

    [SerializeField] private float generateInterval = 2f;

    Vector2 minbound, maxbound;
    public readonly List<Ore> oreList = new();
    private OreData[] currentFloorOres;

    private float generateTimer = 0f;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        minbound = boundSprite.bounds.min;
        maxbound = boundSprite.bounds.max;
        UpdateOreInfo();
        GameManager.Instance.sceneTransitionManager.OnMiningTurnEnter += UpdateOreInfo;
    }

    private void UpdateOreInfo()
    {
        currentFloorOres = database.GetOreListByFloor(GameManager.Instance.floorStateManager.currentFloor);
    }

    private void Update()
    {
        generateTimer -= Time.deltaTime;
        if (generateTimer <= 0f)
        {
            generateTimer = generateInterval;
            GenerateOre();
        }
    }

    private void GenerateOre()
    {
        Vector3 targetPos = new Vector3(
            Random.Range(minbound.x, maxbound.x),
            Random.Range(minbound.y, maxbound.y),
            0f);
        OreData data = currentFloorOres[Random.Range(0, currentFloorOres.Length)];
        Ore ore = Instantiate(oreBase, targetPos, Quaternion.identity);
        ore.Init(data);
        oreList.Add(ore);
    }
}
