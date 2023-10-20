using System.IO;

namespace Pablo.Formats.Naplps.Commands;

public class SetColor : NaplpsCommand
{
	public class Type : NaplpsCommandType<SetColor>
	{
		public override int OpCode
		{
			get { return 074; }
		}
	}

	public override void Read(BinaryReader reader)
	{
		// color is next byte
		reader.ReadByte();
	}
}