using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace AgOpenGPS.Visuals
{
    public class SectionsVisual
    {
        public static void DrawSections(List<CPatches> triStrip)
        {
            int cnt, step, patchCount;
            int mipmap = 8;

            GL.Color3(0.9f, 0.9f, 0.8f);

            //draw patches j= # of sections
            for (int j = 0; j < triStrip.Count; j++)
            {
                //every time the section turns off and on is a new patch
                patchCount = triStrip[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (System.Collections.Generic.List<vec3> triList in triStrip[j].patchList)
                    {
                        //draw the triangle in each triangle strip
                        GL.Begin(PrimitiveType.TriangleStrip);
                        cnt = triList.Count;

                        //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                        if (cnt >= (mipmap))
                        {
                            step = mipmap;
                            for (int i = 1; i < cnt; i += step)
                            {
                                GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;

                                //too small to mipmap it
                                if (cnt - i <= (mipmap + 2))
                                    step = 0;
                            }
                        }
                        else { for (int i = 1; i < cnt; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0); }
                        GL.End();
                    }
                }
            } //end of section patches
        }
    }
}
