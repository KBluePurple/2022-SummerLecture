using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class PerlinPosisionProxy : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new PerlinPosision());
    }
}
