using System.Collections.Generic;
using Elements.Core;
using FrooxEngine;

namespace ResoniteInputControl;

public struct MoveInputData
{
	public VR_LocomotionDirection controller;
	public IInputNode<float2> leftAxis;
	public IInputNode<float2> rightAxis;
	public IInputNode<float> leftSpeed;
	public IInputNode<float> rightSpeed;
}

public struct TurnInputData
{
	public VR_LocomotionTurn controller;
	public IInputNode<float2> leftAxis;
	public IInputNode<float2> rightAxis;
}

public struct Turn3AxisInputData
{
	public VR_LocomotionThreeAxisTurn controller;
	public IInputNode<float2> leftAxis;
	public IInputNode<float2> rightAxis;
}

public struct JumpInputData
{
	public AnyInput controller;
	public List<IInputNode<bool>> inputs;
}

public struct StateData(bool leftMove = true, bool rightMove = true, bool leftTurn = true, bool rightTurn = true, bool leftJump = true, bool rightJump = true)
{
	public bool LeftMove = leftMove;
	public bool RightMove = rightMove;

	public bool LeftTurn = leftTurn;
	public bool RightTurn = rightTurn;

	public bool LeftJump = leftJump;
	public bool RightJump = rightJump;
}