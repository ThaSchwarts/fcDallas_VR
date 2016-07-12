// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2;n:type:ShaderForge.SFN_Vector1,id:6837,x:30558,y:33254,varname:node_6837,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6919,x:30558,y:33347,varname:node_6919,prsc:2,v1:1;n:type:ShaderForge.SFN_Append,id:9970,x:30736,y:33278,varname:node_9970,prsc:2|A-6837-OUT,B-6919-OUT;n:type:ShaderForge.SFN_Multiply,id:4693,x:30966,y:33271,varname:node_4693,prsc:2|A-306-OUT,B-9970-OUT;n:type:ShaderForge.SFN_Append,id:306,x:30736,y:33116,varname:node_306,prsc:2|A-9717-X,B-9717-Y;n:type:ShaderForge.SFN_FragmentPosition,id:9717,x:30458,y:33094,varname:node_9717,prsc:2;n:type:ShaderForge.SFN_Add,id:5161,x:31221,y:33353,varname:node_5161,prsc:2|A-4693-OUT,B-700-OUT;n:type:ShaderForge.SFN_Vector1,id:9348,x:30537,y:33452,varname:node_9348,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:3517,x:30552,y:33538,varname:node_3517,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:5165,x:30727,y:33494,varname:node_5165,prsc:2|A-9348-OUT,B-3517-OUT;n:type:ShaderForge.SFN_Time,id:1659,x:30723,y:33644,varname:node_1659,prsc:2;n:type:ShaderForge.SFN_Multiply,id:700,x:30966,y:33471,varname:node_700,prsc:2|A-5165-OUT,B-1659-TSL;n:type:ShaderForge.SFN_OneMinus,id:6862,x:31453,y:33349,varname:node_6862,prsc:2|IN-5161-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4525,x:31631,y:33347,varname:node_4525,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6862-OUT;n:type:ShaderForge.SFN_Frac,id:3333,x:31816,y:33347,varname:node_3333,prsc:2|IN-4525-OUT;n:type:ShaderForge.SFN_Power,id:5405,x:32002,y:33347,varname:node_5405,prsc:2|VAL-3333-OUT;pass:END;sub:END;*/

Shader "Shader Forge/hologram" {
    Properties {
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
                float3 finalColor = 0;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
