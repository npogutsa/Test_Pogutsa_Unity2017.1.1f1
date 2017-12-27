Shader "Ballons/Lit/AlphaScreenDependent"
{
	Properties
	{
		_Color("Balloon color", Color) = (1,1,1,1)
		_Alpha("Fade speed ratio", Range(0,6)) = 6
	}
		SubShader
	{
		Blend SrcAlpha One
		ZWrite Off
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }

		ColorMask RGB

		CGPROGRAM

#pragma surface surf Lambert alpha 

	sampler2D _MainTex;
	fixed4 _Color;
	float _Alpha;
	struct Input
	{
		float2 uv_MainTex;
		float3 worldPos;
	};
	//
	void surf(Input IN, inout SurfaceOutput o)
	{
		fixed4 tex = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = _Color;
		o.Alpha = (((unity_OrthoParams.y + _WorldSpaceCameraPos.y) - IN.worldPos.y)) * unity_DeltaTime.x * _Alpha;

	}

	ENDCG
	}
}