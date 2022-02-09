// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "M_Transparent"
{
	Properties
	{
		_T_FeuilleAlpha1("T_FeuilleAlpha1", 2D) = "white" {}
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_T_Feuille1("T_Feuille1", 2D) = "white" {}
		_Float0("Float 0", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _T_Feuille1;
		uniform float4 _T_Feuille1_ST;
		uniform float _Float0;
		uniform sampler2D _T_FeuilleAlpha1;
		uniform float4 _T_FeuilleAlpha1_ST;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_T_Feuille1 = i.uv_texcoord * _T_Feuille1_ST.xy + _T_Feuille1_ST.zw;
			float4 tex2DNode2 = tex2D( _T_Feuille1, uv_T_Feuille1 );
			o.Albedo = tex2DNode2.rgb;
			o.Emission = ( tex2DNode2 * _Float0 ).rgb;
			o.Alpha = 1;
			float2 uv_T_FeuilleAlpha1 = i.uv_texcoord * _T_FeuilleAlpha1_ST.xy + _T_FeuilleAlpha1_ST.zw;
			clip( tex2D( _T_FeuilleAlpha1, uv_T_FeuilleAlpha1 ).a - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17400
90;244;1409;775;1065.985;197.1692;1;True;False
Node;AmplifyShaderEditor.SamplerNode;2;-550,-35.5;Inherit;True;Property;_T_Feuille1;T_Feuille1;1;0;Create;True;0;0;False;0;-1;dec145fc1105a96479d05c5c53f81cca;c74c4d0a49c4e984ea21ce374b2a93bc;True;0;False;white;Auto;False;Instance;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;4;-312.485,170.8308;Inherit;False;Property;_Float0;Float 0;1;0;Create;True;0;0;False;0;0;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-574,186.5;Inherit;True;Property;_T_FeuilleAlpha1;T_FeuilleAlpha1;0;0;Create;True;0;0;False;0;-1;ab0f9fb397b480f4ebe9c7be8b4ebb7b;d3e1dd1f3bd06a34cb1f07cc0632d733;True;0;False;white;Auto;False;Instance;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-148.485,98.8308;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;M_Transparent;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;3;0;2;0
WireConnection;3;1;4;0
WireConnection;0;0;2;0
WireConnection;0;2;3;0
WireConnection;0;10;1;4
ASEEND*/
//CHKSM=0BB5BAF9486D7998BCD808E1D71042AE537F8455