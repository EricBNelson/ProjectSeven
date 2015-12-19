﻿namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Math)]
	[Tooltip("Sets the value of many Int Variable.")]
	public class SetMultiIntValue : FsmStateAction
	{
		[CompoundArray("Count", "Int Variable", "Value")]
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmInt[] intVariable;
		public FsmInt[] values;
		public bool everyFrame;
		
		public override void Reset()
		{
			intVariable = new FsmInt[1];
			values = new FsmInt[1];
		}

		public override void OnEnter()
		{
			DoSetIntValue();
			
			if (!everyFrame)
				Finish();
		}

		public override void OnUpdate()
		{
			DoSetIntValue();
		}

		public void DoSetIntValue()
		{
			for(int i = 0; i<intVariable.Length;i++){
				if(!intVariable[i].IsNone || !intVariable[i].Value.Equals("")) 
					intVariable[i].Value = values[i].IsNone ? 0: values[i].Value;
			}
		}
	}
}