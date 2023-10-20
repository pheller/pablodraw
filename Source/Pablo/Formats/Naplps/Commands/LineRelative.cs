namespace Pablo.Formats.Naplps.Commands;

public class LineRelative : NaplpsCommand
{
	public class Type : NaplpsCommandType<LineRelative>
	{
		public override int OpCode
		{
			get { return 051; }
		}
	}
}