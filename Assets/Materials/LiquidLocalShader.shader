Shader "Custom/LiquidUnit_WebGL_Final"
{
    Properties
    {
        _Filling("Filling", Range(0, 1)) = 0.5
        [HDR]_ColorSide("ColorSide", Color) = (0.2001531, 1, 0, 0)
        [HDR]_ColorTop("ColorTop", Color) = (0.08267376, 0.6603774, 0, 0)
        _MinY("Min Y", Float) = 0
        _MaxY("Max Y", Float) = 1
        [HideInInspector]_QueueOffset("_QueueOffset", Float) = 0
        [HideInInspector]_QueueControl("_QueueControl", Float) = -1
        [HideInInspector][NoScaleOffset]unity_Lightmaps("unity_Lightmaps", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_LightmapsInd("unity_LightmapsInd", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_ShadowMasks("unity_ShadowMasks", 2DArray) = "" {}
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Transparent"
            "UniversalMaterialType" = "Unlit"
            "Queue"="Transparent"
            "DisableBatching"="true"
        }
        Pass
        {
            Name "Universal Forward"
            Tags
            {
                // LightMode: <None>
            }
        
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha
        ZTest LEqual
        ZWrite Off
        
        HLSLPROGRAM
        
        #pragma target 2.0
        #pragma multi_compile_instancing
        #pragma instancing_options renderinglayer
        #pragma vertex vert
        #pragma fragment frag
        
        #pragma multi_compile _ LIGHTMAP_ON
        #pragma multi_compile _ DIRLIGHTMAP_COMBINED
        #pragma multi_compile _ USE_LEGACY_LIGHTMAPS
        #pragma multi_compile _ LIGHTMAP_BICUBIC_SAMPLING
        #pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
        #pragma multi_compile_fragment _ DEBUG_DISPLAY
        #pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
        
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        
        struct Attributes
        {
            float3 positionOS : POSITION;
            float3 normalOS : NORMAL;
            float4 tangentOS : TANGENT;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : INSTANCEID_SEMANTIC;
            #endif
        };
        
        struct Varyings
        {
            float4 positionCS : SV_POSITION;
            float3 positionOS : TEXCOORD0;
            float3 normalWS : TEXCOORD1;
            #if UNITY_ANY_INSTANCING_ENABLED
            uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
        };
        
        CBUFFER_START(UnityPerMaterial)
            float _Filling;
            float4 _ColorSide;
            float4 _ColorTop;
            float _MinY;
            float _MaxY;
        CBUFFER_END
        
        Varyings vert(Attributes input)
        {
            Varyings output;
            output.positionCS = TransformObjectToHClip(input.positionOS);
            output.positionOS = input.positionOS;
            output.normalWS = TransformObjectToWorldNormal(input.normalOS);
            #if UNITY_ANY_INSTANCING_ENABLED
            output.instanceID = input.instanceID;
            #endif
            return output;
        }
        
        half4 frag(Varyings input) : SV_Target
        {
           
            float localVertical = input.positionOS.z;
          
            float height = (localVertical - _MinY) / (_MaxY - _MinY);
            height = clamp(height, 0.01, 1);
           
            if (height > _Filling)
            {
                return half4(0, 0, 0, 0);
            }
           
            float gradient = height / max(_Filling, 0.001);
            half4 color = lerp(_ColorSide, _ColorTop, gradient);
            color.a = 1.0;
            
            return color;
        }
        ENDHLSL
        }
    }
    FallBack "Hidden/Shader Graph/FallbackError"
}