//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public ScoreCOmponent scoreCOmponent { get { return (ScoreCOmponent)GetComponent(InputComponentsLookup.ScoreCOmponent); } }
    public bool hasScoreCOmponent { get { return HasComponent(InputComponentsLookup.ScoreCOmponent); } }

    public void AddScoreCOmponent(float newScore) {
        var index = InputComponentsLookup.ScoreCOmponent;
        var component = CreateComponent<ScoreCOmponent>(index);
        component.score = newScore;
        AddComponent(index, component);
    }

    public void ReplaceScoreCOmponent(float newScore) {
        var index = InputComponentsLookup.ScoreCOmponent;
        var component = CreateComponent<ScoreCOmponent>(index);
        component.score = newScore;
        ReplaceComponent(index, component);
    }

    public void RemoveScoreCOmponent() {
        RemoveComponent(InputComponentsLookup.ScoreCOmponent);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherScoreCOmponent;

    public static Entitas.IMatcher<InputEntity> ScoreCOmponent {
        get {
            if (_matcherScoreCOmponent == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.ScoreCOmponent);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherScoreCOmponent = matcher;
            }

            return _matcherScoreCOmponent;
        }
    }
}
