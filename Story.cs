using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public partial class Story : Label
{
	[Export]
	public float MessageTime { get; set; } = 2.0f;

	private float _currentMessageTime = 0.0f;
	private string _currentMessage = "";
	private Queue<string> messageQueue = new Queue<string>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_currentMessage != "")
		{
			_currentMessageTime = Math.Clamp(_currentMessageTime + (float)delta, 0, MessageTime);
			int length = (int)(_currentMessage.Length * _currentMessageTime / MessageTime);
			Text = _currentMessage.Substring(0, length);
		}
	}

	public void NextMessage()
	{
		if (_currentMessageTime < MessageTime)
		{
			_currentMessageTime = MessageTime;
			return;
		}

		if (messageQueue.Count > 0)
		{
			_currentMessage = Tr(messageQueue.Dequeue());
			_currentMessageTime = 0.0f;
		}
		else
		{
			_currentMessage = "";
			GetParent<CanvasLayer>().Hide();
		}
	}

	public void ShowStory(string[] keys)
	{
		for (int i = 0; i < keys.Length; i++)
		{
			messageQueue.Enqueue(keys[i]);
		}
		_currentMessageTime = MessageTime;
		NextMessage();
		GetParent<CanvasLayer>().Show();
	}
}
