using Entitas;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Entitas.Unity;
public class GameManager : MonoBehaviour
{
    private Contexts _contexts;
    private Systems _systems;
    private Systems _gameSystem;
    readonly WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
    readonly int timerEntityIndex = 0;
    CountdownSystem countdownSystem;
    Coroutine balloonsSpawner;
    // Use this for initialization
    void Start()
    {
        _contexts = Contexts.sharedInstance;
        _gameSystem = CreateSystemsGame(_contexts);
        _systems = CreateSystems(_contexts);
        _gameSystem.Initialize();
        _systems.Initialize();
        countdownSystem = new CountdownSystem(_contexts);
        countdownSystem.Initialize();
        balloonsSpawner = StartCoroutine(SpawnBalloons());
        StartCoroutine(CountDown());
    }



    // Update is called once per frame
    void Update()
    {
        _gameSystem.Execute();
        _gameSystem.Cleanup();
        
    }
    private IEnumerator CountDown()
    {
        var timer = _contexts.game.GetEntities(GameMatcher.Timer)[timerEntityIndex].timer.timer;

        while (timer>0)
        {
            timer-=Time.deltaTime;
            _contexts.game.GetEntities(GameMatcher.Timer)[timerEntityIndex].ReplaceTimer(timer);
            countdownSystem.Execute();

            yield return new WaitForEndOfFrame();
        }
        _systems.TearDown();
        _gameSystem.TearDown();
        StopCoroutine(balloonsSpawner);

    }
    private IEnumerator SpawnBalloons()
    {
        while (true)
        {
            _systems.Execute();
            _systems.Cleanup();
            yield return waitForSeconds;
        }
        
    }
    private static Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
                .Add(new BalloonAssetBundleUnpackerSystem(contexts))
                .Add(new BalloonSpawnSystem(contexts));
    }
    private static Systems CreateSystemsGame(Contexts contexts)
    {
        return new Feature("Systems")

                .Add(new BalloonPositionSystem(contexts))
                .Add(new BalloonDestroySystem(contexts))
                .Add(new BallonOutOfRangeCleanupSystem(contexts))
                .Add(new InputSystem(contexts));
             
        
           
    }
    

}
