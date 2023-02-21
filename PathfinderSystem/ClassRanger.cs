using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public sealed class ClassRanger
    {
        public static readonly List<FavoredTerrain> favoredTerrains = new List<FavoredTerrain>(new FavoredTerrain[]
        {
            new FavoredTerrain("Cold", "within glaciers, snow, and tundra terrain"),
            new FavoredTerrain("Desert", "within sand and wasteland terrain"),
            new FavoredTerrain("Forest", "in coniferous and deciduous forests"),
            new FavoredTerrain("Jungle", "in jungles"),
            new FavoredTerrain("Mountain", "in mountains and hills"),
            new FavoredTerrain("Plains", "in plains"),
            new FavoredTerrain("Planes", "on a specific plane other than the Material Plane"),
            new FavoredTerrain("Swamp", "in swamps"),
            new FavoredTerrain("Underground", "in caves and dungeons"),
            new FavoredTerrain("Urban", "in buildings, streets, and sewers"),
            new FavoredTerrain("Water", "on or below the surface of water"),
        });

        public sealed class FavoredTerrain
        {
            private string nameInternal;
            public string name
            {
                get
                {
                    return nameInternal;
                }
            }
            private string sentenceInternal;
            public string sentenceText
            {
                get
                {
                    return sentenceInternal;
                }
            }

            public FavoredTerrain(string myName, string mySentenceText)
            {
                nameInternal = myName;
                sentenceInternal = mySentenceText;
            }

            public static FavoredTerrain Get(string typeName)
            {
                return ClassRanger.favoredTerrains.Find(curTerrain => curTerrain.name == typeName);
            }
        }
    }
}
