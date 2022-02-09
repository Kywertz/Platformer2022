// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_BottomStrength("BottomStrength", Float) = 3.47
		_SimpleNoise("SimpleNoise", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Background+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows exclude_path:deferred 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _BottomStrength;
		uniform sampler2D _SimpleNoise;
		uniform float4 _SimpleNoise_ST;


		float2 voronoihash9( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi9( float2 v, float time, inout float2 id )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mr = 0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash9( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = g - f + o;
					float d = 0.5 * dot( r, r );
			 		if( d<F1 ) {
			 			F2 = F1;
			 			F1 = d; mg = g; mr = r; id = o;
			 		} else if( d<F2 ) {
			 			F2 = d;
			 		}
			 	}
			}
			return F1;
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 color62 = IsGammaSpace() ? float4(1,1,1,0) : float4(1,1,1,0);
			float4 color22 = IsGammaSpace() ? float4(0,0.530354,0.7924528,0) : float4(0,0.2432197,0.5911142,0);
			float time9 = ( 2.0 * _Time.y );
			float2 temp_cast_0 = (10.0).xx;
			float2 uv_TexCoord3 = i.uv_texcoord * temp_cast_0;
			float2 coords9 = ( uv_TexCoord3 + ( 0.5 * _Time.y ) ) * 10.0;
			float2 id9 = 0;
			float voroi9 = voronoi9( coords9, time9,id9 );
			float temp_output_27_0 = (0.1 + (pow( voroi9 , 1.0 ) - 0.0) * (1.0 - 0.1) / (1.0 - 0.0));
			float2 uv_SimpleNoise = i.uv_texcoord * _SimpleNoise_ST.xy + _SimpleNoise_ST.zw;
			float4 temp_cast_1 = (0.1).xxxx;
			float4 lerpResult61 = lerp( color62 , color22 , ( temp_output_27_0 + (float4( 0,0,0,0 ) + (( pow( ( 1.0 - i.uv_texcoord.y ) , _BottomStrength ) * ( 0.0 * tex2D( _SimpleNoise, uv_SimpleNoise ) ) ) - float4( 0,0,0,0 )) * (temp_cast_1 - float4( 0,0,0,0 )) / (float4( 1,0,0,0 ) - float4( 0,0,0,0 ))) ));
			o.Albedo = saturate( ( 1.0 - saturate( lerpResult61 ) ) ).rgb;
			float3 temp_cast_3 = (( 1.0 * temp_output_27_0 )).xxx;
			o.Emission = temp_cast_3;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17400
273;549;1409;781;2130.731;-23.21741;1;True;False
Node;AmplifyShaderEditor.SimpleTimeNode;14;-1792,208;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;48;-1824,352;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;15;-1962,-110;Inherit;False;Constant;_Tiling;Tiling;0;0;Create;True;0;0;False;0;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;17;-1792,128;Inherit;False;Constant;_RipplesSpeed;RipplesSpeed;0;0;Create;True;0;0;False;0;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-1504,176;Inherit;False;Constant;_VoronoiSpeed;VoronoiSpeed;0;0;Create;True;0;0;False;0;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;45;-1616,352;Inherit;True;FLOAT2;1;0;FLOAT2;0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.TextureCoordinatesNode;3;-1792,-128;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-1632,160;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-1343.07,184.1396;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;55;-1122,580;Inherit;False;Constant;_Float1;Float 1;2;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;51;-1408,656;Inherit;True;Property;_SimpleNoise;SimpleNoise;1;0;Create;True;0;0;False;0;-1;f7ef6a613bc91fc438545b025a22fe3b;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;11;-1408,0;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-1376,272;Inherit;False;Constant;_VoronoiScale;VoronoiScale;0;0;Create;True;0;0;False;0;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;46;-1392,354.5887;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;49;-1408,576;Float;False;Property;_BottomStrength;BottomStrength;0;0;Create;True;0;0;False;0;3.47;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;20;-960,240;Inherit;False;Constant;_RippleAmount;RippleAmount;0;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;9;-1024,0;Inherit;True;0;0;1;0;1;False;1;False;3;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;2;FLOAT;0;FLOAT;1
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;54;-992,576;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.PowerNode;47;-1088,352;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;19;-640,0;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;28;-704,225;Inherit;False;Constant;_Float0;Float 0;0;0;Create;True;0;0;False;0;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;57;-738,565;Inherit;False;Constant;_Float2;Float 2;2;0;Create;True;0;0;False;0;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;50;-737,352;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TFHCRemapNode;27;-528,160;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;56;-528,352;Inherit;False;5;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;59;-128,160;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;22;-128,-16;Inherit;False;Constant;_Color;Color;0;0;Create;True;0;0;False;0;0,0.530354,0.7924528,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;62;-128,-192;Inherit;False;Constant;_Color0;Color 0;0;0;Create;True;0;0;False;0;1,1,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;61;256,-32;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;66;496,-32;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;68;672,-32;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;74;917.5105,92.34551;Inherit;False;Constant;_Float3;Float 3;3;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;71;-1311.053,-262.7611;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;67;848,-32;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.BreakToComponentsNode;70;-1535.053,-262.7611;Inherit;True;FLOAT2;1;0;FLOAT2;0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;75;1089.894,143.522;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1221.782,-59.46582;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Unlit/NewUnlitShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Opaque;;Background;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;2;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;45;0;48;0
WireConnection;3;0;15;0
WireConnection;4;0;17;0
WireConnection;4;1;14;0
WireConnection;12;0;18;0
WireConnection;12;1;14;0
WireConnection;11;0;3;0
WireConnection;11;1;4;0
WireConnection;46;0;45;1
WireConnection;9;0;11;0
WireConnection;9;1;12;0
WireConnection;9;2;24;0
WireConnection;54;0;55;0
WireConnection;54;1;51;0
WireConnection;47;0;46;0
WireConnection;47;1;49;0
WireConnection;19;0;9;0
WireConnection;19;1;20;0
WireConnection;50;0;47;0
WireConnection;50;1;54;0
WireConnection;27;0;19;0
WireConnection;27;3;28;0
WireConnection;56;0;50;0
WireConnection;56;4;57;0
WireConnection;59;0;27;0
WireConnection;59;1;56;0
WireConnection;61;0;62;0
WireConnection;61;1;22;0
WireConnection;61;2;59;0
WireConnection;66;0;61;0
WireConnection;68;0;66;0
WireConnection;71;0;70;0
WireConnection;67;0;68;0
WireConnection;70;0;48;0
WireConnection;75;0;74;0
WireConnection;75;1;27;0
WireConnection;0;0;67;0
WireConnection;0;2;75;0
ASEEND*/
//CHKSM=1DFB9A6A5385635CB85E3FC4C8242E383CB3C2DA