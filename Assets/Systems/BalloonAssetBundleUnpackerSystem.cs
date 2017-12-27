using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.IO;

public class BalloonAssetBundleUnpackerSystem : IInitializeSystem
{
    readonly GameContext _context;

    public BalloonAssetBundleUnpackerSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "ballonscriptableobjects.1"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        PopulateAssetList(myLoadedAssetBundle.LoadAllAssets());

        //myLoadedAssetBundle.Unload(true);
    }
    private void PopulateAssetList(UnityEngine.Object[] array)
    {
        foreach (var asset in array)
        {
            ABLoader.AssetBundlesLoader.balloonTypes.Add((BalloonScriptableObject)asset);
        }
    }
    //serialization would be an overkill

}
