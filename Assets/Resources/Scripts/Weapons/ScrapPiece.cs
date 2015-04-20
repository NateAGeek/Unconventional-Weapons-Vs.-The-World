using UnityEngine;
using System.Collections;

public interface ScrapPiece {

	bool canFunctionAs(string type);

	int getHealth();

	void onAttach();

	string name();

	void onBroken();
	void isBroken();

}
