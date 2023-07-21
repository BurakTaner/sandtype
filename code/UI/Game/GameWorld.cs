﻿using System;
using System.Collections.Generic;
using Sandbox;
using Sandbox.UI;
using Sandtype.UI.Game.Entity;

namespace Sandtype.UI.Game;

public class GameWorld : Panel
{
	public TerryGame Game;
	public Action TerryHitAction;
	public Action BulletHitAction;
	private List<ClientWorldEntity> _entities;
	private SceneWorld World;
	private ScenePanel _scenePanel;
	private Vector3 headPos;
	private Vector3 aimPos;
	private Model citizenModel;
	private Vector3 startPos = Vector3.Zero
		.WithX( -140 )
		.WithY( 150f ) // 40 units to the left, hopefully?
		.WithZ( 40 );

	private Vector3 endPos = Vector3.Zero
		.WithX( 250 )
		.WithY( 150f ) // 40 units to the left, hopefully?
		.WithZ( 40 );

	public GameWorld()
	{
		//_entities = new List<ClientWorldEntity>();
		Style.Width = Length.Percent( 100 );
		Style.Height = Length.Percent( 100 );
		
		citizenModel = Model.Load( "models/citizen/citizen.vmdl" );

		// init world
		World = new SceneWorld()
		{
			ClearColor = Color.Black
		};
		
		// init scene panel
		_scenePanel = new ScenePanel();
		_scenePanel.World = World;
		_scenePanel.Camera.FieldOfView = 70;
		_scenePanel.Camera.AntiAliasing = true;
		_scenePanel.Camera.AmbientLightColor = Color.White;
		_scenePanel.Camera.ZFar = 100000f;
		_scenePanel.Camera.Rotation = Vector3.Left.EulerAngles.ToRotation();
		_scenePanel.Camera.Position = Vector3.Zero
			.WithX( 60 )
			.WithY( -150f ) // 40 units to the left, hopefully?
			.WithZ( 40 );// 40  units up

		_scenePanel.Style.Width = Length.Percent( 100 );
		_scenePanel.Style.Height = Length.Percent( 100 );
		_scenePanel.Style.PointerEvents = PointerEvents.All;
		
		AddChild( _scenePanel );

		new SceneSkyBox(World, Cloud.Material("semxy.bluecloudskybox" ));
	}
}
