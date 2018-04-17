// This shader is hugely based on "saturation" by megaloler (https://www.shadertoy.com/view/XttGWB)

Shader "Hidden/CustomColorGrading"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_saturation("saturation value", Float) = 0.3
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float _saturation;

			float3 applySaturation(float3 col) {
				float saturationScale = 0.3; //_saturation; you could tweak the saturation value in the editor if you like

				float average = (col.x + col.y + col.z) / 3.0;
				float xd = average - col.x;
				float yd = average - col.y;
				float zd = average - col.z;
				col.x += xd * -saturationScale;
				col.y += yd * -saturationScale;
				col.z += zd * -saturationScale;
				return col;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				float3 saturatedColor = applySaturation(col.rgb);
				return fixed4(saturatedColor, 1.0);
			}
			ENDCG
		}
	}
}
