using UnityEngine;
using System.Collections.Generic;

public abstract class Piece : MonoBehaviour{
    protected bool moveOnce = false;
    protected bool firstMove = true;
    [SerializeField]
    protected int maxHitPoints;
    [SerializeField]
    protected int currHitPoints;
    [SerializeField]
    protected int attackPower;

    protected List<Vector2Int> movement = new List<Vector2Int>();
    private Vector2Int position = new Vector2Int();
    public GameManager.TurnPlayer team;

    public enum PieceType {rook, bishop, king, queen, pawn, knight};
    protected PieceType pieceType;

    public virtual List<Vector2Int> GetAvailableMoves(Board board){
        List<Vector2Int> moves = new List<Vector2Int>();

        for(int i = 0 ; i < movement.Count ; i++){
            Vector2Int pos = position;

            bool checkNextSquare = true;
            while(checkNextSquare){
                pos = pos + movement[i];
                
                checkNextSquare = board.PieceCanOccupy(pos);
                if(checkNextSquare){
                    if(board.HasPiece(pos)){
                        checkNextSquare = false;
                        if(!(board.GetPiece(pos).GetComponent<Piece>().GetTeam() == team && board.GetPiece(pos).GetComponent<Piece>().GetPieceType() != pieceType)){
                            moves.Add(pos);
                        }
                    }else{
                        moves.Add(pos);
                    }
                }
                
                if(moveOnce) checkNextSquare = false;
            }
        }

        return moves;
    }

    public void MoveTo(Vector2Int new_position){
        firstMove = false;
        position = new_position;
        this.transform.position = new Vector3(position.x - 0.5f, position.y - 0.5f);
    }

    public Vector2Int GetPosition(){
        return this.position;
    }

    public GameManager.TurnPlayer GetTeam(){
        return this.team;
    }

    private void UpdateLifebar(){
        Transform lifebar = transform.Find("Lifebar");

        if(lifebar == null) return;

        Vector3 scale = lifebar.localScale;
        lifebar.localScale = new Vector3((1.0f*currHitPoints)/(maxHitPoints), scale.y, scale.z);
    }

    public void IsAttackedBy(Piece opponent){
        this.currHitPoints = Mathf.Max(0, (this.currHitPoints - opponent.GetAP()));
        UpdateLifebar();
    }

    public bool IsAlive(){
        return this.currHitPoints>0;
    } 
    public int GetCurrHP(){
        return this.currHitPoints;
    }
    public int GetAP(){
        return this.attackPower;
    }
    public int GetMaxHP(){
        return this.maxHitPoints;
    }

    public void MergePiece(Piece piece){
        this.currHitPoints = currHitPoints + piece.GetCurrHP();
        this.maxHitPoints += piece.GetMaxHP();
        this.attackPower += piece.GetAP();
        UpdateLifebar();
    }

    public PieceType GetPieceType(){
        return this.pieceType;
    }
}
