Shader "Unlit/mosaic" {
	Properties{
	_MainTex("Base (RGB)", 2D) = "white" {}
	_intensity("Black & White blend", Range(1, 500)) = 1
	}
		SubShader{
		Pass {
		CGPROGRAM
		#pragma vertex vert_img
		#pragma fragment frag

		#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
		uniform int _intensity;

		float4 frag(v2f_img i) : COLOR {

		i.uv = round(i.uv * _intensity) / _intensity;
		float4 c = tex2D(_MainTex, i.uv);
/*
		float lum = c.r*.3 + c.g*.59 + c.b*.11;
		float3 bw = float3(lum, lum, lum);
		*/
		float4 result = c;
		return result;
		}
		ENDCG
		}
	}
}