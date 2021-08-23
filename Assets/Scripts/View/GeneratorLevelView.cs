using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerMVC.View
{
    public class GeneratorLevelView: MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _groundTile;
        [SerializeField] private int _mapWidth;
        [SerializeField] private int _mapHeight;
        [SerializeField] private bool _borders;
        [SerializeField][Range(0, 100)]private int _factorSmooth;
        [SerializeField][Range(0, 100)] private int _fillPercent;
        
        public Tilemap tilemap { get => _tilemap; set => _tilemap = value; }
        public Tile groundTile { get => _groundTile; set => _groundTile = value; }
        public int mapWidth { get => _mapWidth; set => _mapWidth = value; }
        public int mapHeight { get => _mapHeight; set => _mapHeight = value; }
        public bool borders { get => _borders; set => _borders = value; }
        public int factorSmooth { get => _factorSmooth; set => _factorSmooth = value; }
        public int fillPercent { get => _fillPercent; set => _fillPercent = value; }


    }
}