#pragma strict

function Start () {
		var mesh : Mesh = GetComponent(MeshFilter).mesh;
		mesh.RecalculateNormals();
}
