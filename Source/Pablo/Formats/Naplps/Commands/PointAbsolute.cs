namespace Pablo.Formats.Naplps.Commands;

public class PointAbsolute : NaplpsCommand
{
	public class Type : NaplpsCommandType<PointAbsolute>
	{
		public override int OpCode
		{
			get { return 046; }
		}
	}
	
}