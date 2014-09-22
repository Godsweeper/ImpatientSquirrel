using UnityEngine;
using System.Collections;

public class PuzzleAI : TouchTile {


	public static string[] puzzleSolution;
	public static int[] collNoSolve, rowNumSolve;


	public static void SolvePuzzle() 
	{
		switch (GameStateManager.Instance.activeState)
		{
		case "T1P1":
			print ("Get solution for oak puzzle 1");
			collNoSolve = new int[] {2,3};
			rowNumSolve = new int[] {1,1};
			puzzleSolution = new string[] {"down","left"};
			break;
		case "T1P2":
			print ("Get solution for oak puzzle 2");
			collNoSolve = new int[] {3};
			rowNumSolve = new int[] {1};
			puzzleSolution = new string[] {"left"};
			break;
		case "T1P3":
			print ("Get solution for oak puzzle 3");
			collNoSolve = new int[] {3};
			rowNumSolve = new int[] {2};
			puzzleSolution = new string[] {"up"};
			break;
		case "T1P4":
			print ("Get solution for oak puzzle 4");
			collNoSolve = new int[] {3,2,2};
			rowNumSolve = new int[] {1,1,2};
			puzzleSolution = new string[] {"down","right","up"};
			break;
		case "T1P5"://same as T1P2
			print ("Get solution for oak puzzle 5");
			collNoSolve = new int[] {3,3};
			rowNumSolve = new int[] {1,2};
			puzzleSolution = new string[] {"left","up"};
			break;
		case "T1P6":
			print ("Get solution for oak puzzle 6");
			collNoSolve = new int[] {1};
			rowNumSolve = new int[] {1};
			puzzleSolution = new string[] {"down"};
			break;
		case "T1P7":
			print ("Get solution for oak puzzle 7");
			collNoSolve = new int[] {2,2,2,2};
			rowNumSolve = new int[] {2,1,1,1};
			puzzleSolution = new string[] {"up","wait","wait","down"};
			break;
		case "T1P8":
			print ("Get solution for oak puzzle 8");
			collNoSolve = new int[] {1,2,2,2,2};
			rowNumSolve = new int[] {2,2,1,1,1};
			puzzleSolution = new string[] {"up","left","wait","wait","down"};
			break;
		case "T1P9":
			print ("Get solution for oak puzzle 9");
			collNoSolve = new int[] {2,2,3,3,2,2};
			rowNumSolve = new int[] {1,2,2,1,1,2};
			puzzleSolution = new string[] {"right","up","left","down", "right","up"};
			break;
		case "T1P10":
			print ("Get solution for oak puzzle 10");
			collNoSolve = new int[] {3,3,2,2};
			rowNumSolve = new int[] {2,1,1,2};
			puzzleSolution = new string[] {"left","down","right","up"};
			break;
		case "T1P11":
			print ("Get solution for oak puzzle 11");
			collNoSolve = new int[] {3,2,2,2,1,1,2,2};
			rowNumSolve = new int[] {1,1,2,2,2,1,1,2};
			puzzleSolution = new string[] {"down","right","up","wait","right","down","left","up"};
			break;
		case "T1P12":
			print ("Get solution for oak puzzle 12");
			collNoSolve = new int[] {2,2,3,3,2,2,2};
			rowNumSolve = new int[] {2,1,1,2,2,1,1};
			puzzleSolution = new string[] {"right","down","left","up","right","wait","down"};
			break;
		default:
			print ("Nothing is happening");
			break;
		}

				//if (collNumSolve[c] == 1 && rowNumSolve[i] == 1)
				//{
					//swipeGridCheck = new Vector2(collumnNo + 1, rowNo);
					//Check the grid for a viable swap
					//GameManager.Instance.GridCheckSwap(swipeGridCheck, this);
			//	Debug.Log ("Puzzle AI has happened");
					
					//at the end crystal nut must be deactivated
				//}
	
				

	}

}