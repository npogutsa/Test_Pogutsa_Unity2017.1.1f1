using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
public class AddViewSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity viewEntity in entities)
        {
            //GameObject newBalloon = new GameObject("Balloon");
            //newBalloon.transform.SetParent(viewContainer, false);
            //viewEntity.AddView(newBalloon);
            //viewEntity.AddBalloonGameObject(GameObject.CreatePrimitive(PrimitiveType.Capsule));
            //newBalloon.Link(viewEntity, _context);
            
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasBalloonPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.View);
    }

    //protected override bool Filter(GameEntity entity)
    //{
    //    //return entity.hasBalloonMesh;
    //}

    //protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    //{
    //}


}
