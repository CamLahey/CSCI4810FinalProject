Shader "Unlit/ToonShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _LightPoint("uDirLightPos", Vector) = (0,0,0,0)
        _Color("Color", Color) = (1,1,1,1)
        _uKd("uKd", float) = 1.0
        _uBorder("uBorder", float) = 0.0

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
                float4 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
                float3 worldPosition : TEXCOORD2;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _LightPoint;
            float4 _Color;
            fixed3 vNormal;
            fixed3 vViewPosition;

            v2f vert (appdata v)
            {
                v2f o;
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPosition = mul(unity_ObjectToWorld, v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed3 lightDifference = i.worldPosition - _LightPoint.xyz;
                fixed3 lightDirection = normalize(lightDifference);
                fixed diffuse = -1 * dot(lightDirection, i.worldNormal);
                if (diffuse > 0.6) {
                    diffuse = 1.0;
                }
                else if (diffuse > -.2) {
                    diffuse = 0.7;
                }
                else {
                    diffuse = 0.3;
                }
                fixed4 col = fixed4(diffuse * tex2D(_MainTex, i.uv) * _Color);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
