Shader "Custom/ShaderTest"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color",Color) = (0,0,0,0)
		_Scale("Escala",Range(-0.1,0.1)) = 0
		_Speed ("Speed", float) = 1
		_Frequencia("Frequência",float) =1 
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
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Scale,_Speed,_Frequencia;
			float4 _Color;

			v2f vert (appdata v)
			{
				v2f o;
				//v.vertex.xyz += v.normal.xyz * _ExtrudeAmout * sin(_Time.y);

				half offset = v.vertex.x;
				half value = _Scale * sin(_Time.w*_Speed+offset*_Frequencia);

				v.vertex.xyz += value;

				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;

				return o;
			}

			fixed4 frag(v2f IN) : SV_Target{
				float4 textureColor = tex2D(_MainTex, IN.uv);
				return textureColor+_Color;
			}

			ENDCG
		}
	}
}
