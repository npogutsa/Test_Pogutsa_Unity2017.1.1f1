//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ViewComponent view { get { return (ViewComponent)GetComponent(GameComponentsLookup.View); } }
    public bool hasView { get { return HasComponent(GameComponentsLookup.View); } }

    public void AddView(UnityEngine.GameObject newBalloon) {
        var index = GameComponentsLookup.View;
        var component = CreateComponent<ViewComponent>(index);
        component.balloon = newBalloon;
        AddComponent(index, component);
    }

    public void ReplaceView(UnityEngine.GameObject newBalloon) {
        var index = GameComponentsLookup.View;
        var component = CreateComponent<ViewComponent>(index);
        component.balloon = newBalloon;
        ReplaceComponent(index, component);
    }

    public void RemoveView() {
        RemoveComponent(GameComponentsLookup.View);
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

    static Entitas.IMatcher<GameEntity> _matcherView;

    public static Entitas.IMatcher<GameEntity> View {
        get {
            if (_matcherView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.View);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherView = matcher;
            }

            return _matcherView;
        }
    }
}
