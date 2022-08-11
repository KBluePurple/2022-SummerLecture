// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class RaderObject
// {
//     public Image icon { get; set; }
//     public GameObject owner { get; set; }
// }

// public class Rader : MonoBehaviour
// {
//     public Transform player;
//     public static List<RaderObject> objects = new List<RaderObject>();
//     private const float MAP_SCALE = 2.0f;

//     private void Update()
//     {
//         DrawRaderDots();
//     }

//     public void ItemDropped(GameObject obj)
//     {
//         RegisterRenderObject(obj, obj.GetComponent<Image>());
//     }

//     private static void RegisterRenderObject(GameObject obj, Image image)
//     {
//         Image icon = Instantiate(image);
//         objects.Add(new RaderObject() { icon = icon, owner = obj });
//     }

//     private void DrawRaderDots()
//     {
//         foreach (var obj in objects)
//         {
//             Vector3 raderPos = obj.owner.transform.position - player.position;

//             float distToObject = Vector3.Distance(player.position, obj.owner.transform.position) * MAP_SCALE;
//             float deltaY = Mathf.Atan2(raderPos.x, raderPos.z) * Mathf.Rad2Deg - 270 - player.eulerAngles.y;

//             raderPos.x = distToObject * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
//             raderPos.z = distToObject * Mathf.Sin(deltaY * Mathf.Deg2Rad);

//             obj.icon.transform.SetParent(transform);
//             RectTransform rt = transform as RectTransform;

//             obj.icon.transform.position = new Vector3(raderPos.x + rt.sizeDelta.x, raderPos.z + rt.sizeDelta.y, 0);
//             // Vector2 playerPos = new (player.position.x, player.position.z);
//             // Vector2 ownerPos = new (obj.owner.transform.position.x, obj.owner.transform.position.z);

//             // Vector2 v2 = ownerPos - playerPos;
//             // float angle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;

//             // float distance = Vector2.Distance(playerPos, ownerPos) * MAP_SCALE;

//             // Vector2 position = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

//             // var rt = transform as RectTransform;
//             // obj.icon.transform.position = new Vector3(position.x + rt.pivot.x, position.y + rt.pivot.y, 0) + rt.position;
//         }
//     }
// }
