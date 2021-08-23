using PlatformerMVC.View;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;
using Random = System.Random;

namespace PlatformerMVC.Controllers
{
    public class GeneratorController
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _mapWidth;
        private int _mapHeight;
        private bool _borders;
        
        private const int CountWall = 4;
        private int _factorSmooth;
        private int _fillPercent;
        private int[,] _map;
        
                
        public GeneratorController(GeneratorLevelView generatorLevelView)
        {
            _tilemap = generatorLevelView.tilemap;
            _groundTile = generatorLevelView.groundTile;
            _mapWidth = generatorLevelView.mapWidth;
            _mapHeight = generatorLevelView.mapHeight;
            _borders = generatorLevelView.borders;
            _factorSmooth = generatorLevelView.factorSmooth;
            _fillPercent = generatorLevelView.fillPercent;
            _map = new int[_mapWidth, _mapHeight];
        }

        public void Init()
        {
            RandomFillMap();
            for (int i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();   
            }

            DrawTiles();
        }

        private void RandomFillMap()
        {
            Random rand = new Random();
            for (int i = 0; i < _mapWidth; i++)
            {
                for (int j = 0; j < _mapHeight; j++)
                {
                    if (i == 0 || i == _mapWidth - 1 || j == 0 || j == _mapHeight - 1)
                    {
                        if(_borders) _map[i, j] = 1;
                    }
                    else
                    {
                        _map[i, j] = (rand.Next(0, 100) < _fillPercent) ? 1 : 0;
                    }
                }
            }
        }

        private void SmoothMap()
        {
            for (int i = 0; i < _mapWidth; i++)
            {
                for (int j = 0; j < _mapHeight; j++)
                {
                   int neighbourWalls =  GetWallCount(i, j);
                   if (neighbourWalls > CountWall)
                   {
                       _map[i, j] = 1;
                   } else if (neighbourWalls < CountWall)
                   {
                       _map[i, j] = 0;
                   }
                }
            }
        }

        private int GetWallCount(int x, int y)
        {
            int wallCount = 0;

            for (int i = x-1; i <= x+1; i++)
            {
                for (int j = y-1; j <= y+1; j++)
                {
                    if (i >= 0 && i < _mapWidth && j >= 0 && j < _mapHeight)
                    {
                        if (i != x || j != y)
                        {
                            wallCount += _map[i, j];
                        }
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }

        private void DrawTiles()
        {
            if (_map == null)
                return;

            for (int i = 0; i < _mapWidth; i++)
            {
                for (int j = 0; j < _mapHeight; j++)
                {
                    var positionTile = new Vector3Int(-_mapWidth/2 + i, -_mapHeight/2+j, 0);
                    if (_map[i, j] == 1)
                    {
                        _tilemap.SetTile(positionTile, _groundTile);
                    }
                }
            }
        }
    }
}