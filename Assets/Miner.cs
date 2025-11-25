using UnityEngine;
using UnityEngine.UI;

// TODO: miner관리하는 클래스를 따로 만들어야 하려나
public class Miner : MonoBehaviour
{
    [SerializeField] private float mineSpeed = 0.1f;
    [SerializeField] private Slider slider;

    private float mineProgress;
    private OreData[] currentFloorOres;

    private void Update()
    {
        Mine();
        UpdateProgressBar();
    }


    private void Mine()
    {
        mineProgress += mineSpeed * Time.deltaTime;
        if (mineProgress >= 1f)
        {
            GetOre();  
            mineProgress = 0f;
        }

    }

    // 일단 랜덤
    private void GetOre()
    {
       
    }

    public void UpdateProgressBar()
    {
        slider.value = mineProgress;
    }
}
