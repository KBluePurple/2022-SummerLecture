using UnityEngine;

[CreateAssetMenu(fileName = "PlantDataSO", menuName = "")]
public class PlantDataSO : ScriptableObject
{
    public enum eThreat
    {
        None,
        Low,
        Medium,
        High
    }

    [SerializeField] string _plantName;
    [SerializeField] eThreat _plantThreat;
    [SerializeField] Texture _icon;

    public string Name => _plantName;
    public eThreat Threat => _plantThreat;
    public Texture Icon => _icon;

    public void SetRandomName()
    {
        _plantName = Utills.GetRandomName(Random.Range(4, 10));
    }

    public void SetRandomThreat()
    {
        _plantThreat = Utills.GetRandomEnum<eThreat>();
    }
}