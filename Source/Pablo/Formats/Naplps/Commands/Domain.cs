using System.IO;

namespace Pablo.Formats.Naplps.Commands;

public class Domain : NaplpsCommand
{
	public int SingleValueLength { get; set; }
	public int MultiValueLength { get; set; }
	public int Dimensionality { get; set; }
	public int LogicalPelSize { get; set; }
	
	public class Type : NaplpsCommandType<Domain>
	{
		public override int OpCode
		{
			get { return 041; }
		}
	}

	public override void Read(BinaryReader reader)
	{
		base.Read(reader);

		var b = reader.ReadByte();
		SingleValueLength = b & 0b00000011;
		MultiValueLength = (b & 0b00011100) >> 2;
		Dimensionality = (b & 0b00100000) >> 5 == 0 ? 2 : 3;

		if ((reader.PeekChar() & 0b01000000) != 0)
		{
			// TODO read the Logical Pel Size
		}
		
	}
}