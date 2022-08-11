using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class SpawnerSystem : SystemBase
{
    EndFixedStepSimulationEntityCommandBufferSystem _entityCommandBufferSystem;

    protected override void OnCreate()
    {
        _entityCommandBufferSystem = World.GetOrCreateSystem<EndFixedStepSimulationEntityCommandBufferSystem>();
    }

    partial struct SpawnJob : IJobEntity
    {
        public EntityCommandBuffer CommandBuffer;
        public Entity Prefab;
        public int Erows;
        public int Ecols;

        public void Execute(Entity entity, [EntityInQueryIndex] int index, [ReadOnly] ref Spawner spawner, [ReadOnly] ref LocalToWorld location)
        {
            for (int x = 0; x < spawner.Erows; x++)
            {
                for (int z = 0; z < spawner.Ecols; z++)
                {
                    var instance = CommandBuffer.Instantiate(spawner.Prefab);
                    var postion = math.transform(location.Value, new float3(x, noise.cnoise(new float2(x, z) * 0.21f), z));
                    CommandBuffer.SetComponent(instance, new Translation { Value = postion });
                }
            }
        }
    }

    protected override void OnUpdate()
    {
        var job = new SpawnJob
        {
            CommandBuffer = _entityCommandBufferSystem.CreateCommandBuffer(),
        };

        Dependency = job.Schedule(Dependency);
        _entityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
