using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPlant : MonoBehaviour
{
    [SerializeField] SetPlantInfo setPlantInfo;
    [SerializeField] Text _nameText;
    [SerializeField] Text _threatText;
    [SerializeField] RawImage _iconImage;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Plant")
                {
                    setPlantInfo.OpenPlantPanel();
                    _nameText.text = hit.transform.GetComponent<Plant>().PlantInfo.Name;
                    _threatText.text = hit.transform.GetComponent<Plant>().PlantInfo.Threat.ToString();
                    _iconImage.texture = hit.transform.GetComponent<Plant>().PlantInfo.Icon;
                }
                else
                {
                    setPlantInfo.ClosePlantPanel();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Plant")
        {
            if (other.transform.GetComponent<Plant>().PlantInfo.Threat >= PlantDataSO.eThreat.Medium)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 50, ForceMode.Impulse);
                animator.Play("Standing React Death Backward");
            }
        }
    }
}
