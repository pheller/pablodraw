using System.IO;

namespace Pablo.Formats.Naplps;

public abstract class NaplpsCommand
{
	public NaplpsCommandType CommandType { get; set; }

	public NaplpsDocument Document { get; set; }

	public int OpCode
	{
		get { return CommandType.OpCode;  }
	}
	public virtual void Read (BinaryReader reader)
	{
	}
		
	public virtual void Write (NaplpsWriter writer)
	{
		writer.WriteNewCommand (OpCode);
	}

}
	