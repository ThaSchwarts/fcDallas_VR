using UnityEngine;
using System.Collections;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Media.AVProVideo
{
	[AddComponentMenu("AVPro Video/Apply To Mesh")]
	public class ApplyToMesh : MonoBehaviour 
	{
		public MeshRenderer _mesh;
		public MediaPlayer _media;
		public Texture2D _defaultTexture;

		void Update()
		{
			bool applied = false;
			if (_media != null && _media.TextureProducer != null)
			{
				Texture texture = _media.TextureProducer.GetTexture();
				if (texture != null)
				{
					ApplyMapping(texture, _media.TextureProducer.RequiresVerticalFlip());
					applied = true;
				}
			}

			if (!applied)
			{
				ApplyMapping(_defaultTexture, false);
			}
		}
		
		private void ApplyMapping(Texture texture, bool requiresYFlip)
		{
			if (_mesh != null)
			{
				for (int i = 0; i < _mesh.materials.Length; i++)
				{
					Material mat = _mesh.materials[i];
					mat.mainTexture = texture;

					if (requiresYFlip)
					{
						if (texture.wrapMode == TextureWrapMode.Repeat)
						{
							mat.mainTextureScale = new Vector2(mat.mainTextureScale.x, -mat.mainTextureScale.x);		// NOTE: we use x value for y to prevent negation flip-flop
						}
						else
						{
							mat.mainTextureScale = new Vector2(1.0f, -1.0f);
							mat.mainTextureOffset = Vector2.up;
						}
					}

					// Apply changes for stereo videos
					if (mat.shader.name == "Unlit/InsideSphere")
					{
						Helper.SetupStereoMaterial(mat, _media.m_StereoPacking, _media.m_DisplayDebugStereoColorTint);
					}
				}
			}
		}

		void OnEnable()
		{
			if (_mesh == null)
			{
				_mesh = this.GetComponent<MeshRenderer>();
				if (_mesh == null)
				{
					Debug.LogWarning("[AVProVideo] No mesh renderer set or found in gameobject");
				}
			}
			
			if (_mesh != null)
			{
				Update();
			}
		}
		
		void OnDisable()
		{
			ApplyMapping(_defaultTexture, false);
		}
	}
}