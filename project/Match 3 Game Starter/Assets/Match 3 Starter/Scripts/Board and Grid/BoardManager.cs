/*
 * Copyright (c) 2017 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {
	
	/* 
	Các script khác cần được liên kết với BoardManager.cs, vì vậy sử dụng mẫu singleton
	với biến static tên là instance, cho phép nó được gọi từ bất kì script khác
	*/
	public static BoardManager instance;

	/* characters là một list các sprites sẽ dùng trong tile pieces */
	public List<Sprite> characters = new List<Sprite>();

	/* tile là prefab được sinh ra khi tạo bảng */
	public GameObject tile;

	/* kích thước của bảng */
	public int xSize, ySize;

	/* array 2D tiles chứa các tile */
	private GameObject[,] tiles;

	/* property bool IsShifting được gọi khi tìm được match, và các tile lại được lấp đầy */
	public bool IsShifting { get; set; }

	void Start () {
		instance = GetComponent<BoardManager>();

		// giới hạn kích thước tile
		Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;

        CreateBoard(offset.x, offset.y);
    }

	private void CreateBoard (float xOffset, float yOffset) {
		
		// tạo array tiles
		tiles = new GameObject[xSize, ySize];

		// vị trí bắt đầu của bảng
        float startX = transform.position.x;
		float startY = transform.position.y;

		// khởi tạo các tile theo từng vòng lặp
		for (int x = 0; x < xSize; x++) {
			for (int y = 0; y < ySize; y++) {

				// khởi tạo từng tile
				GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), tile.transform.rotation);
				tiles[x, y] = newTile;

				// gán transform cha của tất cả các tile vào BoardManager để giữ cho Hierarchy clean
				newTile.transform.parent = transform;

				// random sprite cho tile
				Sprite newSprite = characters[Random.Range(0, characters.Count)];
				newTile.GetComponent<SpriteRenderer>().sprite = newSprite;
			}
        }
    }

}
