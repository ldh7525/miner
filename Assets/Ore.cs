using DG.Tweening;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private OreData oreData;

    private float mineTimer { get; set; }

    private int health;

    public void Init(OreData data)
    {
        // TODO:
        oreData = data;
        spriteRenderer.sprite = oreData.sprite;
        health = data.oreHealth;
    }

    private void Update()
    {
        if (mineTimer > 0)
            mineTimer -= Time.deltaTime;
    }

    public void TryMine(float cooldown)
    {
        if (mineTimer > 0)
        {
            return;
        }
        else
        {
            print("캔다");
            mineTimer = cooldown;
            health--;

            Sequence sequence = DOTween.Sequence();
            Color originalColor = spriteRenderer.color;
            sequence.Append(spriteRenderer.DOColor(Color.red, 0.1f));  // 0.1초 동안 빨간색으로 변경
            sequence.Append(spriteRenderer.DOColor(originalColor, 0.1f)); // 다시 원래 색상으로 복귀


            if (health <= 0)
            {
                DropItem();
            }
        }
    }

    private void DropItem()
    {
        GameManager.Instance.inventory.AddItem(oreData, 1);
        OreGenerator.Instance.oreList.Remove(this);
        Destroy(gameObject);
    }

}

