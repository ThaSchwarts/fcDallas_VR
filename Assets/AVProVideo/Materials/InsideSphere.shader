Shader "Unlit/InsideSphere"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

		[KeywordEnum(None, Top_Bottom, Left_Right)] Stereo ("Stereo Mode", Float) = 0
		[Toggle(STEREO_DEBUG)] _StereoDebug ("Stereo Debug Tinting", Float) = 0
    }
    SubShader
    {
		Tags { "RenderType"="Opaque" }
		Cull Off

        Pass
        {
            CGPROGRAM
			#include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag

			//#define STEREO_DEBUG 1

			#pragma multi_compile MONOSCOPIC STEREO_TOP_BOTTOM STEREO_LEFT_RIGHT
			#pragma multi_compile STEREO_DEBUG_OFF STEREO_DEBUG

            struct appdata
            {
                float4 vertex : POSITION; // vertex position
                float2 uv : TEXCOORD0; // texture coordinate
            };

            struct v2f
            {
                float4 vertex : SV_POSITION; // clip space position
                float2 uv : TEXCOORD0; // texture coordinate

#if STEREO_DEBUG
				float4 tint : COLOR;
#endif
            };

            uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform float3 _cameraPosition;

			bool DetermineEye()
			{
#ifdef UNITY_SINGLE_PASS_STEREO

				// Unity 5.4 has this new variable
				return (unity_StereoEyeIndex == 0);
#else
				// _cameraPosition is the camera positon passed in from Unity via script
				// We need to determine whether _WorldSpaceCameraPos (Unity shader variable) is to the left or to the right of _cameraPosition
				float3 right = UNITY_MATRIX_V[0].xyz;
				float dRight = distance(_cameraPosition + right, _WorldSpaceCameraPos);
				float dLeft = distance(_cameraPosition - right, _WorldSpaceCameraPos);
				return (dRight > dLeft);
#endif
			}

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv.xy = float2(1-o.uv.x, o.uv.y);

#if STEREO_DEBUG
				o.tint = 1;
#endif

#if STEREO_TOP_BOTTOM | STEREO_LEFT_RIGHT

				bool isLeftEye = DetermineEye();

#if STEREO_TOP_BOTTOM
				// Top-Bottom
				if (isLeftEye)
				{
					// Left eye (green)
#if UNITY_UV_STARTS_AT_TOP
					o.uv.y = (o.uv.y / 2.0);
#else
					o.uv.y = (o.uv.y / 2.0) + 0.5;
#endif
					
#if STEREO_DEBUG
					o.tint = float4(0, 1, 0, 1);
#endif
				}
				else
				{
					// Right eye (red)
#if UNITY_UV_STARTS_AT_TOP
					
					o.uv.y = (o.uv.y / 2.0) + 0.5;
#else
					o.uv.y = (o.uv.y / 2.0);
#endif

#if STEREO_DEBUG
					o.tint = float4(1, 0, 0, 1);
#endif
				}
#elif STEREO_LEFT_RIGHT

				// Left-Right 
				if (isLeftEye)
				{
					// Left eye (green)
					o.uv.x = (o.uv.x / 2.0);
#if STEREO_DEBUG
					o.tint = float4(0, 1, 0, 1);
#endif
				}
				else
				{
					// Right eye (red)
					o.uv.x = (o.uv.x / 2.0) + 0.5;
#if STEREO_DEBUG
					o.tint = float4(1, 0, 0, 1);
#endif
				}
#endif
#endif
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // sample texture and return it
                fixed4 col = tex2D(_MainTex, i.uv);
#if STEREO_DEBUG
				col *= i.tint;
#endif
                return fixed4(col.rgb, 1.0);
            }
            ENDCG
        }
    }
}