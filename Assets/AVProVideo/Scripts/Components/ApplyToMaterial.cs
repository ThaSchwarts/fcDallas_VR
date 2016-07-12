using UnityEngine;
using System.Collections;

//-----------------------------------------------------------------------------
// Copyright 2015-2016 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

namespace RenderHeads.Media.AVProVideo
{
	[AddComponentMenu("AVPro Video/Apply To Material")]
	public class ApplyToMaterial : MonoBehaviour 
	{
		public Material _material;
		public string _texturePropertyName;
		public MediaPlayer _media;
		public Texture2D _defaultTexture;

		private Texture _originalTexture;
		private Vector2 _scale = Vector2.one;

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
			if (_material != null)
			{
				if (string.IsNullOrEmpty(_texturePropertyName))
				{
					_material.mainTexture = texture;

					if (requiresYFlip)
					{
						if (texture.wrapMode == TextureWrapMode.Repeat)
						{
							_material.mainTextureScale = new Vector2(_scale.x, -_scale.y);
						}
						else
						{
							_material.mainTextureScale = new Vector2(1f, -1f);
							_material.mainTextureOffset = new Vector2(0.0f, 1.0f);
						}
					}
				}
				else
				{
					_material.SetTexture(_texturePropertyName, texture);

					if (requiresYFlip)
					{
						if (texture.wrapMode == TextureWrapMode.Repeat)
						{
							_material.SetTextureScale(_texturePropertyName, new Vector2(_scale.x, -_scale.y));
						}
						else
						{
							_material.SetTextureScale(_texturePropertyName, new Vector2(1f, -1f));
							_material.SetTextureOffset(_texturePropertyName, new Vector2(0.0f, 1.0f));
						}
					}
				}

				// Apply changes for stereo videos
				if (_material.shader.name == "Unlit/InsideSphere")
				{
					Helper.SetupStereoMaterial(_material, _media.m_StereoPacking, _media.m_DisplayDebugStereoColorTint);
				}
			}
		}

		void OnEnable()
		{
			if (string.IsNullOrEmpty(_texturePropertyName))
			{
				_originalTexture = _material.mainTexture;
				_scale = _material.mainTextureScale;
			}
			else
			{
				_originalTexture = _material.GetTexture(_texturePropertyName);
				_scale = _material.GetTextureScale(_texturePropertyName);
			}

			Update();
		}
		
		void OnDisable()
		{
			if (string.IsNullOrEmpty(_texturePropertyName))
			{
				_material.mainTexture = _originalTexture;
				_material.mainTextureScale = _scale;
			}
			else
			{
				_material.SetTexture(_texturePropertyName, _originalTexture);
				_material.SetTextureScale(_texturePropertyName, _scale);
			}
		}
	}
}