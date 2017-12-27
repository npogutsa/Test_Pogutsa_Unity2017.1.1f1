using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class BalloonSpawnSystem : IExecuteSystem
{
    readonly Transform viewContainer = new GameObject("Balloons").transform;
    private Contexts contexts;
    private float spawnerPosY { get { return Camera.main.transform.position.y - 2* Camera.main.orthographicSize * Screen.height / Screen.width; } }
    private float spawnerBorderLeft { get { return Camera.main.transform.position.x - Camera.main.orthographicSize * Screen.width / Screen.height; } }
    private float spawnerBorderRight { get { return Camera.main.transform.position.x + Camera.main.orthographicSize * Screen.width / Screen.height; } }
    private float offset = 1;
    public BalloonSpawnSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }

    public void Execute()
    {
        int type = Random.Range(0, ABLoader.AssetBundlesLoader.balloonTypes.Count);
        var newBalloonEntity = contexts.game.CreateEntity();
        var balloonSO = ABLoader.AssetBundlesLoader.balloonTypes[type];
        newBalloonEntity.AddBalloonSO(balloonSO);
        newBalloonEntity.AddBalloonScale(balloonSO.scale);
        GameObject go = GameObject.Instantiate(ABLoader.AssetBundlesLoader.balloonTypes[type].balloonPrefab, new Vector3(Random.Range(spawnerBorderLeft + offset, spawnerBorderRight- offset), spawnerPosY, 1), Quaternion.Euler(new Vector3(-90,0,0)), viewContainer);
        go.transform.localScale *= balloonSO.scale;
        go.GetComponent<Renderer>().material.SetColor("_Color", balloonSO.color);
        go.Link(newBalloonEntity, contexts.game);
        newBalloonEntity.AddBalloonSpeed(2 / balloonSO.scale);
        newBalloonEntity.AddBalloonGameObject(go);
        newBalloonEntity.AddBalloonPosition(go.transform.position.x, go.transform.position.y);
        newBalloonEntity.AddBalloonActive(true);
        
    }



}
