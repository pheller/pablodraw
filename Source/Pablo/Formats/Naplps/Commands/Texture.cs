using System.IO;

namespace Pablo.Formats.Naplps.Commands;

public enum LineTextureType
{
	Solid = 0,
	Dotted = 1,
	Dashed = 2,
	DottedDashed = 3
}

public enum TexturePatternType
{
	Solid = 0,
	VerticalHatching = 1,
	HorizontalHatching = 2,
	CrossHatching = 3,
	MaskA = 4,
	MaskB = 5,
	MaskC = 6,
	MaskD = 7
}

public class Texture : NaplpsCommand
{
	public class Type : NaplpsCommandType<Texture>
	{
		public override int OpCode
		{
			get { return 043; }
		}
	}

	public override void Read(BinaryReader reader)
	{
		base.Read(reader);

		var b = reader.ReadByte();

		LineTexture = (LineTextureType)(b & 0b00000011);
		Highlight = (b & 0b00000100) >> 2 == 1;
		TexturePattern = (TexturePatternType)((b & 0b00111000) >> 3);
		
		if ((reader.PeekChar() & 0b01000000) != 0)
		{
			// TODO read the mask size
		}
	}

	public TexturePatternType TexturePattern { get; set; }

	public bool Highlight { get; set; }

	public LineTextureType LineTexture { get; set; }
}