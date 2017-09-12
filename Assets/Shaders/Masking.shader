Shader "Hidden/Masking"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_RenderTex ("RenderTex", 2D) = "white" {}
		_FantasyWorld("Fantasy World", 2D) = "white" {}
		_Outline("Outline", 2D) = "white" {}


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
			sampler2D _RenderTex;
			sampler2D _Outline;
			sampler2D _FantasyWorld;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 main = tex2D(_MainTex, i.uv);
				fixed4 outline = tex2D(_Outline, i.uv);
				fixed4 mask = tex2D(_RenderTex, i.uv) * outline;
				fixed4 fw = tex2D(_FantasyWorld, i.uv);
				


				float4 Lerp0 = lerp(main, fw, mask);
				
				
				return Lerp0;
			}
			ENDCG
		}
	}
}
