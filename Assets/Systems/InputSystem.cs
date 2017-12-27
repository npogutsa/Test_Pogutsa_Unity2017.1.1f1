using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using UnityEngine.UI;
public class InputSystem : IInitializeSystem, IExecuteSystem
{
    readonly InputContext _context;
    private InputEntity score;
    public InputSystem(Contexts contexts)
    {
        _context = contexts.input;
    }
    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var entityLink = hit.collider.gameObject.GetEntityLink().entity;
                if (!entityLink.HasComponent(GameComponentsLookup.BalloonPopped))
                {
                    entityLink.AddComponent(GameComponentsLookup.BalloonPopped, new BalloonPoppedComponent());
                    score.ReplaceScoreCOmponent(score.scoreCOmponent.score + 1);
                }
            }


        }
    }

    public void Initialize()
    {
        score = _context.CreateEntity();
        score.AddComponent(InputComponentsLookup.ScoreCOmponent, new ScoreCOmponent());
        
        
    }
}
