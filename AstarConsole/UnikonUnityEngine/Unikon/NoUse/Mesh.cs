using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace UnityEngine
{
	public sealed class Mesh : Object
	{
		internal enum InternalShaderChannel
		{
			Vertex,
			Normal,
			Color,
			TexCoord0,
			TexCoord1,
			TexCoord2,
			TexCoord3,
			Tangent
		}

		internal enum InternalVertexChannelType
		{
			Float,
			Color = 2
		}

		public bool isReadable
		{
			get;
		}

		internal bool canAccess
		{
			get;
		}

		public int blendShapeCount
		{
			get;
		}

		public int vertexBufferCount
		{
			get;
		}

        public Bounds bounds;

		public int vertexCount
		{
			get;
		}

		public int subMeshCount
		{
			get;
			set;
		}

		public BoneWeight[] boneWeights
		{
			get;
			set;
		}

		public Matrix4x4[] bindposes
		{
			get;
			set;
		}
public Vector2[] uv1
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3[] vertices
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector3>(Mesh.InternalShaderChannel.Vertex);
			}
			set
			{
				this.SetArrayForChannel<Vector3>(Mesh.InternalShaderChannel.Vertex, value);
			}
		}

		public Vector3[] normals
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector3>(Mesh.InternalShaderChannel.Normal);
			}
			set
			{
				this.SetArrayForChannel<Vector3>(Mesh.InternalShaderChannel.Normal, value);
			}
		}

		public Vector4[] tangents
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector4>(Mesh.InternalShaderChannel.Tangent);
			}
			set
			{
				this.SetArrayForChannel<Vector4>(Mesh.InternalShaderChannel.Tangent, value);
			}
		}

		public Vector2[] uv
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(Mesh.InternalShaderChannel.TexCoord0);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(Mesh.InternalShaderChannel.TexCoord0, value);
			}
		}

		public Vector2[] uv2
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(Mesh.InternalShaderChannel.TexCoord1);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(Mesh.InternalShaderChannel.TexCoord1, value);
			}
		}

		public Vector2[] uv3
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(Mesh.InternalShaderChannel.TexCoord2);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(Mesh.InternalShaderChannel.TexCoord2, value);
			}
		}

		public Vector2[] uv4
		{
			get
			{
				return this.GetAllocArrayFromChannel<Vector2>(Mesh.InternalShaderChannel.TexCoord3);
			}
			set
			{
				this.SetArrayForChannel<Vector2>(Mesh.InternalShaderChannel.TexCoord3, value);
			}
		}

		public Color[] colors
		{
			get
			{
				return this.GetAllocArrayFromChannel<Color>(Mesh.InternalShaderChannel.Color);
			}
			set
			{
				this.SetArrayForChannel<Color>(Mesh.InternalShaderChannel.Color, value);
			}
		}

		public Color32[] colors32
		{
			get
			{
				return this.GetAllocArrayFromChannel<Color32>(Mesh.InternalShaderChannel.Color, Mesh.InternalVertexChannelType.Color, 1);
			}
			set
			{
				this.SetArrayForChannel<Color32>(Mesh.InternalShaderChannel.Color, Mesh.InternalVertexChannelType.Color, 1, value);
			}
		}

		public int[] triangles
		{
			get
			{
				int[] result;
				if (this.canAccess)
				{
					result = this.GetTrianglesImpl(-1);
				}
				else
				{
					this.PrintErrorCantAccessMeshForIndices();
					result = new int[0];
				}
				return result;
			}
			set
			{
				if (this.canAccess)
				{
					this.SetTrianglesImpl(-1, value, this.SafeLength(value));
				}
				else
				{
					this.PrintErrorCantAccessMeshForIndices();
				}
			}
		}

		public Mesh()
		{
			Mesh.Internal_Create(this);
		}

        private static void Internal_Create([Writable] Mesh mono) { }

        public void Clear([UnityEngine.Internal.DefaultValue("true")] bool keepVertexLayout) { }

		public void Clear()
		{
			bool keepVertexLayout = true;
			this.Clear(keepVertexLayout);
		}

        internal void PrintErrorCantAccessMesh(Mesh.InternalShaderChannel channel) { }

        internal  void PrintErrorCantAccessMeshForIndices() { }

        internal void PrintErrorBadSubmeshIndexTriangles() { }

		internal  void PrintErrorBadSubmeshIndexIndices() { }

        private void SetArrayForChannelImpl(Mesh.InternalShaderChannel channel, Mesh.InternalVertexChannelType format, int dim, Array values, int arraySize) { }

				private Array GetAllocArrayFromChannelImpl(Mesh.InternalShaderChannel channel, Mesh.InternalVertexChannelType format, int dim) 
{
            return null;
}

				private void GetArrayFromChannelImpl(Mesh.InternalShaderChannel channel, Mesh.InternalVertexChannelType format, int dim, Array values) 
{
            
}

				internal bool HasChannel(Mesh.InternalShaderChannel channel) 
{
            return false;
}

				private static void ResizeList(object list, int size) 
{
}

				private static Array ExtractArrayFromList(object list) 
{
            return null;
}

				private int[] GetTrianglesImpl(int submesh) 
{
            return new int[] { };
}

				private void GetTrianglesNonAllocImpl(object values, int submesh) 
{

}

				private int[] GetIndicesImpl(int submesh) 
{
            return new int[] { };
        }

				private void GetIndicesNonAllocImpl(object values, int submesh) 
{

}

				private void SetTrianglesImpl(int submesh, Array triangles, int arraySize, [UnityEngine.Internal.DefaultValue("true")] bool calculateBounds) 
{

}

		private void SetTrianglesImpl(int submesh, Array triangles, int arraySize)
		{
			bool calculateBounds = true;
			this.SetTrianglesImpl(submesh, triangles, arraySize, calculateBounds);
		}

				private void SetIndicesImpl(int submesh, MeshTopology topology, Array indices, int arraySize, [UnityEngine.Internal.DefaultValue("true")] bool calculateBounds) 
{

}

		
		private void SetIndicesImpl(int submesh, MeshTopology topology, Array indices, int arraySize)
		{
			bool calculateBounds = true;
			this.SetIndicesImpl(submesh, topology, indices, arraySize, calculateBounds);
		}

		
		public void SetTriangles(int[] triangles, int submesh)
		{
			bool calculateBounds = true;
			this.SetTriangles(triangles, submesh, calculateBounds);
		}

		public void SetTriangles(int[] triangles, int submesh, [UnityEngine.Internal.DefaultValue("true")] bool calculateBounds)
		{
			if (this.CheckCanAccessSubmeshTriangles(submesh))
			{
				this.SetTrianglesImpl(submesh, triangles, this.SafeLength(triangles), calculateBounds);
			}
		}

		
		public void SetTriangles(List<int> triangles, int submesh)
		{
			bool calculateBounds = true;
			this.SetTriangles(triangles, submesh, calculateBounds);
		}

		public void SetTriangles(List<int> triangles, int submesh, [UnityEngine.Internal.DefaultValue("true")] bool calculateBounds)
		{
			if (this.CheckCanAccessSubmeshTriangles(submesh))
			{
				this.SetTrianglesImpl(submesh, Mesh.ExtractArrayFromList(triangles), this.SafeLength<int>(triangles), calculateBounds);
			}
		}

		
		public void SetIndices(int[] indices, MeshTopology topology, int submesh)
		{
			bool calculateBounds = true;
			this.SetIndices(indices, topology, submesh, calculateBounds);
		}

		public void SetIndices(int[] indices, MeshTopology topology, int submesh, [UnityEngine.Internal.DefaultValue("true")] bool calculateBounds)
		{
			if (this.CheckCanAccessSubmeshIndices(submesh))
			{
				this.SetIndicesImpl(submesh, topology, indices, this.SafeLength(indices), calculateBounds);
			}
		}

				public void ClearBlendShapes() 
{

}

				public string GetBlendShapeName(int shapeIndex) 
{
            return string.Empty;
}

				public int GetBlendShapeFrameCount(int shapeIndex) 
{
            return 0;
}

				public float GetBlendShapeFrameWeight(int shapeIndex, int frameIndex) 
{
            return 0;
}

				public void GetBlendShapeFrameVertices(int shapeIndex, int frameIndex, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents) 
{

}

				public void AddBlendShapeFrame(string shapeName, float frameWeight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents) 
{

}

		public IntPtr GetNativeVertexBufferPtr(int bufferIndex)
		{
			IntPtr result;
			Mesh.INTERNAL_CALL_GetNativeVertexBufferPtr(this, bufferIndex, out result);
			return result;
		}

				private static void INTERNAL_CALL_GetNativeVertexBufferPtr(Mesh self, int bufferIndex, out IntPtr value) 
{
            value = IntPtr.Zero;
}

		public IntPtr GetNativeIndexBufferPtr()
		{
            return IntPtr.Zero ;
		}



        
        private void INTERNAL_set_bounds(ref Bounds value) { }

        
        public void RecalculateBounds() { }

        
        public void RecalculateNormals() { }

        
        public  void RecalculateTangents() { }

        public void Optimize() { }

				public  MeshTopology GetTopology(int submesh) 
{
            return default(MeshTopology);
}

				public  uint GetIndexStart(int submesh) 
{
            return 0;
}

				public  uint GetIndexCount(int submesh) 
{

            return 0;
        }

				public void CombineMeshes(CombineInstance[] combine, [UnityEngine.Internal.DefaultValue("true")] bool mergeSubMeshes, [UnityEngine.Internal.DefaultValue("true")] bool useMatrices, [UnityEngine.Internal.DefaultValue("false")] bool hasLightmapData) 
{

}

		
		public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices)
		{
			bool hasLightmapData = false;
			this.CombineMeshes(combine, mergeSubMeshes, useMatrices, hasLightmapData);
		}

		
		public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes)
		{
			bool hasLightmapData = false;
			bool useMatrices = true;
			this.CombineMeshes(combine, mergeSubMeshes, useMatrices, hasLightmapData);
		}

		
		public void CombineMeshes(CombineInstance[] combine)
		{
			bool hasLightmapData = false;
			bool useMatrices = true;
			bool mergeSubMeshes = true;
			this.CombineMeshes(combine, mergeSubMeshes, useMatrices, hasLightmapData);
		}

				private void GetBoneWeightsNonAllocImpl(object values) 
{

}

				private int GetBindposeCount() 
{
            return 1;
}

				private void GetBindposesNonAllocImpl(object values) 
{

}

				public void MarkDynamic() 
{

}

				public void UploadMeshData(bool markNoLogerReadable) 
{

}

				public int GetBlendShapeIndex(string blendShapeName) 
{
            return 1;
}

		internal Mesh.InternalShaderChannel GetUVChannel(int uvIndex)
		{
			if (uvIndex < 0 || uvIndex > 3)
			{
				throw new ArgumentException("GetUVChannel called for bad uvIndex", "uvIndex");
			}
			return Mesh.InternalShaderChannel.TexCoord0 + uvIndex;
		}

		internal static int DefaultDimensionForChannel(Mesh.InternalShaderChannel channel)
		{
			int result;
			if (channel == Mesh.InternalShaderChannel.Vertex || channel == Mesh.InternalShaderChannel.Normal)
			{
				result = 3;
			}
			else if (channel >= Mesh.InternalShaderChannel.TexCoord0 && channel <= Mesh.InternalShaderChannel.TexCoord3)
			{
				result = 2;
			}
			else
			{
				if (channel != Mesh.InternalShaderChannel.Tangent && channel != Mesh.InternalShaderChannel.Color)
				{
					throw new ArgumentException("DefaultDimensionForChannel called for bad channel", "channel");
				}
				result = 4;
			}
			return result;
		}

		private T[] GetAllocArrayFromChannel<T>(Mesh.InternalShaderChannel channel, Mesh.InternalVertexChannelType format, int dim)
		{
			T[] result;
			if (this.canAccess)
			{
				if (this.HasChannel(channel))
				{
					result = (T[])this.GetAllocArrayFromChannelImpl(channel, format, dim);
					return result;
				}
			}
			else
			{
				this.PrintErrorCantAccessMesh(channel);
			}
			result = new T[0];
			return result;
		}

		private T[] GetAllocArrayFromChannel<T>(Mesh.InternalShaderChannel channel)
		{
			return this.GetAllocArrayFromChannel<T>(channel, Mesh.InternalVertexChannelType.Float, Mesh.DefaultDimensionForChannel(channel));
		}

		private int SafeLength(Array values)
		{
			return (values == null) ? 0 : values.Length;
		}

		private int SafeLength<T>(List<T> values)
		{
			return (values == null) ? 0 : values.Count;
		}

		private void SetSizedArrayForChannel(Mesh.InternalShaderChannel channel, Mesh.InternalVertexChannelType format, int dim, Array values, int valuesCount)
		{
			if (this.canAccess)
			{
				this.SetArrayForChannelImpl(channel, format, dim, values, valuesCount);
			}
			else
			{
				this.PrintErrorCantAccessMesh(channel);
			}
		}

		private void SetArrayForChannel<T>(Mesh.InternalShaderChannel channel, Mesh.InternalVertexChannelType format, int dim, T[] values)
		{
			this.SetSizedArrayForChannel(channel, format, dim, values, this.SafeLength(values));
		}

		private void SetArrayForChannel<T>(Mesh.InternalShaderChannel channel, T[] values)
		{
			this.SetSizedArrayForChannel(channel, Mesh.InternalVertexChannelType.Float, Mesh.DefaultDimensionForChannel(channel), values, this.SafeLength(values));
		}

		private void SetListForChannel<T>(Mesh.InternalShaderChannel channel, Mesh.InternalVertexChannelType format, int dim, List<T> values)
		{
			this.SetSizedArrayForChannel(channel, format, dim, Mesh.ExtractArrayFromList(values), this.SafeLength<T>(values));
		}

		private void SetListForChannel<T>(Mesh.InternalShaderChannel channel, List<T> values)
		{
			this.SetSizedArrayForChannel(channel, Mesh.InternalVertexChannelType.Float, Mesh.DefaultDimensionForChannel(channel), Mesh.ExtractArrayFromList(values), this.SafeLength<T>(values));
		}

		private void GetListForChannel<T>(List<T> buffer, int capacity, Mesh.InternalShaderChannel channel, int dim)
		{
			this.GetListForChannel<T>(buffer, capacity, channel, dim, Mesh.InternalVertexChannelType.Float);
		}

		private void GetListForChannel<T>(List<T> buffer, int capacity, Mesh.InternalShaderChannel channel, int dim, Mesh.InternalVertexChannelType channelType)
		{
			buffer.Clear();
			if (!this.canAccess)
			{
				this.PrintErrorCantAccessMesh(channel);
			}
			else if (this.HasChannel(channel))
			{
				this.PrepareUserBuffer<T>(buffer, capacity);
				this.GetArrayFromChannelImpl(channel, channelType, dim, Mesh.ExtractArrayFromList(buffer));
			}
		}

		private void PrepareUserBuffer<T>(List<T> buffer, int capacity)
		{
			buffer.Clear();
			if (buffer.Capacity < capacity)
			{
				buffer.Capacity = capacity;
			}
			Mesh.ResizeList(buffer, capacity);
		}

		public void GetVertices(List<Vector3> vertices)
		{
			if (vertices == null)
			{
				throw new ArgumentNullException("The result vertices list cannot be null.", "vertices");
			}
			this.GetListForChannel<Vector3>(vertices, this.vertexCount, Mesh.InternalShaderChannel.Vertex, Mesh.DefaultDimensionForChannel(Mesh.InternalShaderChannel.Vertex));
		}

		public void SetVertices(List<Vector3> inVertices)
		{
			this.SetListForChannel<Vector3>(Mesh.InternalShaderChannel.Vertex, inVertices);
		}

		public void GetNormals(List<Vector3> normals)
		{
			if (normals == null)
			{
				throw new ArgumentNullException("The result normals list cannot be null.", "normals");
			}
			this.GetListForChannel<Vector3>(normals, this.vertexCount, Mesh.InternalShaderChannel.Normal, Mesh.DefaultDimensionForChannel(Mesh.InternalShaderChannel.Normal));
		}

		public void SetNormals(List<Vector3> inNormals)
		{
			this.SetListForChannel<Vector3>(Mesh.InternalShaderChannel.Normal, inNormals);
		}

		public void GetTangents(List<Vector4> tangents)
		{
			if (tangents == null)
			{
				throw new ArgumentNullException("The result tangents list cannot be null.", "tangents");
			}
			this.GetListForChannel<Vector4>(tangents, this.vertexCount, Mesh.InternalShaderChannel.Tangent, Mesh.DefaultDimensionForChannel(Mesh.InternalShaderChannel.Tangent));
		}

		public void SetTangents(List<Vector4> inTangents)
		{
			this.SetListForChannel<Vector4>(Mesh.InternalShaderChannel.Tangent, inTangents);
		}

		public void GetColors(List<Color> colors)
		{
			if (colors == null)
			{
				throw new ArgumentNullException("The result colors list cannot be null.", "colors");
			}
			this.GetListForChannel<Color>(colors, this.vertexCount, Mesh.InternalShaderChannel.Color, Mesh.DefaultDimensionForChannel(Mesh.InternalShaderChannel.Color));
		}

		public void SetColors(List<Color> inColors)
		{
			this.SetListForChannel<Color>(Mesh.InternalShaderChannel.Color, inColors);
		}

		public void GetColors(List<Color32> colors)
		{
			if (colors == null)
			{
				throw new ArgumentNullException("The result colors list cannot be null.", "colors");
			}
			this.GetListForChannel<Color32>(colors, this.vertexCount, Mesh.InternalShaderChannel.Color, 1, Mesh.InternalVertexChannelType.Color);
		}

		public void SetColors(List<Color32> inColors)
		{
			this.SetListForChannel<Color32>(Mesh.InternalShaderChannel.Color, Mesh.InternalVertexChannelType.Color, 1, inColors);
		}

		private void SetUvsImpl<T>(int uvIndex, int dim, List<T> uvs)
		{
			if (uvIndex < 0 || uvIndex > 3)
			{
				Debug.LogError("The uv index is invalid (must be in [0..3]");
			}
			else
			{
				this.SetListForChannel<T>(this.GetUVChannel(uvIndex), Mesh.InternalVertexChannelType.Float, dim, uvs);
			}
		}

		public void SetUVs(int channel, List<Vector2> uvs)
		{
			this.SetUvsImpl<Vector2>(channel, 2, uvs);
		}

		public void SetUVs(int channel, List<Vector3> uvs)
		{
			this.SetUvsImpl<Vector3>(channel, 3, uvs);
		}

		public void SetUVs(int channel, List<Vector4> uvs)
		{
			this.SetUvsImpl<Vector4>(channel, 4, uvs);
		}

		private void GetUVsImpl<T>(int uvIndex, List<T> uvs, int dim)
		{
			if (uvs == null)
			{
				throw new ArgumentNullException("The result uvs list cannot be null.", "uvs");
			}
			if (uvIndex < 0 || uvIndex > 3)
			{
				throw new IndexOutOfRangeException("Specified uv index is out of range. Must be in the range [0, 3].");
			}
			this.GetListForChannel<T>(uvs, this.vertexCount, this.GetUVChannel(uvIndex), dim);
		}

		public void GetUVs(int channel, List<Vector2> uvs)
		{
			this.GetUVsImpl<Vector2>(channel, uvs, 2);
		}

		public void GetUVs(int channel, List<Vector3> uvs)
		{
			this.GetUVsImpl<Vector3>(channel, uvs, 3);
		}

		public void GetUVs(int channel, List<Vector4> uvs)
		{
			this.GetUVsImpl<Vector4>(channel, uvs, 4);
		}

		private bool CheckCanAccessSubmesh(int submesh, bool errorAboutTriangles)
		{
			bool result;
			if (!this.canAccess)
			{
				this.PrintErrorCantAccessMeshForIndices();
				result = false;
			}
			else if (submesh < 0 || submesh >= this.subMeshCount)
			{
				if (errorAboutTriangles)
				{
					this.PrintErrorBadSubmeshIndexTriangles();
				}
				else
				{
					this.PrintErrorBadSubmeshIndexIndices();
				}
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		private bool CheckCanAccessSubmeshTriangles(int submesh)
		{
			return this.CheckCanAccessSubmesh(submesh, true);
		}

		private bool CheckCanAccessSubmeshIndices(int submesh)
		{
			return this.CheckCanAccessSubmesh(submesh, false);
		}

		public int[] GetTriangles(int submesh)
		{
			return (!this.CheckCanAccessSubmeshTriangles(submesh)) ? new int[0] : this.GetTrianglesImpl(submesh);
		}

		public void GetTriangles(List<int> triangles, int submesh)
		{
			if (triangles == null)
			{
				throw new ArgumentNullException("The result triangles list cannot be null.", "triangles");
			}
			if (submesh < 0 || submesh >= this.subMeshCount)
			{
				throw new IndexOutOfRangeException("Specified sub mesh is out of range. Must be greater or equal to 0 and less than subMeshCount.");
			}
			this.PrepareUserBuffer<int>(triangles, (int)this.GetIndexCount(submesh));
			this.GetTrianglesNonAllocImpl(triangles, submesh);
		}

		public int[] GetIndices(int submesh)
		{
			return (!this.CheckCanAccessSubmeshIndices(submesh)) ? new int[0] : this.GetIndicesImpl(submesh);
		}

		public void GetIndices(List<int> indices, int submesh)
		{
			if (indices == null)
			{
				throw new ArgumentNullException("The result indices list cannot be null.", "indices");
			}
			if (submesh < 0 || submesh >= this.subMeshCount)
			{
				throw new IndexOutOfRangeException("Specified sub mesh is out of range. Must be greater or equal to 0 and less than subMeshCount.");
			}
			this.PrepareUserBuffer<int>(indices, (int)this.GetIndexCount(submesh));
			indices.Clear();
			this.GetIndicesNonAllocImpl(indices, submesh);
		}

		public void GetBindposes(List<Matrix4x4> bindposes)
		{
			if (bindposes == null)
			{
				throw new ArgumentNullException("The result bindposes list cannot be null.", "bindposes");
			}
			this.PrepareUserBuffer<Matrix4x4>(bindposes, this.GetBindposeCount());
			this.GetBindposesNonAllocImpl(bindposes);
		}

		public void GetBoneWeights(List<BoneWeight> boneWeights)
		{
			if (boneWeights == null)
			{
				throw new ArgumentNullException("The result boneWeights list cannot be null.", "boneWeights");
			}
			this.PrepareUserBuffer<BoneWeight>(boneWeights, this.vertexCount);
			this.GetBoneWeightsNonAllocImpl(boneWeights);
		}
	}
}