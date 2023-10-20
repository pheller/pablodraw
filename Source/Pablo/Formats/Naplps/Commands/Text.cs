using System.IO;

namespace Pablo.Formats.Naplps.Commands;

public enum TextCharacterPath
{
	Right = 0,
	Left = 1,
	Up = 2,
	Down = 3
	
}

public enum TextCharacterSpacing
{
	Single = 0,
	FiveFourths = 1,
	ThreeHalves = 2,
	Proportional = 3
}

public enum TextRowSpacing
{
	Single = 0,
	FiveFourths = 1,
	ThreeHalves = 2,
	Double = 3
}

public enum TextMoveStyle
{
	Together = 0,
	CursorLeads = 1,
	DrawingPointLeads = 2,
	Independent = 3
}

public enum TextCursorStyle
{
	Underscore = 0,
	Block = 1,
	CrossHair = 2,
	Custom = 3
}


public class Text : NaplpsCommand
{
	
	public class Type : NaplpsCommandType<Text>
	{
		public override int OpCode
		{
			get { return 042; }
		}
	}

	public override void Read(BinaryReader reader)
	{
		base.Read(reader);

		var b = reader.ReadByte();

		Rotation = (b & 0b00000011) * 90;
		CharacterPath = (TextCharacterPath) ((b & 0b00001100) >> 2);
		CharacterSpacing = (TextCharacterSpacing) ((b & 0b00110000) >> 4);

		b = reader.ReadByte();

		InterrowSpacing = (TextRowSpacing) (b & 0b00000011);
		MoveParameters = (TextMoveStyle) ((b & 0b00001100) >> 2);
		CursorStyle = (TextCursorStyle) ((b & 0b00110000) >> 4);
		
		// TODO read character vield dimensions
		
	}

	public TextCursorStyle CursorStyle { get; set; }

	public TextMoveStyle MoveParameters { get; set; }

	public TextRowSpacing InterrowSpacing { get; set; }

	public TextCharacterSpacing CharacterSpacing { get; set; }

	public TextCharacterPath CharacterPath { get; set; }


	public int Rotation { get; set; }
}