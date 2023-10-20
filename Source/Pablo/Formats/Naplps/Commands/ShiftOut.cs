namespace Pablo.Formats.Naplps.Commands;

public class ShiftOut : NaplpsCommand
{
	public class Type : NaplpsCommandType<ShiftOut>
	{
		public override int OpCode
		{
			get { return 016; }
		}
	}
}