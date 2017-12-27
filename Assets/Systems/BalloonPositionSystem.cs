using System.Collections.Generic;
using Entitas;

public class BalloonPositionSystem : ReactiveSystem<GameEntity>
{

    readonly GameContext _context;
    private float timer = 0;
    float timerSpeedRatio = 0;
    public BalloonPositionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
         timer = _context.GetEntities(GameMatcher.Timer)[0].timer.timer;
       
        if (timer > 0)
        {
            timerSpeedRatio = 10 / timer;

        }
        foreach (var item in entities)
        {
            item.ReplaceBalloonPosition(item.balloonPosition.x, item.balloonPosition.y + (item.balloonSpeed.balloonSpeed + timerSpeedRatio) * UnityEngine.Time.deltaTime);
            item.balloonGameObject.ballonGO.transform.position = new UnityEngine.Vector3(item.balloonPosition.x, item.balloonPosition.y + (item.balloonSpeed.balloonSpeed * timerSpeedRatio) * UnityEngine.Time.deltaTime, 0);

        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasBalloonPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BalloonPosition);
    }
}
