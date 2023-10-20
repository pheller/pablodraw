namespace Pablo.Formats.Naplps.Commands;

public class Reset : NaplpsCommand
{
	public class Type : NaplpsCommandType<Reset>
	{
		public override int OpCode
		{
			get { return 040; }
		}
	}
}