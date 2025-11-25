using System.Collections.Generic;
using UnityEngine;

public class PlayerMine : MonoBehaviour
{
    [SerializeField] private float mineRange;
    [SerializeField] private float mineInterval = 0.5f;

    private List<Ore> FieldOreList => OreGenerator.Instance.oreList;

    private void Update()
    {
        MineNearbyOre();
    }

    private void MineNearbyOre()
    {
        for (int i = FieldOreList.Count - 1; i >= 0; i--)
        {
            float distance = Vector3.Distance(transform.position, FieldOreList[i].transform.position);
            if (distance <= mineRange)
            {
                FieldOreList[i].TryMine(mineInterval);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, mineRange);
    }
}
