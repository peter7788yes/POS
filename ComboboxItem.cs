using System.Runtime.CompilerServices;

public class ComboboxItem
{
	[CompilerGenerated]
	private string <Text>k__BackingField;

	[CompilerGenerated]
	private object <Value>k__BackingField;

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return <Text>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			<Text>k__BackingField = value;
		}
	}

	public object Value
	{
		[CompilerGenerated]
		get
		{
			return <Value>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			<Value>k__BackingField = value;
		}
	}

	public ComboboxItem(string text, object value)
	{
		Text = text;
		Value = value;
	}

	public override string ToString()
	{
		return Text;
	}
}
