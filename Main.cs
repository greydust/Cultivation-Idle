using Godot;
using System;

public partial class Main : Node
{
	[Export]
	public Story Story { get; set; }
	[Export]
	public ItemList StatusList { get; set; }

	private Player _player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_NewGame();
	}

	private void _NewGame()
	{
		_player = GetNode<Player>("/root/Player");
		_player.LearnManual("basic_manual");
		Story.ShowStory(new string[] { "INTRO1", "INTRO2", "INTRO3", "INTRO4" });
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_UpdateCharacterStatus();
	}

	private void _UpdateCharacterStatus()
	{
		StatusList.Clear();
		if (_player.Stage >= Stage.STAGE_QI)
		{
			StatusList.AddItem($"{Tr("ESSENCE")}: {_player.Essence}");
		}
		StatusList.AddItem($"{Tr("QI")}: {_player.Qi}");
		if (_player.Stage >= Stage.STAGE_FOUNDATION)
		{
			StatusList.AddItem($"{Tr("SPIRIT")}: {_player.Spirit}");
		}
		StatusList.AddItem($"{Tr("LITERACY")}: {_player.Literacy}");
		StatusList.AddItem($"{Tr("AGE")}: {_player.Age}");
		StatusList.AddItem($"{Tr("LONGEVITY")}: {_player.Longevity}");
		StatusList.AddItem($"{Tr("STAGE")}: {Tr(_player.Stage.ToString())}");
	}
}
