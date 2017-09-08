// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/DeConstruct"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NumberTex ("Numbers", 2D) = "black" {}
		_Intensity ("Intensity", Range(0, 1000)) = 0
		_Scale ("Scale", Range(0, 1)) = 0.25
		_Gradiant ("Gradiant", Range(0, 1)) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _NumberTex;
			float4 _MainTex_ST;
			float _Intensity;
			float _Scale;
			float _Gradiant;
			

			v2f vert (appdata v)
			{
				v2f o;
				float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.vertex.x += sin(_Intensity*_Time)*_Scale * (v.vertex.y+0.5);
				//o.vertex.z += sin(_Intensity*_Time)*_Scale * (v.vertex.y + 0.5);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 num = tex2D(_NumberTex, i.uv);
				fixed4 output = lerp(col, num, _Gradiant);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return output;
			}
			ENDCG
		}
	}
}
