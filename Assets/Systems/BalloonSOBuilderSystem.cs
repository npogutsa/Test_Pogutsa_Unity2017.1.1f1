using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class BalloonSOBuilderSystem : ReactiveSystem<GameEntity>
{
    public BalloonSOBuilderSystem(Contexts contexts) : base(contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        
    }

    protected override bool Filter(GameEntity entity)
    {
        return  entity.hasView && entity.hasBalloonPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BalloonPosition);
    }
}
