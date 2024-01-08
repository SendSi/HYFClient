

Shader "SLG_Particles/FX_Main" {
	Properties{
		[Enum(Alpha Blend,10,Addtive,1)] _DestBlend("混合模式", Float) = 1
		[Enum(UnityEngine.Rendering.CullMode)] _Cull("剔除", Float) = 0
		[Enum(Off,0,On,1)] _ZWrite("深度写入", Float) = 0
		_Zoffset("深度偏移",Range(-0.5,0.5)) = 0
		[Space]
		[Space]
		[MaterialToggle] _Main("基础效果开关", Float) = 1
		[MaterialToggle] _ContrastToggle("幂开关",Float) = 0
		_MainContrast("幂", float) = 1
		[Space]
		[Space]
		[Toggle(_FRESNEL_ON)] _Fresnel("Fresnel开关", Float) = 0
		_Exp("Exp", Float) = 1
		[MaterialToggle] _CVS_W("自定义W=Fresnel范围", Float) = 0
		[HDR]_FresnelColor("Fresnel Color", Color) = (1,1,1,1)
		[Toggle(_FRESNELCHANEL_ON)] _FresnelChanel("Fresnel作为alpha", Float) = 0
		[Space]
		[Space]
		[MaterialToggle] _DissolveToggle("溶解开关",Float) = 0
		[Toggle] _DissolveColType("多颜色溶解/单颜色溶解",int) = 0
		[MaterialToggle] _DissolveTex("更换Noise作为溶解纹理（默认为Main）", Float) = 0
		[MaterialToggle] _CVS_Z("自定义Z=溶解强度", Float) = 0
		_DissolveInt("溶解强度", Range(0, 1)) = 0
		_DissolveStep("边缘羽化", Range(-1, 1)) = 0
		_DissolveEdge("边缘范围", Range(-1, 1)) = 0
		_EdgeColor1("边缘 Color1", Color) = (1,1,1,1)
		_EdgeColor2("边缘 Color2", Color) = (1,1,1,1)
		_EdgeColor3("边缘 Color3", Color) = (1,1,1,1)
		[Space]
		[Space]
		_Intensity("Main/Mask/边缘/Fresnel 强度", Vector) = (1,1,1,1)
		[HDR]_TintColor("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex("MainTex", 2D) = "white" {}
		[MaterialToggle] _MainAlpha("Main alpha开关", Float) = 1
		[MaterialToggle] _CVS_UV("自定义XY=MainUV", Float) = 0
		[MaterialToggle] _MainPolarCoord("Main极坐标", Float) = 0
		_MainAlphaCut("Main Alpha cut", Range(-1,1)) = 0
		[MaterialToggle] _ColorOffset("色调偏移开关",Float) = 0
		_Mainoffset("Main色调偏离", Range(-0.1,0.1)) = 0
		_MainSpeed("Main UV流动/旋转", Vector) = (0,0,0,0)
		[Space]
		[Space]
		[MaterialToggle] _Mask("开启Mask图", Float) = 0
		_MaskTex("Mask Tex", 2D) = "white" {}
		[MaterialToggle] _CVS_UV2("自定义XY=MaskUV", Float) = 0
		[MaterialToggle] _MaskPolarCoord("Mask极坐标", Float) = 0
		[MaterialToggle] _AlphaMask("Mask作为Main遮罩", Float) = 0
		[MaterialToggle] _AlphaMask1("Mask作为Main遮罩且保持原来颜色(不可与以上同时使用)", Float) = 0
		[MaterialToggle] _NoiseMask("Mask作为Noise遮罩", Float) = 0
		[Toggle(_TEXTURE02_ON)] _Texture02("Mask作为叠加纹理",Float) = 0
		[MaterialToggle] _MainMask("Main * Mask", Float) = 0
		_MaskAlphaCut("Mask Alpha cut", Range(-1,1)) = 0
		[HDR]_Tex02Color("叠加纹理 Color", Color) = (0.5,0.5,0.5,0.5)
		_MaskSpeed("Mask UV流动/旋转", Vector) = (0,0,0,0)
		[Space]
		[Space]
		[MaterialToggle] _Noise("开启Noise图", Float) = 0
		_NoiseTex("Noise Tex", 2D) = "white" {}
		[MaterialToggle] _NoisePolarCoord("Noise极坐标", Float) = 0
		[MaterialToggle] _Mask02("开启Noise作为全局遮罩", Float) = 0
		_NoiseInt("紊乱强度", Range(-1, 1)) = 0
		_NoiseSpeed("Noise UV流动/旋转", Vector) = (0,0,0,0)
		[Space]
		[Space]
		[MaterialToggle] _VertexOffset("顶点偏移开关", Float) = 0
		_VertexOffsetInt("顶点偏移", Range(-1,1)) = 0
		[MaterialToggle] _CVS_V("自定义W=顶点偏移", Float) = 0
		[HideInInspector]_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
		[Space]
		[Space]
		_StencilComp("Stencil Comparison", Float) = 8.000000
		_Stencil("Stencil ID", Float) = 0.000000
		_StencilOp("Stencil Operation", Float) = 0.000000
		_StencilWriteMask("Stencil Write Mask", Float) = 255.000000
		_StencilReadMask("Stencil Read Mask", Float) = 255.000000
	}
		SubShader{
			Tags {
				"IgnoreProjector" = "True"
				"Queue" = "Transparent"
				"RenderType" = "Transparent"
				"PreviewType" = "Plane"
			}
			Pass {
				Name "FORWARD"
				Tags {
					"LightMode" = "ForwardBase"
				}
				Blend SrcAlpha[_DestBlend]
				Cull[_Cull]
				ZWrite[_ZWrite]
				Offset[_Zoffset],0

				Stencil
				{
					Ref[_Stencil]
					ReadMask[_StencilReadMask]
					WriteMask[_StencilWriteMask]
					Comp[_StencilComp]
					Pass[_StencilOp]
				}
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"
				#pragma target 3.0
				#pragma multi_compile _ _FRESNEL_ON
				#pragma multi_compile _ _COLOROFFSET_ON
				#pragma multi_compile _ _CONTRASTTOGGLE_ON
				#pragma multi_compile _ _MAIN_ON
				#pragma multi_compile _ _NOISE_ON
				#pragma multi_compile _ _MASK_ON
				#pragma multi_compile _ _DISSOLVETOGGLE_ON
				#pragma multi_compile _ _VERTEXOFFSET_ON



				uniform sampler2D _NoiseTex; uniform float4 _NoiseTex_ST;
				uniform half _NoisePolarCoord;
				uniform half _DissolveInt;
				uniform half _CVS_Z;
				uniform half _DissolveStep;
				uniform half _DissolveEdge;
				uniform half _Mask02;
				uniform fixed4 _TintColor;
				uniform fixed4 _Intensity;
				uniform fixed4 _EdgeColor1;
				uniform fixed4 _EdgeColor2;
				uniform fixed4 _EdgeColor3;
				uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
				uniform half _MainPolarCoord;
				uniform half _AlphaMask;
				uniform half _AlphaMask1;
				uniform half _MainAlphaCut;
				uniform fixed4 _MainSpeed;
				uniform half _Mainoffset;
				uniform half _CVS_UV;
				uniform half _DissolveTex;
				uniform sampler2D _MaskTex; uniform float4 _MaskTex_ST;
				uniform half _MaskPolarCoord;
				uniform fixed4 _MaskSpeed;
				uniform half _MaskAlphaCut;
				uniform half _Texture02;
				uniform half _MainMask;
				uniform half _CVS_UV2;
				uniform fixed4 _Tex02Color;
				uniform half _NoiseMask;
				uniform half _NoiseInt;
				uniform fixed4 _NoiseSpeed;
				uniform half _Exp;
				uniform half _CVS_W;
				uniform half _CVS_V;
				uniform fixed4 _FresnelColor;
				uniform half _Main;
				uniform half _MainAlpha;
				uniform half _MainContrast;
				uniform half _FresnelChanel;
				uniform half _VertexOffsetInt;
				uniform int _DissolveColType;

				struct VertexInput {
					float4 vertex : POSITION;
					float3 normal : NORMAL;
					float2 texcoord0 : TEXCOORD0;
					float4 texcoord1 : TEXCOORD1;
					float4 vertexColor : COLOR;
				};
				struct VertexOutput {
					float4 pos : SV_POSITION;
					float2 uv0 : TEXCOORD0;
					float4 uv1 : TEXCOORD1;
					float4 posWorld : TEXCOORD2;
					float3 normalDir : TEXCOORD3;
					float4 vertexColor : COLOR;
				};
				VertexOutput vert(VertexInput v) {
					VertexOutput o = (VertexOutput)0;
					o.uv0 = v.texcoord0;
					o.uv1 = v.texcoord1;
					o.vertexColor = v.vertexColor;
					o.normalDir = UnityObjectToWorldNormal(v.normal);
					//顶点偏移
					#if defined(_VERTEXOFFSET_ON) && defined(_NOISE_ON)
					fixed2 VOPolarUVRamp = o.uv0 * 2.0 + -1.0;
					fixed2 VOPolarCoord = float2(((atan2(VOPolarUVRamp.r,VOPolarUVRamp.g) / UNITY_TWO_PI) + 0.5),length(VOPolarUVRamp));
					fixed2 VOSpeed = _Time.g * _NoiseSpeed.xy;
					fixed4 _VO_var = tex2Dlod(_NoiseTex,fixed4(TRANSFORM_TEX((VOPolarCoord + VOSpeed), _NoiseTex),0.0,0));
					v.vertex.xyz += (_VO_var.rgb * v.normal * (lerp(_VertexOffsetInt,o.uv1.w,_CVS_V)));
					#endif
					o.posWorld = mul(unity_ObjectToWorld, v.vertex);
					o.pos = UnityObjectToClipPos(v.vertex);
					return o;
				}
				float4 frag(VertexOutput i, float facing : VFACE) : COLOR
				{
					half isFrontFace = (facing >= 0 ? 1 : 0);
					half faceSign = (facing >= 0 ? 1 : -1);
					half DisInt;
					half Dissolve;
					half DissolveRange;
					half DissolveEdge;
					fixed3 EdgeColor;
					half EdgeAlpha;
					i.normalDir = normalize(i.normalDir);
					i.normalDir *= faceSign;
					fixed3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
					fixed3 normalDirection = i.normalDir;
					fixed3 viewReflectDirection = reflect(-viewDirection, normalDirection);
					////// Lighting:
					////// Emissive:
					//极坐标UV
					#if defined(_MAIN_ON) || defined(_MASK_ON) || defined(_NOISE_ON)
					fixed2 PolarUVRamp = i.uv0 * 2.0 + -1.0;
					fixed2 PolarCoord = fixed2(((atan2(PolarUVRamp.r,PolarUVRamp.g) / UNITY_TWO_PI) + 0.5),length(PolarUVRamp));
					#endif
					//溶解?
					#if defined(_DISSOLVETOGGLE_ON)
					half SmoothStepMax = (_DissolveStep * 0.5 + 0.5);
					half SmoothStepMin = (1.0 - SmoothStepMax);
					#endif
					//遮罩图
					#if defined(_MASK_ON)                       
					fixed2 MaskUVPolar = _MaskPolarCoord == 1 ? PolarCoord : i.uv0;
					fixed2 MaskUV = lerp(fixed2(_Time.g * _MaskSpeed.xy), i.uv1.xy, _CVS_UV2) + MaskUVPolar;
					fixed4 _MaskTex_var = tex2D(_MaskTex,TRANSFORM_TEX(MaskUV , _MaskTex));
					fixed4 MaskColor = fixed4(_MaskTex_var.rgb,saturate(_MaskTex_var.a - _MaskAlphaCut)) * _Intensity.y * _Tex02Color * i.vertexColor.a;
					#endif
					//噪波图
					#if defined(_NOISE_ON)                   
						fixed2 NoiseUVPolar = _NoisePolarCoord == 1 ? PolarCoord : i.uv0;
						fixed4 _NoiseTex_var = tex2D(_NoiseTex,TRANSFORM_TEX((NoiseUVPolar + fixed2(_Time.g * _NoiseSpeed.xy)), _NoiseTex));
						fixed2 NoiseInt = (_NoiseTex_var.rg * _NoiseInt);
						//遮罩==>噪波
						#if defined(_MASK_ON)
						half NoiseMask = _NoiseMask == 1 ? MaskColor.a : 1;
						NoiseInt *= NoiseMask;
						#endif
					#endif
					//主贴图
					#if defined(_MAIN_ON)               
					fixed2 MainUVPolar = _MainPolarCoord == 1 ? PolarCoord : i.uv0;
					fixed2 MainUV = lerp(fixed2(_Time.g * _MainSpeed.xy), i.uv1.xy, _CVS_UV) + MainUVPolar;
					fixed4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(MainUV , _MainTex));
					fixed4 MainColor = _Intensity.x * _TintColor * i.vertexColor;
					//遮罩==>主贴图
					#if defined(_MASK_ON)                       
					half MainMask = _AlphaMask == 1|| _AlphaMask1 == 1 ? MaskColor.a : 1;
					MainColor=lerp(MainColor,MainColor*MainMask,_AlphaMask);
					MainColor.a=lerp(MainColor.a,MainColor.a*MainMask,_AlphaMask1);
					#endif
					//噪波==>主贴图
					#if defined(_NOISE_ON)
					MainUV += NoiseInt;
					_MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(MainUV , _MainTex));
					#endif
					//主贴图alpha通道开关
					_MainTex_var.a = _MainAlpha == 1 ? _MainTex_var.a : 1;
					//主贴图色调偏离
					#if defined(_COLOROFFSET_ON)                
					fixed4 Mainoffset_R = tex2D(_MainTex,TRANSFORM_TEX((MainUV + _Mainoffset.xx), _MainTex));
					fixed4 Mainoffset_B = tex2D(_MainTex,TRANSFORM_TEX((MainUV - _Mainoffset.xx), _MainTex));
					_MainTex_var = fixed4(Mainoffset_R.r, _MainTex_var.g, Mainoffset_B.b, _MainTex_var.a);
					#endif
					fixed4 finalMain = fixed4(_MainTex_var.rgb,saturate(_MainTex_var.a - _MainAlphaCut)) * MainColor;
					//遮罩==>纹理2
					#if defined(_MASK_ON)
					fixed3 Tex02 = _Texture02 == 1 ? MaskColor.rgb : 0;
					half Tex02Alpha = _MainMask == 1 ? 0 : MaskColor.a;
					finalMain = fixed4((finalMain.rgb + Tex02 * MaskColor.a),(finalMain.a + Tex02Alpha));
					#endif
					//噪波==>全局遮罩
					#if defined(_NOISE_ON)
					half Mask02 = _Mask02 == 1 ? _NoiseTex_var.a : 1;
					finalMain *= Mask02;
					#endif
					//幂开关
					#if defined(_CONTRASTTOGGLE_ON)
					finalMain = pow(finalMain,_MainContrast);
					#endif
					//溶解==>主效果
					#if defined(_DISSOLVETOGGLE_ON)
					//溶解纹理
					#if defined(_NOISE_ON)
					half MainDissolveTex = _DissolveTex == 1 ? _NoiseTex_var.r : _MainTex_var.a;
					#else
					half MainDissolveTex = _MainTex_var.a;
					#endif
					DisInt = MainDissolveTex + ((lerp(_DissolveInt,i.uv1.b,_CVS_Z)) * -1.1 + 0.55);
					Dissolve = smoothstep(SmoothStepMin, SmoothStepMax, saturate(DisInt));
					DissolveRange = smoothstep(SmoothStepMin, SmoothStepMax, saturate((DisInt + (_DissolveEdge * 0.2 + 0.0))));
					DissolveEdge = (DissolveRange - Dissolve);
					if(_DissolveColType == 1)
					{
						EdgeColor = lerp(_EdgeColor1,_EdgeColor2,MainDissolveTex - _DissolveInt) * DissolveEdge * _Intensity.z;
					    EdgeAlpha = DissolveEdge * i.vertexColor.a * _Intensity.z;
					    //finalMain = float4(finalMain.rgb * Dissolve + EdgeColor,finalMain.a * (Dissolve + EdgeAlpha));
					    half t = 1 - smoothstep(0.0,_DissolveEdge,1 - i.uv1.b - 0.15);
					    fixed3 explsionCol = lerp(_EdgeColor1,_EdgeColor2,t);
					    //fixed3 explsionCol = step(0.5,t) < 0 ? _EdgeColor1 : _EdgeColor2;
					    finalMain = fixed4(lerp(finalMain,explsionCol,t * step(0.0001,i.uv1.b)),finalMain.a * (Dissolve + EdgeAlpha));
					}
					else
					{
						EdgeColor = _EdgeColor1 * DissolveEdge * _Intensity.z;
					    EdgeAlpha = DissolveEdge * i.vertexColor.a * _Intensity.z;
					    finalMain = fixed4(finalMain.rgb * Dissolve + EdgeColor,finalMain.a * (Dissolve + EdgeAlpha));
					}
					#endif
					#endif
					//菲涅尔
					#if defined(_FRESNEL_ON)                            
					half FresnelAlpha = pow(1.0 - max(0,dot(normalDirection, viewDirection)),lerp(_Exp,i.uv1.a,_CVS_W));
					fixed4 finalFres = i.vertexColor * _FresnelColor * FresnelAlpha * _Intensity.w;
					//遮罩==>菲涅尔
					#if defined(_MASK_ON)
						half FresMask = _AlphaMask == 1 ? MaskColor.a : 1;
						finalFres *= FresMask;
					#endif
					//溶解==>菲涅尔
					#if defined(_DISSOLVETOGGLE_ON)
					half FresDissolveTex = 0;
					//溶解纹理
					#if defined(_MAIN_ON)
					FresDissolveTex = MainDissolveTex;
					#endif
					#if !defined(_MAIN_ON) && defined(_NOISE_ON)
					FresDissolveTex = _NoiseTex_var.a;
					#endif
				    DisInt = FresDissolveTex + ((lerp(_DissolveInt,i.uv1.b,_CVS_Z)) * -1.1 + 0.55);
				    Dissolve = smoothstep(SmoothStepMin, SmoothStepMax, saturate(DisInt));
				    DissolveRange = smoothstep(SmoothStepMin, SmoothStepMax, saturate((DisInt + (_DissolveEdge * 0.2 + 0.0))));
					DissolveEdge = (DissolveRange - Dissolve);
					EdgeColor = _EdgeColor1 * DissolveEdge * _Intensity.z;
					EdgeAlpha = DissolveEdge * i.vertexColor.a * _Intensity.z;
					finalFres = fixed4(finalFres.rgb * Dissolve + EdgeColor,finalFres.a * (Dissolve + EdgeAlpha));
					#endif
					#endif
					fixed4 finalEffect = 0;
					#if defined(_MAIN_ON) && !defined(_FRESNEL_ON)
					finalEffect = finalMain;
					#endif
					#if defined(_FRESNEL_ON) && !defined(_MAIN_ON)
					finalEffect = finalFres;
					#endif
					#if defined(_MAIN_ON) && (_FRESNEL_ON)
					finalMain.a = _FresnelChanel == 1 ? 0 : finalMain.a;
					finalEffect = fixed4(finalMain.rgb + finalFres.rgb,finalMain.a + finalFres.a);
					#endif
					return finalEffect;
				}
			ENDCG
		}
	}
}


