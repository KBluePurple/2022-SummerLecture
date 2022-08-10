using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public PlantDataSO PlantInfo;

    private void Start()
    {
        PlantInfo.SetRandomName();
        PlantInfo.SetRandomThreat();
    }
}
