namespace Pablo.Formats.Naplps.Commands;

public class LineAbsolute : NaplpsCommand
{
	public class Type : NaplpsCommandType<LineAbsolute>
	{
		public override int OpCode
		{
			get { return 050; }
		}
	}
}