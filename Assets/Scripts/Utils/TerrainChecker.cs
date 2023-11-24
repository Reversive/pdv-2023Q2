using UnityEngine;

public class TerrainChecker
{
    private float[] GetTextureMix(Vector3 playerPos, Terrain t)
    {
        Vector3 tPos = t.transform.position;
        TerrainData tData = t.terrainData;
        int mapX = (int)((playerPos.x - tPos.x) / tData.size.x * tData.alphamapWidth);
        int mapZ = (int)((playerPos.z - tPos.z) / tData.size.z * tData.alphamapHeight);
        float[,,] splatmapData = tData.GetAlphamaps(mapX, mapZ, 1, 1);
        float[] cellMix = new float[splatmapData.GetUpperBound(2) + 1];
        for (int n = 0; n < cellMix.Length; ++n)
        {
            cellMix[n] = splatmapData[0, 0, n];
        }
        return cellMix;
    }

    public string GetLayerName(Vector3 playerPos, Terrain t)
    {
        float[] cellMix = GetTextureMix(playerPos, t);
        int maxIndex = 0;
        float strongest = 0;
        for (int n = 0; n < cellMix.Length; ++n)
        {
            if (cellMix[n] > strongest)
            {
                maxIndex = n;
                strongest = cellMix[n];
            }
        }
        return t.terrainData.terrainLayers[maxIndex].name;
    }
}
