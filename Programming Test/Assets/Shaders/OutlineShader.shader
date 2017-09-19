Shader "Custom/Outline Shader" {


	Properties {

		_MainTex ("Main Color (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Color ("Color", Color) = (1,1,1,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_OutlineWidth ("Outline Width", Range(0.0,1)) = 0.5
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG

		//Outline
		Tags { "RenderType"="Opaque" }
		Pass {

		Cull Front
		ZWrite On

		CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			float _OutlineWidth;
			float4 _OutlineColor;


			struct appdata{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f {
				float4 pos : SV_POSITION;
			};


			v2f vert (appdata v){

				v2f o;
				o.pos = v.vertex;
				o.pos.xyz += normalize(v.normal.xyz) * _OutlineWidth * 0.01;
				o.pos = UnityObjectToClipPos(o.pos);
				return o;


			}

			half4 frag (v2f i) : COLOR{
				return _OutlineColor;
			}
			ENDCG
		}

				
	}
	FallBack "Diffuse"
}
