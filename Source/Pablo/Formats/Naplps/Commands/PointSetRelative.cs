namespace Pablo.Formats.Naplps.Commands;

public class PointSetRelative : NaplpsCommand
{
	public class Type : NaplpsCommandType<PointSetRelative>
	{
		public override int OpCode
		{
			get { return 044; }
		}
	}
	
}