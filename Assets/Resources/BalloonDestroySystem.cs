using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class BalloonDestroySystem : ReactiveSystem<GameEntity>
{
    Contexts context;
    public BalloonDestroySystem(Contexts contexts) : base(contexts.game)
    {
        this.context = contexts;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            UnityEngine.MonoBehaviour.Destroy(entity.balloonGameObject.ballonGO);
            entity.RemoveAllComponents();
            entity.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return  entity.isBalloonPopped;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BalloonPopped);
    }
}
