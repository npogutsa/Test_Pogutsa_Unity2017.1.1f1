using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "BallonType")]
public class BalloonScriptableObject : ScriptableObject {

    public GameObject balloonPrefab;
    public float speed;
    public float scale;
    public Color color;
}
