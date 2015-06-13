Shader "Diffuse - Worldspace" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_Scalex ("Texture Scale X", Float) = 1.0
	_Scaley ("Texture Scale Y", Float) = 1.0
	_Offsety ("Texture Offset Y", Float) = 0
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

CGPROGRAM
#pragma surface surf NoLighting

sampler2D _MainTex;
fixed4 _Color;
float _Scalex, _Scaley, _Offsety;
//float _Scale;

 fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
     {
         fixed4 c;
         c.rgb = s.Albedo; 
         c.a = s.Alpha;
         return c;
     }

struct Input
{
	float3 worldNormal;
	float3 worldPos;
};

void surf (Input IN, inout SurfaceOutput o)
{
	float2 UV;
	fixed4 c;

	float2 _Scale;
	
	_Scale = (_Scalex, _Scaley);

	if(abs(IN.worldNormal.x)>0.5)
	{
		UV = IN.worldPos.yz; // side
		UV.y += _Offsety;
		c = tex2D(_MainTex, UV* _Scale); // use WALLSIDE texture
	}
	else if(abs(IN.worldNormal.z)>0.5)
	{
		UV = IN.worldPos.xy; // front
		UV.y += _Offsety;
		c = tex2D(_MainTex, UV* _Scale); // use WALL texture
	}
	else
	{
		UV = IN.worldPos.xz; // top
		UV.y += _Offsety;
		c = tex2D(_MainTex, UV* _Scale); // use FLR texture
	}

	o.Albedo = c.rgb * _Color;
}
ENDCG
}

Fallback "VertexLit"
}
