using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BallonOutOfRangeCleanupSystem : ReactiveSystem<GameEntity> {
    Contexts _contexts;
    private float outOfRangeBorder { get { return Camera.main.transform.position.y + 2 * Camera.main.orthographicSize * Screen.height / Screen.width; } }

    public BallonOutOfRangeCleanupSystem(Contexts contexts):base(contexts.game)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.balloonPosition.y > outOfRangeBorder)
            {
                entity.isBalloonPopped = true;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasBalloonPosition && entity.hasBalloonGameObject && !entity.isBalloonPopped;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BalloonPosition);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
