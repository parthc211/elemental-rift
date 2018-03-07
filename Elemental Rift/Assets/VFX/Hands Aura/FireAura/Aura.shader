Shader "Custom/Aura" {
	Properties
	{
		_FinalPower("Final Power", Range(0 , 10)) = 1
		_FinalColor("Final Color", Color) = (1,1,1,1)
		_FinalOpacityPower("Final Opacity Power", Range(0 , 4)) = 1
		_EmberTex("Ember Tex", 2D) = "white" {}
	_Ramp("Ramp", 2D) = "white" {}
	_RampMask("Ramp Mask", 2D) = "white" {}
	_SoftParticleValue("Soft Particle Value", Float) = 0.25
		[HideInInspector] _texcoord("", 2D) = "white" {}
	[HideInInspector] __dirty("", Int) = 1
	}

		SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true" }
		Cull Back
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
#include "UnityCG.cginc"
#pragma target 3.0
#pragma surface surf Unlit alpha:fade keepalpha noshadow noambient novertexlights nolightmap  nodynlightmap nodirlightmap nometa noforwardadd 
		struct Input
	{
		float2 uv_texcoord;
		float4 vertexColor : COLOR;
		float4 screenPos;
	};

	uniform sampler2D _RampMask;
	uniform sampler2D _EmberTex;
	uniform float4 _EmberTex_ST;
	uniform sampler2D _Ramp;
	uniform float4 _FinalColor;
	uniform float _FinalPower;
	uniform float _FinalOpacityPower;
	uniform sampler2D _CameraDepthTexture;
	uniform float _SoftParticleValue;

	inline fixed4 LightingUnlit(SurfaceOutput s, half3 lightDir, half atten)
	{
		return fixed4(0, 0, 0, s.Alpha);
	}

	void surf(Input i , inout SurfaceOutput o)
	{
		float2 uv_EmberTex = i.uv_texcoord * _EmberTex_ST.xy + _EmberTex_ST.zw;
		float4 tex2DNode1 = tex2D(_EmberTex, uv_EmberTex);
		float2 appendResult3 = (float2(tex2DNode1.r , 0.0));
		o.Emission = (tex2D(_RampMask, appendResult3).r * tex2D(_Ramp, appendResult3) * i.vertexColor * _FinalColor * _FinalPower).rgb;
		float4 ase_screenPos = float4(i.screenPos.xyz , i.screenPos.w + 0.00000000001);
		float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
		ase_screenPosNorm.z = (UNITY_NEAR_CLIP_VALUE >= 0) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
		float screenDepth17 = LinearEyeDepth(UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture,UNITY_PROJ_COORD(ase_screenPos))));
		float distanceDepth17 = abs((screenDepth17 - LinearEyeDepth(ase_screenPosNorm.z)) / (_SoftParticleValue));
		float clampResult19 = clamp(distanceDepth17 , 0.0 , 1.0);
		float clampResult13 = clamp((i.vertexColor.a * _FinalOpacityPower * tex2DNode1.r * clampResult19) , 0.0 , 1.0);
		o.Alpha = clampResult13;
	}

	ENDCG
	}
		CustomEditor "ASEMaterialInspector"
}
