using Godot;
using System;

public partial class IntegerLineEdit : LineEdit
{
	private string oldText = "1";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void UpdateValue()
	{
		int value = int.Parse(oldText);
		if (int.TryParse(Text, out int parseValue))
		{
			value = parseValue;
		}
		Text = value.ToString();
		oldText = Text;
	}
}
