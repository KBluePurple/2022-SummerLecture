using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaderObject
{
    public Image icon { get; set; }
    public GameObject owner { get; set; }
}

public class Radar : MonoBehaviour
{
    [SerializeField] Text getText;
    public Transform player;
    public static Dictionary<GameObject, RaderObject> objects = new Dictionary<GameObject, RaderObject>();
    private const float MAP_SCALE = 2.0f;

    private void Update()
    {
        DrawRaderDots();
    }

    public void ItemDropped(GameObject obj)
    {
        RegisterRenderObject(obj, obj.GetComponent<Item>().icon);
    }

    private static void RegisterRenderObject(GameObject obj, Image image)
    {
        Image icon = Instantiate(image);
        objects.Add(obj, new RaderObject() { icon = icon, owner = obj });
    }

    private void DrawRaderDots()
    {
        foreach (var obj in objects)
        {
            Vector3 radarPos = (obj.Value.owner.transform.position - player.position);

            float distToObject = Vector3.Distance(player.position, obj.Value.owner.transform.position) * MAP_SCALE;
            float deltaY = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - player.eulerAngles.y;

            radarPos.x = distToObject * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
            radarPos.z = distToObject * Mathf.Sin(deltaY * Mathf.Deg2Rad);

            // 레이더에 표시를 해보자
            obj.Value.icon.transform.SetParent(this.transform);
            RectTransform rt = this.GetComponent<RectTransform>();
            Debug.Log(rt.pivot);

            obj.Value.icon.transform.position = new Vector3(radarPos.x + rt.pivot.x, radarPos.z + rt.pivot.y, 0) + this.transform.position;

            // Vector2 playerPos = new (player.position.x, player.position.z);
            // Vector2 ownerPos = new (obj.owner.transform.position.x, obj.owner.transform.position.z);

            // Vector2 v2 = ownerPos - playerPos;
            // float angle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;

            // float distance = Vector2.Distance(playerPos, ownerPos) * MAP_SCALE;

            // Vector2 position = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

            // var rt = transform as RectTransform;
            // obj.icon.transform.position = new Vector3(position.x + rt.pivot.x, position.y + rt.pivot.y, 0) + rt.position;
        }
    }

    public void OnPickup(GameObject obj)
    {
        StartCoroutine(GetItem(obj));
    }

    IEnumerator GetItem(GameObject obj)
    {
        Destroy(objects[obj].icon.gameObject);
        objects.Remove(obj);
        Destroy(obj);
        getText.text = "+ R을 흭득하셨습니다.";
        yield return new WaitForSeconds(3);
        getText.text = "";
    }
}
