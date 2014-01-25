Shader "Custom/CutoutBevel" {
	Properties {
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
         _Color ("Light Color", Color) = (0.5,0.5,0.5,1.0)
		_RotationX ("rotation x", Range(-1,1)) = 0
		_RotationY ("rotation y", Range(-1,1)) = 0
	_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
	}
	SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 100
	Pass {
	ZTest LEqual
		ZWrite Off
		Lighting Off
		Fog { Mode off }
		Alphatest Greater [_Cutoff]

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma fragmentoption ARB_precision_hint_fastest 
		
		#include "UnityCG.cginc"
		
		uniform sampler2D _MainTex;
		uniform sampler2D _BumpMap;

		float4 _Color;		
		float _RotationX;
		float _RotationY;
		
		struct v2f {
			float4 pos : POSITION;
			float2 uv : TEXCOORD0;
		};
		
		v2f vert( appdata_img v )
		{
			v2f o;
			o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			o.uv = v.texcoord.xy;
			
			return o;
		}
		
		half4 frag (v2f i) : COLOR
		{
	
			fixed3 normal = UnpackNormal(tex2D (_BumpMap, i.uv.xy));
			half4 color = _Color;
			color.rgb +=clamp(dot(normalize(float3 (_RotationX,_RotationY,1)), normal),0,1);
			color = tex2D (_MainTex, i.uv.xy)*clamp(color,0,1);
			//float x = sin((_RotationX)*2*3.1415)/2+0.5;
			//float y = cos((_RotationX)*2*3.1415)/2+0.5;
			//color = tex2D (_MainTex, float2 (distance(float2 (x,y), float2(normal.r,normal.g)),0.5) );
			return color;
		}
		ENDCG
	}
	} 
	FallBack "Diffuse"
}
