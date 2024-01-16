using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Controller : MonoBehaviour
{
    public LevelPiece[] level_Piece;
    [SerializeField] private Transform _camera;
    [SerializeField] private int draw_Distance;
    [SerializeField] private float generated_Piece;
    [SerializeField] private float camera_Speed;

    Queue<GameObject> active_Piece = new Queue<GameObject>();
    List<int> probability_List = new List<int>();
    private int current_Cam_Step = 0;
    private int last_Cam_Step = 0;

    private void Start()
    {
        Build_List();
        for (int i = 0; i < draw_Distance; i++)
        {
            Spawned_Piece();
        }
        current_Cam_Step = (int)(_camera.transform.position.y / generated_Piece);
        last_Cam_Step = current_Cam_Step;
    }

    void Spawned_Piece()
    {
        int piece_Index = probability_List[Random.Range(0, probability_List.Count)];
        GameObject newLevelPiece = Instantiate(level_Piece[piece_Index].prefab, new Vector3(0f, (current_Cam_Step + active_Piece.Count) * generated_Piece, 0f), Quaternion.identity);
        active_Piece.Enqueue(newLevelPiece);
    }

    void Despawn_Piece()
    {
        GameObject old_piece = active_Piece.Dequeue();
        Destroy(old_piece);
    }
     void Build_List()
    {
        int index = 0;
        foreach (LevelPiece piece in level_Piece)
        {
            for (int i = 0; i < piece.probability; i++)
            {
                probability_List.Add(index);
            }
            index++;
        }
    }

    private void Update()
    {
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.up, Time.deltaTime * camera_Speed);
        current_Cam_Step = (int)(_camera.transform.position.y / generated_Piece);
        if (current_Cam_Step != last_Cam_Step)
        {
            last_Cam_Step = current_Cam_Step;
            Despawn_Piece();
            Spawned_Piece();
        }
    }
}

[System.Serializable]
public class LevelPiece
{
    [SerializeField] private string name;
    public GameObject prefab;
    public int probability = 1;
}