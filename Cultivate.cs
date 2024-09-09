using Godot;
using System;
using System.Collections.Generic;

public partial class Cultivate : Control
{
	[Export]
	public OptionButton Manual { get; set; }
	[Export]
	public Label Rank { get; set; }
	[Export]
	public Label GainContent { get; set; }
	[Export]
	public Label RequirementContent { get; set; }

	private Data _data;
	private Player _player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<Player>("/root/Player");
		_data = GetNode<Data>("/root/Data");

		foreach (KeyValuePair<string, Player.Manual> kvp in _player.Manuals)
		{
			Manual.AddItem(kvp.Key);
		}
	}

	public void SelectManual(int index)
	{
		string name = Manual.GetItemText(index);
		if (_data.Manuals.ContainsKey(name))
		{
			Player.Manual manual = _player.Manuals[name];
			Rank.Text = $"{Tr("Rank")}: {manual.Rank.ToString()}";
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
