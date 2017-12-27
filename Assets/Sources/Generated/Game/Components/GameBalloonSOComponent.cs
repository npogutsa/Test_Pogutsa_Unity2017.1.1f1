//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BalloonSOComponent balloonSO { get { return (BalloonSOComponent)GetComponent(GameComponentsLookup.BalloonSO); } }
    public bool hasBalloonSO { get { return HasComponent(GameComponentsLookup.BalloonSO); } }

    public void AddBalloonSO(BalloonScriptableObject newBalloonSO) {
        var index = GameComponentsLookup.BalloonSO;
        var component = CreateComponent<BalloonSOComponent>(index);
        component.balloonSO = newBalloonSO;
        AddComponent(index, component);
    }

    public void ReplaceBalloonSO(BalloonScriptableObject newBalloonSO) {
        var index = GameComponentsLookup.BalloonSO;
        var component = CreateComponent<BalloonSOComponent>(index);
        component.balloonSO = newBalloonSO;
        ReplaceComponent(index, component);
    }

    public void RemoveBalloonSO() {
        RemoveComponent(GameComponentsLookup.BalloonSO);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBalloonSO;

    public static Entitas.IMatcher<GameEntity> BalloonSO {
        get {
            if (_matcherBalloonSO == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BalloonSO);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBalloonSO = matcher;
            }

            return _matcherBalloonSO;
        }
    }
}
