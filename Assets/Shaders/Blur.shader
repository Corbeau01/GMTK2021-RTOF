Shader "Blur"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}

		_Color("Color", Color) = (1,1,1,1)
		_TexelSize("TexelSize", Vector) = (1,1,1,1)
	}

	SubShader
	{
		Tags
		{
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		ZTest [unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			Name "Default"
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0

			#include "UnityCG.cginc"
			#include "UnityUI.cginc"

			#pragma multi_compile_local _ UNITY_UI_CLIP_RECT
			#pragma multi_compile_local _ UNITY_UI_ALPHACLIP

			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 uv  : TEXCOORD0;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _MainTex_ST_TexelSize;
			float4 TexelSize;
			fixed4 _Color;
			
			float step_w;
			float step_h;

			v2f vert(appdata_t v)
			{
				v2f OUT;
				float4 vPosition = UnityObjectToClipPos(v.vertex);
				OUT.vertex = vPosition;
				OUT.uv = TRANSFORM_TEX(v.texcoord, _MainTex);


				OUT.color = v.color * _Color;
				return OUT;
			}

			fixed4 frag(v2f IN) : SV_Target
			{
				step_w = TexelSize.x;
				step_h = TexelSize.y;

				float2 offset[25] = 
				{
					float2(-step_w*2.0, -step_h*2.0), float2(-step_w, -step_h*2.0),  float2(0.0, -step_h*2.0), float2(step_w, -step_h*2.0), float2(step_w*2.0, -step_h*2.0),
					float2(-step_w*2.0, -step_h),     float2(-step_w, -step_h),      float2(0.0, -step_h),     float2(step_w, -step_h),     float2(step_w*2.0, -step_h),
					float2(-step_w*2.0, 0.0),         float2(-step_w, 0.0),          float2(0.0, 0.0),         float2(step_w, 0.0),         float2(step_w*2.0, 0.0),
					float2(-step_w*2.0, step_h),      float2(-step_w, step_h),       float2(0.0, step_h),      float2(step_w, step_h),      float2(step_w*2.0, step_h),
					float2(-step_w*2.0, step_h*2.0),  float2(-step_w, step_h*2.0),   float2(0.0, step_h*2.0),  float2(step_w, step_h * 20),   float2(step_w*2.0, step_h*2.0)
				};

				float kernel[25] = 
				{

					0.003765,    0.015019,    0.023792,    0.015019,    0.003765,
					0.015019,    0.059912,    0.094907,    0.059912,    0.015019,
					0.023792,    0.094907,    0.150342,    0.094907,    0.023792,
					0.015019,    0.059912,    0.094907,    0.059912,    0.015019,
					0.003765,    0.015019,    0.023792,    0.015019,    0.003765
				};

				float4 sum = float4(0.0, 0.0, 0.0, 0.0);

				for (int j = 0; j < 25; j++) 
				{
					float4 tmp = tex2D(_MainTex, IN.uv + offset[j]);
					//sum += tmp * kernel[j];
					sum +=  _Color* kernel[j];
				}

				return sum;
			}
			ENDCG
		}
	}
}
