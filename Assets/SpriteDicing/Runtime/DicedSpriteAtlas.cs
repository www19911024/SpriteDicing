﻿using System.Collections.Generic;
using UnityEngine;

namespace SpriteDicing
{
    /// <summary>
    /// Stores diced sprites data and associated atlas textures.
    /// </summary>
    [CreateAssetMenu(menuName = "Diced Sprite Atlas", order = 350)]
    public class DicedSpriteAtlas : ScriptableObject
    {
        /// <summary>
        /// Number of sprites stored in this atlas.
        /// </summary>
        public int SpritesCount => sprites.Count;
        /// <summary>
        /// Number of textures used by this atlas.
        /// </summary>
        public int TexturesCount => textures.Count;

        [SerializeField] private List<Texture2D> textures = new List<Texture2D>();
        [SerializeField] private List<Sprite> sprites = new List<Sprite>();

        #if UNITY_EDITOR
        // Editor-only data to track source sprite textures and store build configuration.
        // Disabled warnings are about "unused" variables (used by the editor scripts via reflection).
        #pragma warning disable 0169, 0414, 1635, IDE0052
        [SerializeField] private int atlasSizeLimit = 2048;
        [SerializeField] private bool forceSquare = false;
        [SerializeField] private float pixelsPerUnit = 100f;
        [SerializeField] private int diceUnitSize = 64;
        [SerializeField] private int padding = 2;
        [SerializeField] private Vector2 defaultPivot = new Vector2(.5f, .5f);
        [SerializeField] private bool keepOriginalPivot;
        [SerializeField] private bool decoupleSpriteData;
        [SerializeField] private Object inputFolder;
        [SerializeField] private bool includeSubfolders;
        [SerializeField] private bool prependSubfolderNames;
        [HideInInspector]
        [SerializeField] private string generatedSpritesFolderGuid;
        #pragma warning restore 0169, 0414, 1635, IDE0052
        #endif

        /// <summary>
        /// Retrieves a generated sprite with the provided name.
        /// </summary>
        /// <param name="spriteName">Name of the sprite to retrieve.</param>
        /// <returns>Diced sprite data or null if not found.</returns>
        public Sprite GetSprite (string spriteName) => sprites.Find(sprite => sprite.name.Equals(spriteName));
    }
}
