using Godot;
using System;
using System.Collections.Generic;

public enum Stage
{
	STAGE_MORTAL,
	STAGE_QI,
	STAGE_FOUNDATION,
	STAGE_GOLDEN,
	STAGE_NASCENT,
}

public partial class Player : Node
{
	public class Manual
	{
		public int Rank { get; set; } = 1;
		public int Profieciency { get; set; } = 0;
	}

	public int Essence { get; } = 0;
	public int Qi { get; } = 0;
	public int Spirit { get; } = 0;
	public int Literacy { get; } = 100;
	public int Age { get; } = 20;
	public int Longevity { get; } = 60;
	public Stage Stage { get; } = Stage.STAGE_MORTAL;
	public Dictionary<string, Manual> Manuals { get; set; }

	private Data _data;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_data = GetNode<Data>("/root/Data");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void LearnManual(string name)
	{
		if (_data.Manuals.ContainsKey(name) && !Manuals.ContainsKey(name))
		{
			Manuals.Add(name, new Manual
			{
				Rank = 1,
				Profieciency = 0,
			});
		}
	}
}
