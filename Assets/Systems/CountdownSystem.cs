using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class CountdownSystem : IInitializeSystem, IExecuteSystem {
    readonly GameContext _contexts;
    readonly InputContext _inputContexts;
    private GameEntity countdownTimer;
    private Text timerText;
    private Text scoreText;

    public CountdownSystem(Contexts contexts)
    {
        _contexts = contexts.game;
        _inputContexts = contexts.input;
    }
    public void Execute()
    {
        timerText.text = ((int)countdownTimer.timer.timer).ToString();
        if (countdownTimer.timer.timer<=0)
        {
            scoreText.text = _inputContexts.GetEntities(InputMatcher.ScoreCOmponent)[0].scoreCOmponent.score.ToString();
            timerText.text = "";

            ShutDown();
        }
    }
    private void ShutDown()
    {
        foreach (var item in _contexts.GetEntities(GameMatcher.AllOf(GameMatcher.BalloonPosition)))
        {
            if (!item.isBalloonPopped)
            {
                item.AddComponent(GameComponentsLookup.BalloonPopped, new BalloonPoppedComponent());

            }
        }
    }
    public void Initialize()
    {
        timerText = GameObject.Find("timer").GetComponent<Text>();
        scoreText = GameObject.Find("score").GetComponent<Text>();
        countdownTimer = _contexts.CreateEntity();
        countdownTimer.AddTimer(60);
    }

   
}
