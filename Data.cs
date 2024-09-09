using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;

public partial class Data : Node
{
	public class Manual
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public ManualRank[] Rank { get; set; }
	}

	public class ManualRank
	{
		public Attribute Gain { get; set; }
		public Attribute? Breakthrough { get; set; }
		public Attribute? Reach { get; set; }
	}

	public class Attribute
	{
		public int? Qi { get; set; }
		public int? Profieciency { get; set; }
		public string[] Flag { get; set; }
	}

	public Dictionary<string, Manual> Manuals { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_LoadManuals();
	}

	private void _LoadManuals()
	{
		Manuals = new Dictionary<string, Manual>();

		DirAccess dir = DirAccess.Open("res://data/item/manual");
		if (dir != null)
		{
			dir.ListDirBegin();
			string fileName = dir.GetNext();
			while (fileName != "")
			{
				if (dir.CurrentIsDir())
				{
					fileName = dir.GetNext();
					continue;
				}
				string path = "res://data/item/manual/" + fileName;
				FileAccess file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
				Dictionary<string, Manual> manual = JsonSerializer.Deserialize<Dictionary<string, Manual>>(file.GetAsText());
				foreach (KeyValuePair<string, Manual> kvp in manual)
				{
					Manuals[kvp.Key] = kvp.Value;
				}

				fileName = dir.GetNext();
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
