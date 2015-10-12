﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoicesButtons : MonoBehaviour {

	[SerializeField]
	private Text[] buttonTexts;

	private ArrayList buttons;

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_POST_WINDOW_BTN_CLICK, UpdateWindowButtons);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(AdvNames.ON_POST_WINDOW_BTN_CLICK, UpdateWindowButtons);
	}

	public void Start() {
		buttons = new ArrayList();
		AdvUtils.DisableAllChildren(transform);
	}

	public void OnButton1Click() {
		Parameters param = new Parameters();
		AdvChoices button = buttons[0] as AdvChoices;
		param.PutExtra(AdvNames.CHOICE_BTN_ID, button.name);
		EventBroadcaster.sharedInstance.CallObserver(AdvNames.ON_CHOICE_BTN_CLICK, param);
		AdvUtils.DisableAllChildren(transform);
	}

	public void OnButton2Click() {
		Parameters param = new Parameters();
		AdvChoices button = buttons[1] as AdvChoices;
		param.PutExtra(AdvNames.CHOICE_BTN_ID, button.name);
		EventBroadcaster.sharedInstance.CallObserver(AdvNames.ON_CHOICE_BTN_CLICK, param);
		AdvUtils.DisableAllChildren(transform);
	}

	public void OnButton3Click() {
		Parameters param = new Parameters();
		AdvChoices button = buttons[2] as AdvChoices;
		param.PutExtra(AdvNames.CHOICE_BTN_ID, button.name);
		EventBroadcaster.sharedInstance.CallObserver(AdvNames.ON_CHOICE_BTN_CLICK, param);
		AdvUtils.DisableAllChildren(transform);
	}

	public void UpdateWindowButtons(Parameters param) {
		if (param.GetExtra(AdvNames.ON_LAST_NODE, false)) {
			AdvUtils.EnableAllChildren(transform);
		}

		buttons = param.GetExtra(AdvNames.WINDOW_CHOICES, buttons);
		UpdateButtonNames();
	}

	public void UpdateButtonNames() {
		if (buttons == null)
			return;

		for (int i = 0; i < buttons.Count; i++) {
			AdvChoices choice = buttons[i] as AdvChoices;
			buttonTexts[i].text = choice.text;
		}
	}
}